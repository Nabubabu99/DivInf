using DivInf.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDTO>> GetPacientes();
        Task<IEnumerable<PacienteDTO>> GetPacientes(string searchString);
        Task AddPaciente(PacienteDTO paciente);
        Task UpdatePaciente(PacienteUpdateDTO paciente);
        Task DeletePaciente(int id);
        Task<PacienteDTO> GetPacienteByHistoriaClinica(int? historiaClinica);
    }
}
