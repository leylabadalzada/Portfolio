using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Response;
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

        public async Task<ResponseVM> CreateAsync(SocialMediaCreateOrUpdateVM vm)
        {
            var media = new SocialMedia
            {
                SocialMediaName = vm.SocialMediaName,
                UserName = vm.UserName,
                Url = vm.Url
            };
            var result = await _context.AddAsync(media);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<List<SocialMediaGetVM>>> GetAllAsync()
        {
            return new ResponseVM<List<SocialMediaGetVM>> { Data = await _context.SocialMedias.AsNoTracking().OrderByDescending(e => e.CreatedAt).Select(sm => sm.ToSocialMediaGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM> UpdateAsync(Guid id, SocialMediaCreateOrUpdateVM vm)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            if (media == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Social Media") };
            media.UserName = vm.UserName;
            media.Url = vm.Url;
            media.SocialMediaName = vm.SocialMediaName;

            var result = _context.Update(media);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<SocialMediaGetVM>> GetAsync(Guid id)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            return media == null ? new ResponseVM<SocialMediaGetVM>
            {
                Message = ResponseMessage.NotFoundMessage("Social media"),
                Result = false
            } : new ResponseVM<SocialMediaGetVM> { Data = media.ToSocialMediaGetVM() };
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var media = await _context.SocialMedias.FindAsync(id);
            if (media == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Social media") };
            var result = _context.Remove(media);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}
