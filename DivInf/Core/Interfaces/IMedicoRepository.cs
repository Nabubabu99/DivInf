using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IMedicoRepository : IRepository<MedicosModel>
    {
        Task<MedicosModel> GetMedicoById(int? id);
        Task<IEnumerable<MedicosModel>> GetAll(string searchString);
    }
}
