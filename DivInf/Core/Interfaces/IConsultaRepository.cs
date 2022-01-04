using DivInf.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IConsultaRepository : IRepository<ConsultasModel>
    {
        Task<ConsultasModel> GetConsultaById(int? id);
        Task<IEnumerable<ConsultasModel>> GetAll(string searchString);
    }
}
