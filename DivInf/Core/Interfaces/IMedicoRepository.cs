using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IMedicoRepository : IRepository<MedicoModel>
    {
        Task<MedicoModel> GetMedicoById(int? id);
        Task<IEnumerable<MedicoModel>> GetAll(string searchString);
    }
}
