using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Enums;
using Portfolio.Data.Contexts;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;
using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.Response;

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

        public async Task<ResponseVM<List<AuthorGetVM>>> GetAllAsync()
        {
            var query = _context.Authors.AsNoTracking();
            return new ResponseVM<List<AuthorGetVM>> { Data = await query.Select(author => author.ToAuthorGetVM()).ToListAsync() };
        }

        public async Task<ResponseVM<AuthorGetVM>> GetAsync()
        {
            var author = await _context.Authors.AsNoTracking().FirstOrDefaultAsync();
            if (author == null) return new ResponseVM<AuthorGetVM> { Result = false, Message = ResponseMessage.NotFoundMessage("Author") };
            return new ResponseVM<AuthorGetVM> { Data = author.ToAuthorGetVM() };
        }

        public async Task<ResponseVM> ChangeImageAsync(ChangeImageVM vm)
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            if (!author.ImageName.Contains("default.png"))
            {
                var path = Path.Combine(_env.WebRootPath, FilePaths.AuthorPath, author.ImageName);
                if (File.Exists(path)) File.Delete(path);
            }

            author.ImageName = vm.NewImage.UploadFile(_env.WebRootPath, FilePaths.AuthorPath);

            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Image changed") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }

        public async Task<ResponseVM> UpdateAsync(AuthorUpdateVM vm)
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");

            author.FirstName = vm.FirstName;
            author.LastName = vm.LastName;
            author.Info = vm.Info;
            author.Description = vm.Description;
            author.Location = vm.Location;
            author.Email = vm.Email;
            author.isFreelanceAvailable = vm.isFreelanceAvailable.Value;
            author.BirthDate = DateOnlyUtils.GenerateDate(vm.BirthDate.Day, vm.BirthDate.Month, vm.BirthDate.Year);
            var result = _context.Update(author);
            if (result.State != EntityState.Modified) return new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Update) };
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0 ? new ResponseVM { Message = ResponseMessage.SuccessMessage("Updated") } : new ResponseVM { Result = false, Message = ResponseMessage.FailMessage(ResponseMessageContent.Save) };
        }
    }
}
