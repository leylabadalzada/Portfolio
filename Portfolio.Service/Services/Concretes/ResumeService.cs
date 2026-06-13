using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
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

        public async Task<List<ResumeGetVM>> GetAsync(bool isFiltered)
        {
            var resumes = isFiltered ? await _context.Resumes.Where(r => !r.isDeleted).ToListAsync() : await _context.Resumes.ToListAsync();
            return resumes.Select(r => r.ToResumeGetVM()).ToList();
        }

        public async Task<bool> CreateAsync(ResumeCreateVM vm)
        {
            var resume = new Resume()
            {
                Filename = vm.File.UploadFile(_env.WebRootPath, FilePaths.ResumePath),
                IsLast = true
            };
            var result = await _context.AddAsync(resume);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<ResumeGetVM> GetLastResumeAsync()
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.IsLast && !r.isDeleted);
            return resume.ToResumeGetVM();
        }
    }
}
