using Portfolio.Service.ViewModels.Auth;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResponseVM> ForgotPasswordAsync(string email);
        Task<ResponseVM> LoginAsync(LoginVM vm);
        Task LogoutAsync();
        Task<ResponseVM> ResetPasswordAsync(ResetPasswordVM vm);
    }
}
