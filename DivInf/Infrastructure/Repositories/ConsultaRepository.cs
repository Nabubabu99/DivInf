using DivInf.Core.Interfaces;
using DivInf.Core.Models;
using DivInf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Repositories
{
    public class ConsultaRepository : Repository<ConsultasModel>, IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ConsultasModel> GetConsultaById(int? id)
        {
            var entity = await _context.Consultas.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<ConsultasModel>> GetAll(string searchString)
        {
            var consultas = await _context.Consultas.Where(x => x.Medico.Nombre.Contains(searchString)).ToListAsync();
            return consultas;
        }
    }
}
