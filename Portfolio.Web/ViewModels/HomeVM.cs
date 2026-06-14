using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Resumes;
using Portfolio.Service.ViewModels.Speciality;

namespace Portfolio.Web.ViewModels
{
    public class HomeVM
    {
        public AuthorGetVM Author { get; set; }
        public ResumeGetVM Resume { get; set; }
        public ICollection<SpecialityGetVM> Specialities { get; set; } = new List<SpecialityGetVM>();
    }
}
