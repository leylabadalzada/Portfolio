using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Data.Contexts;
using Portfolio.Service.DTOs.Author;
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
                //ImageName = dto.Image.UploadFile()
                BirthDate = DateOnlyUtils.GenerateDate(dto.BirthDate.Day, dto.BirthDate.Month, dto.BirthDate.Year),
            };

            var result = await _context.AddAsync(author);
            if (result.State != EntityState.Added) return false;
            var saveCount = await _context.SaveChangesAsync();
            return saveCount > 0;
        }
    }
}
