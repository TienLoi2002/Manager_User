using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IFormService
    {
        List<FormDTO> GetAllForms();
        FormDTO AddForm(FormDTO form);
        FormDTO UpdateForm(FormDTO form);
        bool DeleteForm(int formId);
    }
}
