namespace Portfolio.Service.ViewModels.Project
{
    public record ProjectGetVM
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string GitHubURL { get; set; }
        public string? LiveURL { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
