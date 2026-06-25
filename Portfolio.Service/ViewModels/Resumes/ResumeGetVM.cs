namespace Portfolio.Service.ViewModels.Resumes
{
    public record ResumeGetVM
    {
        public string Id { get; set; }
        public string Filename { get; set; }
        public bool IsSelected { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
