using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Service.ViewModels.Author
{
    public record ChangePasswordVM
    {
        [PasswordPropertyText]
        public string NewPassword { get; set; }
        [PasswordPropertyText]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
