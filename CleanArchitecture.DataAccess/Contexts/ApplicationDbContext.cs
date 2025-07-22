using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.DataAccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);

            builder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderId, od.BookId });

            builder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderDetails>()
                .HasOne(od => od.Book)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData
                (
                     new IdentityRole() { Id = "1", Name = SD.Role_Admin, ConcurrencyStamp = "1", NormalizedName = SD.Role_Admin },
                     new IdentityRole() { Id = "2", Name = SD.Role_User, ConcurrencyStamp = "2", NormalizedName = SD.Role_User },
                     new IdentityRole() { Id = "3", Name = SD.Role_Author, ConcurrencyStamp = "3", NormalizedName = SD.Role_Author }
                );
        }
    }
}
