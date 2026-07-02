using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Skill
{
    public record SkillUpdateVM
    {
        public SkillType Name { get; set; }
        public string Description { get; set; }
    }
}
