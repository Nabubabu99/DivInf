using DivInf.Core.DTOs;
using DivInf.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : Controller
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            try
            {
                ViewData["EspecialidadSortParm"] = String.IsNullOrEmpty(sortOrder) ? "especialidadDesc" : "especialidad";
                ViewData["NombreSortParm"] = sortOrder == "nombre" ? "nombreDesc" : "nombre";
                ViewData["MatriculaSortParm"] = sortOrder == "matricula" ? "matriculaDesc" : "matricula";
                ViewData["CurrentFilter"] = searchString;

                var listMedicos = await _medicoService.GetMedicos();

                if (!String.IsNullOrEmpty(searchString))
                {
                    listMedicos = await _medicoService.GetMedicos(searchString);
                }

                switch (sortOrder)
                {
                    case "especialidadDesc":
                        listMedicos = listMedicos.OrderByDescending(x => x.Especialidad);
                        break;
                    case "nombre":
                        listMedicos = listMedicos.OrderBy(x => x.Nombre);
                        break;
                    case "nombreDesc":
                        listMedicos = listMedicos.OrderByDescending(x => x.Nombre);
                        break;
                    case "especialidad":
                        listMedicos = listMedicos.OrderBy(x => x.Especialidad);
                        break;
                    case "matriculaDesc":
                        listMedicos = listMedicos.OrderByDescending(x => x.Matricula);
                        break;
                    default:
                        listMedicos = listMedicos.OrderBy(x => x.Matricula);
                        break;
                }

                return View(listMedicos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] MedicoDTO medico)
        {
            try
            {
                var medicoExist = await _medicoService.GetMedicoByMatricula(medico.Matricula);

                if (medicoExist != null)
                {
                    TempData["mensaje"] = "Ya existe un medico con esa matricula.";
                }
                else if (ModelState.IsValid)
                {
                    await _medicoService.AddMedico(medico);

                    TempData["mensaje"] = "El medico se ha creado correctamente.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? matricula)
        {
            try
            {
                if (matricula == null || matricula == 0)
                {
                    return NotFound();
                }

                var medico = await _medicoService.GetMedicoByMatricula(matricula);

                if (medico == null)
                {
                    return NotFound();
                }

                return View(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromForm] MedicoUpdateDTO medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _medicoService.UpdateMedico(medico);

                    TempData["mensaje"] = "El medico se ha actualizado correctamente.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("delete/{matricula}")]
        public async Task<IActionResult> Delete(int? matricula)
        {
            try
            {
                if (matricula == null || matricula == 0)
                {
                    return NotFound();
                }

                var medico = await _medicoService.GetMedicoByMatricula(matricula);

                if (medico == null)
                {
                    return NotFound();
                }

                return View(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("delete/{matricula}")]
        public async Task<IActionResult> Delete(int matricula)
        {
            try
            {
                var medico = await _medicoService.GetMedicoByMatricula(matricula);

                if (medico == null)
                {
                    return NotFound();
                }

                await _medicoService.DeleteMedico(matricula);

                TempData["mensaje"] = "El medico se ha eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
