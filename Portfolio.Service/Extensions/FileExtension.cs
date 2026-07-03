using Microsoft.AspNetCore.Http;

namespace Portfolio.Service.Extensions
{
    public static class FileExtension
    {
        public static string UploadFile(this IFormFile file, string root, string path)
        {
            var filename = $"{Guid.NewGuid().ToString()}{file.FileName}";
            var fullPath = Path.Combine(root, path, filename);
            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
            return filename;
        }

        public static void DeleteFile(this string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
