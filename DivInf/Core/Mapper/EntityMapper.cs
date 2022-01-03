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
        public MedicosModel FromMedicoDtoToMedicoModel(MedicoDTO medicoDTO)
        {
            var medico = new MedicosModel
            {
                Matricula = medicoDTO.Matricula,
                Nombre = medicoDTO.Nombre,
                Especialidad = medicoDTO.Especialidad
            };

            return medico;
        }

        public MedicoDTO FromMedicoModelToMedicoDto(MedicosModel medicoModel)
        {
            var medico = new MedicoDTO
            {
                Matricula = medicoModel.Matricula,
                Nombre = medicoModel.Nombre,
                Especialidad = medicoModel.Especialidad
            };

            return medico;
        }

        public MedicosModel FromMedicoUpdateDtoToMedicoModel(MedicoUpdateDTO medicoDTO, MedicosModel medicoModel)
        {
            medicoModel.Nombre = medicoDTO.Nombre;
            medicoModel.Especialidad = medicoDTO.Especialidad;

            return medicoModel;
        }
    }
}
