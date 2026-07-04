using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Response;
using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Service.Services.Concretes
{
    public class ResumeService : IResumeService
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;

        public ResumeService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<ResponseVM<List<ResumeGetVM>>> GetAsync()
        {
            return new ResponseVM<List<ResumeGetVM>> { Data = await _context.Resumes.OrderByDescending(e => e.CreatedAt).AsNoTracking().OrderByDescending(r => r.CreatedAt).Select(r => r.ToResumeGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM> CreateAsync(ResumeCreateVM vm)
        {
            var resume = new Resume()
            {
                Filename = vm.File.UploadFile(_env.WebRootPath, FilePaths.ResumePath),
                IsSelected = true
            };
            var result = await _context.AddAsync(resume);
            if (result.State != EntityState.Added) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Add) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Created") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM<ResumeGetVM>> GetSelectedResumeAsync()
        {
            var resume = await _context.Resumes.AsNoTracking().FirstOrDefaultAsync(r => r.IsSelected);
            return resume == null ? new ResponseVM<ResumeGetVM>
            {
                Message = ResponseMessage.NotFoundMessage("Resume"),
                Result = false
            } : new ResponseVM<ResumeGetVM> { Data = resume.ToResumeGetVM() }; ;
        }

        public async Task<ResponseVM> RemoveAsync(Guid id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Resume") };

            var path = Path.Combine(_env.WebRootPath, FilePaths.ResumePath, resume.Filename);
            if (File.Exists(path)) File.Delete(path);

            var result = _context.Remove(resume);
            if (result.State != EntityState.Deleted) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Remove) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Removed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };

        }

        public async Task<ResponseVM> SelectResumeAsync(Guid id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null) return new ResponseVM { Result = false, Message = ResponseMessage.NotFoundMessage("Resume") };

            resume.IsSelected = true;

            var result = _context.Update(resume);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}
