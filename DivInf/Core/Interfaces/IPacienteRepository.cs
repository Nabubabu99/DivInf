﻿using DivInf.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IPacienteRepository : IRepository<PacientesModel>
    {
        Task<PacientesModel> GetPacienteById(int? id);
        Task<IEnumerable<PacientesModel>> GetAll(string searchString);
    }
}
