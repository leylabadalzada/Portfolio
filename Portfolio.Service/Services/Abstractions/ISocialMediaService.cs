using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaGetVM>> GetAllAsync();
        Task<bool> CreateAsync(SocialMediaCreateVM vm);
    }
}
