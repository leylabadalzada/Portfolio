using Portfolio.Core.Enums;
using Portfolio.Core.Models.BaseModels;

namespace Portfolio.Core.Models
{
    public class Skill : BaseEntity
    {
        public SkillType Name { get; set; }
        public SkillLevel Level { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
    }
}
