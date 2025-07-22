using CleanArchitecture.DataAccess.Contexts;
using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.Infrastructure.DataSeed;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace CleanArchitecture.Infrastructure
{

    public class UserRatingSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRatingSeeder> _logger;

        public UserRatingSeeder(ApplicationDbContext context, ILogger<UserRatingSeeder> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedUserRatingsAsync()
        {
            try
            {
                var hasData = await _context.UserRatings.AnyAsync();
                if (hasData)
                {
                    _logger.LogInformation("UserRatings table already has data. Skipping seeding.");
                    return;
                }

                var path = Path.Combine(AppContext.BaseDirectory, "DataSeed", "UserRatings.csv");

                if (!File.Exists(path))
                {
                    _logger.LogWarning("CSV file not found at path: {Path}", path);
                    return;
                }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);
                csv.Context.RegisterClassMap<UserRatingMap>();

                var records = csv.GetRecords<UserRating>().ToList();

                await _context.UserRatings.AddRangeAsync(records);
                await _context.SaveChangesAsync();

                _logger.LogInformation("UserRatings seeding completed. Inserted {Count} records.", records.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seeding error: {Message}", ex.Message);
            }
        }
    }
}