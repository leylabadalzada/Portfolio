using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;

namespace Portfolio.Data.Seeders
{
    public static class AuthorSeeder
    {
        public static void SeedAuthor(this ModelBuilder builder)
        {
            var author = new Author()
            {
                ImageName = "default.png",
                Info = "Sample Developer Information",
                FirstName = "FirstName",
                LastName = "Lastname",
                Location = "Location",
                Email = "email@sample.domain",
                BirthDate = DateOnly.MinValue,
                Description = "Sample Developer Description",
                CreatedAt = TimeConstants.AzerbaijaniTime,
                isFreelanceAvailable = true
            };
            builder.Entity<Author>().HasData(author);
        }
    }
}
