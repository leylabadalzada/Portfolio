using System.ComponentModel.DataAnnotations;

namespace Portfolio.Service.ViewModels.Auth
{
    public record ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
