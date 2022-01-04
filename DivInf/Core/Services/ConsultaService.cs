using DivInf.Core.DTOs;
using DivInf.Core.Interfaces;
using DivInf.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public ConsultaService(IConsultaRepository consultaRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _consultaRepository = consultaRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<bool> AddConsulta(ConsultaDTO consultaDTO)
        {
            try
            {
                var consultaExist = await _consultaRepository.GetConsultaById(consultaDTO.Id);
                var medicoExist = await _medicoRepository.GetMedicoById(consultaDTO.Matricula);
                var pacienteExist = await _pacienteRepository.GetPacienteById(consultaDTO.HistoriaClinica);

                if (consultaExist == null && medicoExist != null && pacienteExist != null)
                {
                    var mapper = new EntityMapper();
                    var consulta = mapper.FromConsultaDtoToConsultasModel(consultaDTO);
                    await _consultaRepository.Insert(consulta);

                    return true;
                }

                return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteConsulta(int id)
        {
            try
            {
                await _consultaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ConsultaDTO>> GetConsultas(string searchString)
        {
            try
            {
                var mapper = new EntityMapper();
                var consultas = await _consultaRepository.GetAll(searchString);

                var listConsultas = consultas.Select(x => mapper.FromConsultasModelToConsultaDto(x)).ToList();

                return listConsultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ConsultaDTO>> GetConsultas()
        {
            try
            {
                var mapper = new EntityMapper();
                var consultas = await _consultaRepository.GetAll();

                var listConsultas = consultas.Select(x => mapper.FromConsultasModelToConsultaDto(x)).ToList();

                return listConsultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateConsulta(ConsultaUpdateDTO consultaDTO)
        {
            try
            {
                var consultaToUpdate = await _consultaRepository.GetConsultaById(consultaDTO.Id);
                var medicoExist = await _medicoRepository.GetMedicoById(consultaDTO.Matricula);
                var pacienteExist = await _pacienteRepository.GetPacienteById(consultaDTO.HistoriaClinica);

                if (consultaToUpdate != null && medicoExist != null && pacienteExist != null)
                {
                    var mapper = new EntityMapper();
                    var consulta = mapper.FromConsultaUpdateDtoToConsultasModel(consultaDTO, consultaToUpdate);
                    await _consultaRepository.Update(consulta);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ConsultaDTO> GetConsultaById(int? id)
        {
            try
            {
                var mapper = new EntityMapper();
                var consulta = await _consultaRepository.GetConsultaById(id);

                if(consulta != null)
                {
                    var consultaUpdate = mapper.FromConsultasModelToConsultaDto(consulta);

                    return consultaUpdate;
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
