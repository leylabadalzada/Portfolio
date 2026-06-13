using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Data.Contexts;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Author;

namespace Portfolio.Service.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;

        public AuthorService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<AuthorGetVM>> GetAllAsync()
        {
            var query = _context.Authors.AsNoTracking();
            return await query.Select(author => author.ToAuthorGetVM()).ToListAsync();
        }

        public async Task<AuthorGetVM> GetAsync()
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            return author.ToAuthorGetVM();
        }

        public async Task<bool> ChangeImageAsync(ChangeImageVM vm)
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            if (!author.ImageName.Contains("default.png"))
            {
                var path = Path.Combine(_env.WebRootPath, FilePaths.AuthorPath, author.ImageName);
                if (File.Exists(path)) File.Delete(path);
            }

            author.ImageName = vm.NewImage.UploadFile(_env.WebRootPath, FilePaths.AuthorPath);
            //author.ImageName = Path.Combine(_url, author.ImageName);

            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<bool> UpdateAsync(AuthorUpdateVM vm)
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");

            author.FirstName = vm.FirstName;
            author.LastName = vm.LastName;
            author.Info = vm.Info;
            author.Description = vm.Description;
            author.Location = vm.Location;
            author.isFreelanceAvailable = vm.isFreelanceAvailable.Value;
            author.BirthDate = DateOnlyUtils.GenerateDate(vm.BirthDate.Day, vm.BirthDate.Month, vm.BirthDate.Year);
            var result = _context.Update(author);
            if (result.State != EntityState.Modified) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}
