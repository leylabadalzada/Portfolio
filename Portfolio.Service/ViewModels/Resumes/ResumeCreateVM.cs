using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.ViewModels.Resumes
{
    public record ResumeCreateVM
    {
        public IFormFile File { get; set; }
    }
}
