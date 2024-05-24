using System.Collections.Generic;
using System.Threading.Tasks;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class FormService : IFormService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageUploadService _imageUploadService;
        private readonly CloudinaryService _cloudinaryService;

        public FormService(IUnitOfWork unitOfWork, IImageUploadService imageUploadService, CloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _imageUploadService = imageUploadService;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<FormDTO> AddFormAsync(FormDTO form, IFormFile image)
        {
            /*if (image != null)
            {
                var imageUrl = await _imageUploadService.UploadImageAsync(image);
                form.FilePath = imageUrl;
            }*/
            if (image != null)
            {
                var imageUrlCloudinary = await _cloudinaryService.UploadImageCloudinaryAsync(image);
                form.FilePath = imageUrlCloudinary;
            }
            form.DateSubmitted = DateTime.Now;
            var addedForm = await _unitOfWork.FormRepository.AddFormAsync(form);
            await _unitOfWork.SaveChangesAsync();
            return addedForm;
        }

        public async Task<bool> DeleteFormAsync(int formId)
        {
            var result = await _unitOfWork.FormRepository.DeleteFormAsync(formId);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<FormDTO>> GetAllFormsAsync()
        {
            return await _unitOfWork.FormRepository.GetAllFormsAsync();
        }

        public async Task<FormDTO> UpdateFormAsync(FormDTO form)
        {
            var updatedForm = await _unitOfWork.FormRepository.UpdateFormAsync(form);
            await _unitOfWork.SaveChangesAsync();
            return updatedForm;
        }
    }
}
