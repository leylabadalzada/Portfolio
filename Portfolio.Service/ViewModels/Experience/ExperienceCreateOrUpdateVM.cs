using Portfolio.Service.ViewModels.General;

namespace Portfolio.Service.ViewModels.Experience
{
    public class ExperienceCreateOrUpdateVM
    {
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public DateVM? StartDate { get; set; }
        public DateVM? EndDate { get; set; }
        public bool isContinuing { get; set; }
    }
}
