using Portfolio.Core.Enums;

namespace Portfolio.Service.ViewModels.Skill
{
    public class SkillGetVM
    {
        public string Id { get; set; }
        public SkillType Name { get; set; }
        public SkillLevel Level { get; set; }
        public string LevelAsString { get; set; }
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
