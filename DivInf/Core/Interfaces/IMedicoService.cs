using DivInf.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDTO>> GetMedicos();
        Task<IEnumerable<MedicoDTO>> GetMedicos(string searchString);
        Task AddMedico(MedicoDTO usuario);
        Task UpdateMedico(MedicoUpdateDTO medico, int id);
        Task DeleteMedico(int id);
    }
}
