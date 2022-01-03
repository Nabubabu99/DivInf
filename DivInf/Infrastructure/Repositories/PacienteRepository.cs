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
    public class PacienteRepository : Repository<PacienteModel>, IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PacienteModel> GetPacienteById(int? id)
        {
            var entity = await _context.Paciente.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<PacienteModel>> GetAll(string searchString)
        {
            var usuarios = await _context.Paciente.Where(x => x.Nombre.Contains(searchString)).ToListAsync();
            return usuarios;
        }
    }
}
