using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IPacienteRepository : IRepository<PacienteModel>
    {
        Task<PacienteModel> GetPacienteById(int? id);
        Task<IEnumerable<PacienteModel>> GetAll(string searchString);
    }
}
