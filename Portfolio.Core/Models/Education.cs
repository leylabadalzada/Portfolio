using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Education : BaseEntity
    {
        public string Speciality { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool isContinuing { get; set; }
    }
}
