using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Skill
{
    public record SkillCreateVM
    {
        public SkillType Name { get; set; }
        public SkillLevel Level { get; set; }
        public Guid FieldId { get; set; }
    }
}
