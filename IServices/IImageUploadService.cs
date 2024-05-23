namespace Manager_User_API.IServices
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
