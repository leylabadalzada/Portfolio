using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<ResponseVM> ChangeImageAsync(ChangeImageVM vm);
        Task<ResponseVM<List<AuthorGetVM>>> GetAllAsync();
        Task<ResponseVM<AuthorGetVM>> GetAsync();
        Task<ResponseVM> UpdateAsync(AuthorUpdateVM vm);
    }
}
