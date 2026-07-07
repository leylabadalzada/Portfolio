using System.ComponentModel.DataAnnotations;

public class ResetPasswordVM
{
    public string Email { get; set; }

    public string Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required]
    [Compare(nameof(NewPassword))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}