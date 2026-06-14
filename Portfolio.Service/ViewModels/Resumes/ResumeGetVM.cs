namespace Portfolio.Service.ViewModels.Resumes
{
    public class ResumeGetVM
    {
        public string Id { get; set; }
        public string Filename { get; set; }
        public bool IsSelected { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
