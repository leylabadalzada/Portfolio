using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string GitHubURL { get; set; }
        public string? LiveURL { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; }

    }
}
