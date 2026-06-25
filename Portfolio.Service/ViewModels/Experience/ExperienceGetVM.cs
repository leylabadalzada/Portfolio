namespace Portfolio.Service.ViewModels.Experience
{
    public class ExperienceGetVM
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool isContinuing { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
