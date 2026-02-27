using Portfolio.Service.DTOs.Author;

namespace Portfolio.Service.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<bool> ChangeImageAsync(ChangeImageDto dto);
        Task<bool> CreateAsync(AuthorCreateDto dto);
        Task<List<AuthorGetDto>> GetAllAsync();
        Task<AuthorGetDto> GetAsync();
    }
}
