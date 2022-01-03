using DivInf.Core.Models;
using DivInf.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Repositories
{
    public class ConsultaRepository : Repository<ConsultaModel>
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ConsultaModel> GetConsultaById(int? id)
        {
            var entity = await _context.Consulta.FindAsync(id);
            return entity;
        }
    }
}
