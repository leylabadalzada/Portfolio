using Portfolio.Core.Models;
using Portfolio.Service.DTOs.Author;

namespace Portfolio.Service.Extensions
{
    public static class Mapping
    {
        public static AuthorGetDto ToGetDto(this Author author)
        {
            return new AuthorGetDto
            {
                Location = author.Location,
                BirthDate = author.BirthDate,
                Description = author.Description,
                FullName = $"{author.FirstName} {author.LastName}",
                ImageURL = author.ImageURL,
                Info = author.Info,
                isFreelanceAvailable = author.isFreelanceAvailable
            };
        }
    }
}
