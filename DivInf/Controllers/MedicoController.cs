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
                ViewData["NombreSortParm"] = sortOrder == "matricula" ? "matriculaDesc" : "matricula";
                ViewData["CurrentFilter"] = searchString;

                var listUsuarios = await _medicoService.GetMedicos();

                if (!String.IsNullOrEmpty(searchString))
                {
                    listUsuarios = await _medicoService.GetMedicos(searchString);
                }

                switch (sortOrder)
                {
                    case "especialidadDesc":
                        listUsuarios = listUsuarios.OrderByDescending(x => x.Especialidad);
                        break;
                    case "nombre":
                        listUsuarios = listUsuarios.OrderBy(x => x.Nombre);
                        break;
                    case "nombreDesc":
                        listUsuarios = listUsuarios.OrderByDescending(x => x.Nombre);
                        break;
                    case "especialidad":
                        listUsuarios = listUsuarios.OrderBy(x => x.Especialidad);
                        break;
                    case "matriculaDesc":
                        listUsuarios = listUsuarios.OrderByDescending(x => x.Matricula);
                        break;
                    default:
                        listUsuarios = listUsuarios.OrderBy(x => x.Matricula);
                        break;
                }

                return View(listUsuarios);
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

                if (medicoExist != false)
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
    }
}
