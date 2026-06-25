using Portfolio.Service.ViewModels.General;

namespace Portfolio.Service.ViewModels.Education
{
    public record EducationCreateOrUpdateVM
    {
        public string Speciality { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public DateVM? StartDate { get; set; }
        public DateVM? EndDate { get; set; }
        public bool isContinuing { get; set; }
    }
}
