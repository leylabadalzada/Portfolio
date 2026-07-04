using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<ResponseVM> ChangeImageAsync(ChangeImageVM vm);
        Task<ResponseVM<AuthorGetVM>> GetAsync();
        Task<ResponseVM> UpdateAsync(AuthorUpdateVM vm);
        Task<ResponseVM> ChangeEmailAsync(string email);
        Task<ResponseVM> VerifyEmailAsync(string email, int otp);
        //todo: ChangePassword
    }
}
