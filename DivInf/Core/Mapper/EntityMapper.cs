using DivInf.Core.DTOs;
using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Mapper
{
    public class EntityMapper
    {
        public MedicoModel FromMedicoDtoToMedicoModel(MedicoDTO medicoDTO)
        {
            var medico = new MedicoModel
            {
                Matricula = medicoDTO.Matricula,
                Nombre = medicoDTO.Nombre,
                Especialidad = medicoDTO.Especialidad
            };

            return medico;
        }

        public MedicoDTO FromMedicoModelToMedicoDto(MedicoModel medicoModel)
        {
            var medico = new MedicoDTO
            {
                Matricula = medicoModel.Matricula,
                Nombre = medicoModel.Nombre,
                Especialidad = medicoModel.Especialidad
            };

            return medico;
        }

        public MedicoModel FromMedicoUpdateDtoToMedicoModel(MedicoUpdateDTO medicoDTO, MedicoModel medicoModel)
        {
            medicoModel.Nombre = medicoDTO.Nombre;
            medicoModel.Especialidad = medicoDTO.Especialidad;

            return medicoModel;
        }
    }
}
