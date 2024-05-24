using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("Image cannot be null or empty");
            }

            if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
            {
                throw new InvalidOperationException("WebRootPath is not set.");
            }

            var imagePath = "/uploads/forms/" + Guid.NewGuid().ToString() + "_" + image.FileName;
            var imagePathOnServer = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
            var directory = Path.GetDirectoryName(imagePathOnServer);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var stream = new FileStream(imagePathOnServer, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return imagePath;
        }
    }


}
