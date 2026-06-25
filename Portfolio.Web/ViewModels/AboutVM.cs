using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Education;
using Portfolio.Service.ViewModels.Language;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Web.ViewModels
{
    public class AboutVM
    {
        public AuthorGetVM Author { get; set; }
        public string Speciality { get; set; }
        public ICollection<SocialMediaGetVM> SocialMedias { get; set; } = new List<SocialMediaGetVM>();
        public ICollection<LanguageGetVM> Languages { get; set; } = new List<LanguageGetVM>();
        public ICollection<EducationGetVM> Education { get; set; } = new List<EducationGetVM>();
    }
}
