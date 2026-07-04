using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<ResponseVM<List<SocialMediaGetVM>>> GetAllAsync();
        Task<ResponseVM> CreateAsync(SocialMediaCreateOrUpdateVM vm);
        Task<ResponseVM> UpdateAsync(Guid id, SocialMediaCreateOrUpdateVM vm);
        Task<ResponseVM<SocialMediaGetVM>> GetAsync(Guid id);
        Task<ResponseVM> RemoveAsync(Guid id);
    }
}
