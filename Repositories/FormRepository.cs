using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<FormDTO> AddFormAsync(FormDTO form)
        {
            var formEntity = _mapper.Map<Form>(form);
            _context.Forms.Add(formEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<FormDTO>(formEntity);
        }

        public async Task<bool> DeleteFormAsync(int formId)
        {
            var form = await _context.Forms.FindAsync(formId);
            if (form == null)
            {
                return false;
            }

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FormDTO>> GetAllFormsAsync()
        {
            var forms = await _context.Forms.ToListAsync();
            return _mapper.Map<List<FormDTO>>(forms);
        }

        public async Task<FormDTO> UpdateFormAsync(FormDTO form)
        {
            var formToUpdate = await _context.Forms.FindAsync(form.FormId);
            if (formToUpdate == null)
            {
                return null;
            }

            _mapper.Map(form, formToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<FormDTO>(formToUpdate);
        }
    }
}
