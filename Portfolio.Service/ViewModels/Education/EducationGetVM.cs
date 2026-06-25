namespace Portfolio.Service.ViewModels.Education
{
    public record EducationGetVM
    {
        public string Id { get; set; }
        public string Speciality { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool isContinuing { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
