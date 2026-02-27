using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.DTOs.Author
{
    public record ChangeImageDto
    {
        public IFormFile NewImage { get; set; }
    }
}
