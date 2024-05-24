using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Manager_User_API.DTO;
using Microsoft.Extensions.Options;
using static NuGet.Packaging.PackagingConstants;

namespace Manager_User_API.Service
{

    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<string> UploadImageCloudinaryAsync(IFormFile file)
        {
            if (file.Length == 0)
                return null;

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "Manager_User_Form_Image"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.Url.ToString();
        }
    }

}
