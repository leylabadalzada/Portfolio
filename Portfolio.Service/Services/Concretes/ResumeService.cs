using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
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

        public async Task<List<ResumeGetVM>> GetAsync()
        {
            var resumes = await _context.Resumes.AsNoTracking().OrderByDescending(r => r.CreatedAt).ToListAsync();
            return resumes.Select(r => r.ToResumeGetVM()).ToList();
        }

        public async Task<bool> CreateAsync(ResumeCreateVM vm)
        {
            var resume = new Resume()
            {
                Filename = vm.File.UploadFile(_env.WebRootPath, FilePaths.ResumePath),
                IsSelected = true
            };
            var result = await _context.AddAsync(resume);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<ResumeGetVM> GetSelectedResumeAsync()
        {
            var resume = await _context.Resumes.AsNoTracking().FirstOrDefaultAsync(r => r.IsSelected);
            return resume.ToResumeGetVM();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null) throw new NotFoundException("resume");

            var path = Path.Combine(_env.WebRootPath, FilePaths.ResumePath, resume.Filename);
            if (File.Exists(path)) File.Delete(path);

            var result = _context.Remove(resume);
            if (result.State != EntityState.Deleted) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;

        }

        public async Task<bool> SelectResumeAsync(Guid id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null) throw new NotFoundException("resume");

            resume.IsSelected = true;

            var result = _context.Update(resume);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}
