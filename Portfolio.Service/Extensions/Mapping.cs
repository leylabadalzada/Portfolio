using Portfolio.Core.Models;
using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Education;
using Portfolio.Service.ViewModels.Experience;
using Portfolio.Service.ViewModels.Field;
using Portfolio.Service.ViewModels.Language;
using Portfolio.Service.ViewModels.Project;
using Portfolio.Service.ViewModels.Resumes;
using Portfolio.Service.ViewModels.Skill;
using Portfolio.Service.ViewModels.SocialMedia;
using Portfolio.Service.ViewModels.Speciality;

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
                Email = author.Email,
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
                IsSelected = resume.IsSelected,
                CreatedAt = resume.CreatedAt,
                UpdatedAt = resume.UpdatedAt
            };
        }

        public static SpecialityGetVM ToSpecialityGetVM(this Speciality speciality)
        {
            return new SpecialityGetVM
            {
                Id = speciality.ID.ToString(),
                CreatedAt = speciality.CreatedAt,
                IsMain = speciality.IsMain,
                Name = speciality.Name,
                UpdatedAt = speciality.UpdatedAt
            };
        }

        public static SocialMediaGetVM ToSocialMediaGetVM(this SocialMedia socialMedia)
        {
            return new SocialMediaGetVM
            {
                Id = socialMedia.ID.ToString(),
                SocialMediaName = socialMedia.SocialMediaName,
                Url = socialMedia.Url,
                UserName = socialMedia.UserName,
                CreatedAt = socialMedia.CreatedAt,
                UpdatedAt = socialMedia.UpdatedAt
            };
        }

        public static LanguageGetVM ToLanguageGetVM(this Language language)
        {
            return new LanguageGetVM
            {
                Id = language.ID.ToString(),
                CreatedAt = language.CreatedAt,
                LevelName = language.Level.ToString(),
                Level = language.Level,
                Name = language.Name,
                UpdatedAt = language.UpdatedAt
            };
        }

        public static EducationGetVM ToEducationGetVM(this Education education)
        {
            return new EducationGetVM
            {
                Id = education.ID.ToString(),
                Description = education.Description,
                EndDate = education.EndDate,
                isContinuing = education.isContinuing,
                Speciality = education.Speciality,
                StartDate = education.StartDate,
                University = education.University,
                UpdatedAt = education.UpdatedAt,
                CreatedAt = education.CreatedAt
            };
        }

        public static FieldGetVM ToFieldGetVM(this Field field)
        {
            return new FieldGetVM
            {
                Id = field.ID.ToString(),
                CreatedAt = field.CreatedAt,
                UpdatedAt = field.UpdatedAt,
                FieldName = field.FieldName
            };
        }

        public static ExperienceGetVM ToExperienceGetVM(this Experience experience)
        {
            return new ExperienceGetVM
            {
                Id = experience.ID.ToString(),
                Description = experience.Description,
                EndDate = experience.EndDate,
                isContinuing = experience.isContinuing,
                Position = experience.Position,
                StartDate = experience.StartDate,
                Company = experience.Company,
                UpdatedAt = experience.UpdatedAt,
                CreatedAt = experience.CreatedAt
            };
        }

        public static SkillGetVM ToSkillGetVM(this Skill skill)
        {
            return new SkillGetVM
            {
                Id = skill.ID.ToString(),
                CreatedAt = skill.CreatedAt,
                FieldId = skill.FieldId.ToString(),
                Description = skill.Description,
                Name = skill.Name,
                UpdatedAt = skill.UpdatedAt,
                FieldName = skill.Field.FieldName
            };
        }

        public static ProjectGetVM ToProjectGetVM(this Project project)
        {
            return new ProjectGetVM
            {
                Id = project.ID.ToString(),
                CreatedAt = project.CreatedAt,
                Description = project.Description,
                GitHubURL = project.GitHubURL,
                Image = project.Image,
                IsFeatured = project.IsFeatured,
                LiveURL = project.LiveURL,
                ProjectName = project.ProjectName,
                ShortDescription = project.ShortDescription,
                UpdatedAt = project.UpdatedAt
            };
        }
    }
}
