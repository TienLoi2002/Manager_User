using System.Collections.Generic;
using System.Threading.Tasks;
using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IFormService
    {
        Task<List<FormDTO>> GetAllFormsAsync();
        Task<FormDTO> AddFormAsync(FormDTO form);
        Task<FormDTO> UpdateFormAsync(FormDTO form);
        Task<bool> DeleteFormAsync(int formId);
    }
}
