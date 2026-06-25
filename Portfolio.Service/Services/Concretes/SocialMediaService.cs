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

        public async Task<bool> CreateAsync(SocialMediaCreateOrUpdateVM vm)
        {
            var media = new SocialMedia
            {
                SocialMediaName = vm.SocialMediaName,
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
            return await _context.SocialMedias.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(sm => sm.ToSocialMediaGetVM()).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, SocialMediaCreateOrUpdateVM vm)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            if (media == null) return false;
            media.UserName = vm.UserName;
            media.Url = vm.Url;
            media.SocialMediaName = vm.SocialMediaName;

            var result = _context.Update(media);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<SocialMediaGetVM> GetAsync(Guid id)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            if (media == null) throw new Exception("Social media not found");
            return media.ToSocialMediaGetVM();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            if (media == null) throw new Exception("Social media not found");
            var result = _context.Remove(media);
            if (result.State != EntityState.Deleted) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}
