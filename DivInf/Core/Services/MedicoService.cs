using DivInf.Core.DTOs;
using DivInf.Core.Interfaces;
using DivInf.Core.Mapper;
using DivInf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task AddMedico(MedicoDTO medicoDTO)
        {
            try
            {
                var mapper = new EntityMapper();
                var medico = mapper.FromMedicoDtoToMedicoModel(medicoDTO);
                await _medicoRepository.Insert(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteMedico(int id)
        {
            try
            {
                await _medicoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<MedicoDTO>> GetMedicos(string searchString)
        {
            try
            {
                var mapper = new EntityMapper();
                var medicos = await _medicoRepository.GetAll(searchString);

                var listMedicos = medicos.Select(x => mapper.FromMedicoModelToMedicoDto(x)).ToList();

                return listMedicos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<MedicoDTO>> GetMedicos()
        {
            try
            {
                var mapper = new EntityMapper();
                var medicos = await _medicoRepository.GetAll();

                var listMedicos = medicos.Select(x => mapper.FromMedicoModelToMedicoDto(x)).ToList();

                return listMedicos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateMedico(MedicoUpdateDTO medicoDTO, int id)
        {
            try
            {
                var medicoToUpdate = await _medicoRepository.GetMedicoById(id);

                if (medicoToUpdate != null)
                {
                    var mapper = new EntityMapper();
                    var medico = mapper.FromMedicoUpdateDtoToMedicoModel(medicoDTO, medicoToUpdate);
                    await _medicoRepository.Update(medico);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
