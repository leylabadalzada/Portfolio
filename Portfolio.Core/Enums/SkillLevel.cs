using System.ComponentModel.DataAnnotations;

namespace Portfolio.Core.Enums
{
    public enum SkillLevel
    {
        [Display(Name = "Beginner")]
        Beginner = 1,

        [Display(Name = "Intermediate")]
        Intermediate = 2,

        [Display(Name = "Advanced")]
        Advanced = 3,

        [Display(Name = "Expert")]
        Expert = 4
    }
}
