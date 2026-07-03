using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IEmailService
    {
        Task<ResponseVM> SendEmailAsync(string from, string subject, string body, bool isHTML = true);
    }
}
