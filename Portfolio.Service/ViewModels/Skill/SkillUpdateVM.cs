using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Skill
{
    public record SkillUpdateVM
    {
        public SkillType Name { get; set; }
        public SkillLevel Level { get; set; }
    }
}
