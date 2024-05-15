using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;

namespace Manager_User_API.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FormRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public FormDTO AddForm(FormDTO form)
        {
            var formEntity = _mapper.Map<Form>(form);
            _context.Forms.Add(formEntity);
            _context.SaveChanges();
            return _mapper.Map<FormDTO>(formEntity);
        }

        public bool DeleteForm(int formId)
        {
            var form = _context.Forms.Find(formId);
            if (form == null)
            {
                return false;
            }

            _context.Forms.Remove(form);
            _context.SaveChanges();
            return true;
        }

        public List<FormDTO> GetAllForms()
        {
            var forms = _context.Forms.ToList();
            return _mapper.Map<List<FormDTO>>(forms);
        }

        public FormDTO UpdateForm(FormDTO form)
        {
            var formToUpdate = _context.Forms.Find(form.FormId);
            if (formToUpdate == null)
            {
                return null;
            }

            _mapper.Map(form, formToUpdate);
            _context.SaveChanges();
            return _mapper.Map<FormDTO>(formToUpdate);
        }
    }
}
