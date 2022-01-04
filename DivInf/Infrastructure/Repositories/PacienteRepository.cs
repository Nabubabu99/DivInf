using DivInf.Core.Interfaces;
using DivInf.Core.Models;
using DivInf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Repositories
{
    public class PacienteRepository : Repository<PacientesModel>, IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PacientesModel> GetPacienteById(int? id)
        {
            var entity = await _context.Pacientes.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<PacientesModel>> GetAll(string searchString)
        {
            var pacientes = await _context.Pacientes.Where(x => x.Nombre.Contains(searchString)).ToListAsync();
            return pacientes;
        }
    }
}
