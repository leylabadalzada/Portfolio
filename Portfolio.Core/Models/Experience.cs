using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Experience : BaseEntity
    {
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool isContinuing { get; set; }
    }
}
