using Manager_User_API.DTO;

namespace Manager_User_API.IRepositories
{
    public interface IFormRepository
    {
        List<FormDTO> GetAllForms();
        FormDTO AddForm(FormDTO form);
        FormDTO UpdateForm(FormDTO form);
        bool DeleteForm(int formId);
    }
}
