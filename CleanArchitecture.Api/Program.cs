using BrainHope.Services.DTO.Email;
using CleanArchitecture.DataAccess;
using CleanArchitecture.DataAccess.Contexts;
using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Services;
using CleanArchitecture.Services.Interfaces;
using CleanArchitecture.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Utilites;

namespace CleanArchitecture.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            // Inject external DI
            builder.Services
                .AddDataAccessServices(config)
                .AddServiceLayer()
                .AddApiLayer(config);

            // Identity config
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region JWT


            #region Cores

            // 🔹 Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            #endregion


            // ✅ Add infrastructure layer (JWT, Google)
            builder.Services.AddInfrastructure(builder.Configuration);
            #endregion


            #region Email
            var Configure = builder.Configuration;
            var emailconfig = Configure.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailconfig);
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);
            #endregion
            builder.Services.AddAuthorization();

            // Redis
            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisConnection = config.GetSection("Redis")["ConnectionString"];
                return ConnectionMultiplexer.Connect(redisConnection);
            });



            builder.Services.AddSignalR();

            builder.Services.AddScoped<UserRatingSeeder>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate(); // Apply migrations if needed

                    var seeder = services.GetRequiredService<UserRatingSeeder>();
                    seeder.SeedUserRatingsAsync().GetAwaiter().GetResult(); // <-- No await needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Seeding error: {ex.InnerException?.Message ?? ex.Message}");
                }
            }

            // Redis ImageHelper Config
            var accessor = app.Services.GetRequiredService<IHttpContextAccessor>();
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();
            ImageHelper.Configure(accessor, env);

            // Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();


            app.Run();
        }
    }
}
