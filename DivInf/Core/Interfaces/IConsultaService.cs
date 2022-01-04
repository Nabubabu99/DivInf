using DivInf.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDTO>> GetConsultas();
        Task<IEnumerable<ConsultaDTO>> GetConsultas(string searchString);
        Task<bool> AddConsulta(ConsultaDTO consultas);
        Task<bool> UpdateConsulta(ConsultaUpdateDTO consultas);
        Task DeleteConsulta(int id);
        Task<ConsultaDTO> GetConsultaById(int? id);
    }
}
