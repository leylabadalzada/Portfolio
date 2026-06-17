using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Service.Services.Concretes
{
    public class SocialMediaService : ISocialMediaService
    {
        readonly AppDbContext _context;

        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(SocialMediaCreateVM vm)
        {
            var media = new SocialMedia
            {
                SocialMediaName = vm.Name,
                UserName = vm.UserName,
                Url = vm.Url
            };
            var result = await _context.AddAsync(media);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<List<SocialMediaGetVM>> GetAllAsync()
        {
            return await _context.SocialMedias.Select(sm => sm.ToSocialMediaGetVM()).ToListAsync();
        }
    }
}
