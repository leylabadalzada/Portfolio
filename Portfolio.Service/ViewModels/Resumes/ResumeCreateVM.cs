using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.ViewModels.Resumes
{
    public class ResumeCreateVM
    {
        public IFormFile File { get; set; }
    }
}
