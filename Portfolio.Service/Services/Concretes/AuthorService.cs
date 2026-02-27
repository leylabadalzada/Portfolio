using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.DTOs.Author;
using Portfolio.Service.Exceptions;
using Portfolio.Service.Extensions;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.Utils;

namespace Portfolio.Service.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;
        string _url;

        public AuthorService(AppDbContext context, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _context = context;
            _env = env;
            _accessor = accessor;
            _url = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}/{FilePaths.AuthorPath}";
        }

        public async Task<bool> CreateAsync(AuthorCreateDto dto)
        {
            var author = new Author()
            {
                ID = Guid.NewGuid(),
                Description = dto.Description,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Info = dto.Info,
                isFreelanceAvailable = dto.isFreelanceAvailable,
                Location = dto.Location,
            };
            author.BirthDate = DateOnlyUtils.GenerateDate(dto.BirthDate.Day, dto.BirthDate.Month, dto.BirthDate.Year);
            author.ImageName = dto.Image.UploadFile(_env.WebRootPath, FilePaths.AuthorPath);
            author.ImageURL = $"{_url}/{author.ImageName}";
            var result = await _context.AddAsync(author);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }

        public async Task<List<AuthorGetDto>> GetAllAsync()
        {
            var query = _context.Authors.AsNoTracking();
            return await query.Select(author => author.ToGetDto()).ToListAsync();
        }

        public async Task<AuthorGetDto> GetAsync()
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            return author.ToGetDto();
        }

        public async Task<bool> ChangeImageAsync(ChangeImageDto dto)
        {
            var author = await _context.Authors.FirstOrDefaultAsync();
            if (author == null) throw new NotFoundException("Author");
            var path = Path.Combine(_env.WebRootPath, FilePaths.AuthorPath, author.ImageName);
            if (File.Exists(path)) File.Delete(path);

            author.ImageName = dto.NewImage.UploadFile(_env.WebRootPath, FilePaths.AuthorPath);
            author.ImageURL = Path.Combine(_url, author.ImageName);

            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}
