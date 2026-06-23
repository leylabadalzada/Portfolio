using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaGetVM>> GetAllAsync();
        Task<bool> CreateAsync(SocialMediaCreateOrUpdateVM vm);
        Task<bool> UpdateAsync(Guid id, SocialMediaCreateOrUpdateVM vm);
        Task<SocialMediaGetVM> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
