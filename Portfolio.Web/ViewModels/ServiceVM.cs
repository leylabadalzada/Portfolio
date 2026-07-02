using Portfolio.Service.ViewModels.Skill;

namespace Portfolio.Web.ViewModels
{
    public class ServiceVM
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public ICollection<SkillGetVM> Skills { get; set; } = new List<SkillGetVM>();
    }
}
