using DivInf.Core.DTOs;
using DivInf.Core.Interfaces;
using DivInf.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task AddPaciente(PacienteDTO pacienteDTO)
        {
            try
            {
                var mapper = new EntityMapper();
                var paciente = mapper.FromPacienteDtoToPacienteModel(pacienteDTO);
                await _pacienteRepository.Insert(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletePaciente(int id)
        {
            try
            {
                await _pacienteRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PacienteDTO>> GetPacientes(string searchString)
        {
            try
            {
                var mapper = new EntityMapper();
                var pacientes = await _pacienteRepository.GetAll(searchString);

                var listPacientes = pacientes.Select(x => mapper.FromPacientesModelToPacienteDto(x)).ToList();

                return listPacientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PacienteDTO>> GetPacientes()
        {
            try
            {
                var mapper = new EntityMapper();
                var pacientes = await _pacienteRepository.GetAll();

                var listPacientes = pacientes.Select(x => mapper.FromPacientesModelToPacienteDto(x)).ToList();

                return listPacientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePaciente(PacienteUpdateDTO pacienteDTO)
        {
            try
            {
                var pacienteToUpdate = await _pacienteRepository.GetPacienteById(pacienteDTO.HistoriaClinica);

                if (pacienteToUpdate != null)
                {
                    var mapper = new EntityMapper();
                    var paciente = mapper.FromPacienteUpdateDtoToPacientesModel(pacienteDTO, pacienteToUpdate);
                    await _pacienteRepository.Update(paciente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteDTO> GetPacienteByHistoriaClinica(int? historiaClinica)
        {
            try
            {
                var mapper = new EntityMapper();
                var paciente = await _pacienteRepository.GetPacienteById(historiaClinica);

                if(paciente != null)
                {
                    var pacienteUpdate = mapper.FromPacientesModelToPacienteDto(paciente);

                    return pacienteUpdate;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
