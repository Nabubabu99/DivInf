using DivInf.Core.Interfaces;
using DivInf.Core.Models;
using DivInf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Repositories
{
    public class MedicoRepository : Repository<MedicoModel>, IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MedicoModel> GetMedicoById(int? id)
        {
            var entity = await _context.Medico.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<MedicoModel>> GetAll(string searchString)
        {
            var usuarios = await _context.Medico.Where(x => x.Nombre.Contains(searchString) || x.Especialidad.Contains(searchString)).ToListAsync();
            return usuarios;
        }
    }
}
