using DivInf.Core.Models;
using DivInf.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Repositories
{
    public class ConsultaRepository : Repository<ConsultasModel>
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
    }
}
