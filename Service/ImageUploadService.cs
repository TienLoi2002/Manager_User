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

            var extension = Path.GetExtension(image.FileName).ToLower();
            if (extension != ".jpg" && extension != ".jpeg")
            {
                throw new ArgumentException("Only JPG/JPEG images are supported");
            }

            // Đường dẫn lưu trữ hình ảnh trên máy chủ
            var imagePath = "/uploads/forms/" + Guid.NewGuid().ToString() + "_" + image.FileName;

            // Tạo đường dẫn lưu trữ trên máy chủ
            var imagePathOnServer = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

            // Lưu hình ảnh vào đường dẫn được chỉ định trên máy chủ
            using (var stream = new FileStream(imagePathOnServer, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return imagePath;
        }
    }

}
