using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Field : BaseEntity
    {
        public string FieldName { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
