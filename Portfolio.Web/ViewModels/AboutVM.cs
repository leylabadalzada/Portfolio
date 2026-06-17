using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Web.ViewModels
{
    public class AboutVM
    {
        public AuthorGetVM Author { get; set; }
        public string Speciality { get; set; }
        public List<SocialMediaGetVM> SocialMedias { get; set; }
    }
}
