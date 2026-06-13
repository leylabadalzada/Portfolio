using Portfolio.Service.ViewModels.Author;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<bool> ChangeImageAsync(ChangeImageVM vm);
        Task<List<AuthorGetVM>> GetAllAsync();
        Task<AuthorGetVM> GetAsync();
        Task<bool> UpdateAsync(AuthorUpdateVM vm);
    }
}
