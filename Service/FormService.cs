using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Service
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public FormDTO AddForm(FormDTO form)
        {
            return _formRepository.AddForm(form);
        }

        public bool DeleteForm(int formId)
        {
            return _formRepository.DeleteForm(formId);
        }

        public List<FormDTO> GetAllForms()
        {
            return _formRepository.GetAllForms();
        }

        public FormDTO UpdateForm(FormDTO form)
        {
            return _formRepository.UpdateForm(form);
        }
    }
}
