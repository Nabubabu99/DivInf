using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IConsultaRepository : IRepository<ConsultaModel>
    {
        Task<PacienteModel> GetConsultaById(int? id);
        Task<IEnumerable<PacienteModel>> GetAll(string searchString);
    }
}
