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
    public class MedicoRepository : Repository<MedicosModel>, IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MedicosModel> GetMedicoById(int? id)
        {
            var entity = await _context.Medicos.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<MedicosModel>> GetAll(string searchString)
        {
            var medicos = await _context.Medicos.Where(x => x.Nombre.Contains(searchString) || x.Especialidad.Contains(searchString)).ToListAsync();
            return medicos;
        }
    }
}
