using Portfolio.Core.Models;
using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Service.Extensions
{
    public static class Mapping
    {
        public static AuthorGetVM ToAuthorGetVM(this Author author)
        {
            return new AuthorGetVM
            {
                Id = author.ID.ToString(),
                Location = author.Location,
                BirthDate = author.BirthDate,
                Description = author.Description,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Info = author.Info,
                isFreelanceAvailable = author.isFreelanceAvailable,
                ImageName = author.ImageName
            };
        }

        public static ResumeGetVM ToResumeGetVM(this Resume resume)
        {
            return new ResumeGetVM
            {
                Id = resume.ID.ToString(),
                Filename = resume.Filename,
                IsLast = resume.IsSelected,
                CreatedAt = resume.CreatedAt,
                UpdatedAt = resume.UpdatedAt
            };
        }
    }
}
