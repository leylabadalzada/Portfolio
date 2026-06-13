using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.ViewModels.Author
{
    public record ChangeImageVM
    {
        public IFormFile NewImage { get; set; }
    }
}
