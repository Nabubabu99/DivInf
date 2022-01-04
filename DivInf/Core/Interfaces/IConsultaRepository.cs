using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IConsultaRepository : IRepository<ConsultasModel>
    {
        Task<ConsultasModel> GetConsultaById(int? id);
        Task<IEnumerable<ConsultasModel>> GetAll(string searchString);
    }
}
