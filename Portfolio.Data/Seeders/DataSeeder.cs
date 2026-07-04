using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;

namespace Portfolio.Data.Seeders
{
    public static class DataSeeder
    {
        public static void SeedAuthor(this ModelBuilder builder)
        {
            var author = new Author()
            {
                Id = Guid.NewGuid().ToString(),
                ImageName = "default.png",
                Info = "Sample Developer Information",
                FirstName = "FirstName",
                LastName = "Lastname",
                Location = "Location",
                Email = "email@sample.domain",
                BirthDate = DateOnly.MinValue,
                Description = "Sample Developer Description",
                CreatedAt = TimeConstants.AzerbaijaniTime,
                isFreelanceAvailable = true,
                NormalizedEmail = "EMAIL@SAMLE.DOMAIN",
                UserName = "author123",
                NormalizedUserName = "AUTHOR123",
                PhoneNumber = "+994123456789",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                AccessFailedCount = 3,
                LockoutEnabled = true
            };

            var hash = new PasswordHasher<Author>();
            author.PasswordHash = hash.HashPassword(author, "Author123@");

            builder.Entity<Author>().HasData(author);

            var role = SeedRole(builder);
            var authorRole = new IdentityUserRole<string>()
            {
                RoleId = role.Id,
                UserId = author.Id
            };

            builder.Entity<IdentityUserRole<string>>().HasData(authorRole);

        }

        public static IdentityRole SeedRole(this ModelBuilder builder)
        {
            var role = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Author", NormalizedName = "AUTHOR" };
            builder.Entity<IdentityRole>().HasData(role);
            return role;
        }

        public static void SeedSpeciality(this ModelBuilder builder)
        {
            var speciality = new Speciality
            {
                ID = Guid.NewGuid(),
                Name = "Some speciality",
                IsMain = true,
                CreatedAt = DateTime.UtcNow
            };

            builder.Entity<Speciality>().HasData(speciality);
        }
    }
}
