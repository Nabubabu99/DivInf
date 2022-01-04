using DivInf.Core.DTOs;
using DivInf.Core.Models;

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

        public PacientesModel FromPacienteDtoToPacienteModel(PacienteDTO pacienteDTO)
        {
            var paciente = new PacientesModel
            {
                HistoriaClinica = pacienteDTO.HistoriaClinica,
                Nombre = pacienteDTO.Nombre
            };

            return paciente;
        }

        public PacienteDTO FromPacientesModelToPacienteDto(PacientesModel pacienteModel)
        {
            var paciente = new PacienteDTO
            {
                HistoriaClinica = pacienteModel.HistoriaClinica,
                Nombre = pacienteModel.Nombre
            };

            return paciente;
        }

        public PacientesModel FromPacienteUpdateDtoToPacientesModel(PacienteUpdateDTO pacienteDTO, PacientesModel pacienteModel)
        {
            pacienteModel.Nombre = pacienteDTO.Nombre;

            return pacienteModel;
        }

        public ConsultasModel FromConsultaDtoToConsultasModel(ConsultaDTO consultaDTO)
        {
            var consulta = new ConsultasModel
            {
                Fecha = consultaDTO.Fecha,
                Matricula = consultaDTO.Matricula,
                Tipo = consultaDTO.Tipo,
                Costo = consultaDTO.Costo,
                Descripcion = consultaDTO.Descripcion,
                CostoMaterial = consultaDTO.CostoMaterial,
                HistoriaClinica = consultaDTO.HistoriaClinica
            };

            return consulta;
        }

        public ConsultaDTO FromConsultasModelToConsultaDto(ConsultasModel consultaModel)
        {
            var consulta = new ConsultaDTO
            {
                Id = consultaModel.Id,
                Fecha = consultaModel.Fecha,
                Matricula = consultaModel.Matricula,
                Tipo = consultaModel.Tipo,
                Costo = consultaModel.Costo,
                Descripcion = consultaModel.Descripcion,
                CostoMaterial = consultaModel.CostoMaterial,
                HistoriaClinica = consultaModel.HistoriaClinica
            };

            return consulta;
        }

        public ConsultasModel FromConsultaUpdateDtoToConsultasModel(ConsultaUpdateDTO consultaDTO, ConsultasModel consultaModel)
        {
            consultaModel.Fecha = consultaDTO.Fecha;
            consultaModel.Matricula = consultaDTO.Matricula;
            consultaModel.Tipo = consultaDTO.Tipo;
            consultaModel.Costo = consultaDTO.Costo;
            consultaModel.Descripcion = consultaDTO.Descripcion;
            consultaModel.CostoMaterial = consultaDTO.CostoMaterial;
            consultaModel.HistoriaClinica = consultaDTO.HistoriaClinica;

            return consultaModel;
        }
    }
}
