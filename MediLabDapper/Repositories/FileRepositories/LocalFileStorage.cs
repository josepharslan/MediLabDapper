
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.StaticFiles;

namespace MediLabDapper.Repositories.FileRepositories
{
    public class LocalFileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly FileExtensionContentTypeProvider _types = new();

        public LocalFileStorage(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public Task DeleteAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SavePhotoAsync(Guid doctorId, IFormFile file)
        {
            Validate(file);

            var root = _configuration["Upload:Root"] ?? "wwwroot/uploads";
            var relativeFolder = Path.Combine("uploads", "doctors", doctorId.ToString());
            var physicalFolder = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine("uploads", "doctors", doctorId.ToString()));

            Directory.CreateDirectory(physicalFolder);

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var storedName = $"{Guid.NewGuid():N}{ext}";
            var fullPath = Path.Combine(physicalFolder, storedName);

            await using (var fs = File.Create(fullPath))
            {
                await file.CopyToAsync(fs);
            }

            return Path.Combine("/", relativeFolder, storedName).Replace("\\", "/");
        }

        private void Validate(IFormFile file)
        {
            if (file is null || file.Length == 0)
                throw new ArgumentException("Dosya boş olamaz.");

            var allowed = _configuration.GetSection("Upload:AllowedExtensions").Get<string[]>() ?? new[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowed.Contains(ext))
                throw new ArgumentException($"Sadece şu uzantılara izin verilmektedir: {string.Join(", ", allowed)}");
        }
    }
}
