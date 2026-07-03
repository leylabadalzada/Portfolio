using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.ViewModels.Project
{
    public record ProjectUpdateVM
    {
        public string ProjectName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string GitHubURL { get; set; }
        public string? LiveURL { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public bool IsFeatured { get; set; }
    }
}
