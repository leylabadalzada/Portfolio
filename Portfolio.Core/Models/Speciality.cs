using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
    }
}
