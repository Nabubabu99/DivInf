using DivInf.Core.DTOs;
using DivInf.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            try
            {
                ViewData["NombreSortParm"] = sortOrder == "nombre" ? "nombreDesc" : "nombre";
                ViewData["HistoriaClinicaSortParm"] = sortOrder == "historiaClinica" ? "historiaClinicaDesc" : "historiaClinica";
                ViewData["CurrentFilter"] = searchString;

                var listPacientes = await _pacienteService.GetPacientes();

                if (!String.IsNullOrEmpty(searchString))
                {
                    listPacientes = await _pacienteService.GetPacientes(searchString);
                }

                switch (sortOrder)
                {
                    case "nombre":
                        listPacientes = listPacientes.OrderBy(x => x.Nombre);
                        break;
                    case "nombreDesc":
                        listPacientes = listPacientes.OrderByDescending(x => x.Nombre);
                        break;
                    case "historiaClinicaDesc":
                        listPacientes = listPacientes.OrderByDescending(x => x.HistoriaClinica);
                        break;
                    default:
                        listPacientes = listPacientes.OrderBy(x => x.HistoriaClinica);
                        break;
                }

                return View(listPacientes);
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
        public async Task<IActionResult> Create([FromForm] PacienteDTO paciente)
        {
            try
            {
                var pacienteExist = await _pacienteService.GetPacienteByHistoriaClinica(paciente.HistoriaClinica);

                if (pacienteExist != null)
                {
                    TempData["mensaje"] = "Ya existe un paciente con esa historia clinica.";
                }
                else if (ModelState.IsValid)
                {
                    await _pacienteService.AddPaciente(paciente);

                    TempData["mensaje"] = "El paciente se ha creado correctamente.";
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
        public async Task<IActionResult> Edit(int? historiaClinica)
        {
            try
            {
                if (historiaClinica == null || historiaClinica == 0)
                {
                    return NotFound();
                }

                var paciente = await _pacienteService.GetPacienteByHistoriaClinica(historiaClinica);

                if (paciente == null)
                {
                    return NotFound();
                }

                return View(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromForm] PacienteUpdateDTO paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _pacienteService.UpdatePaciente(paciente);

                    TempData["mensaje"] = "El paciente se ha actualizado correctamente.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("delete/{historiaClinica}")]
        public async Task<IActionResult> Delete(int? historiaClinica)
        {
            try
            {
                if (historiaClinica == null || historiaClinica == 0)
                {
                    return NotFound();
                }

                var paciente = await _pacienteService.GetPacienteByHistoriaClinica(historiaClinica);

                if (paciente == null)
                {
                    return NotFound();
                }

                return View(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("delete/{historiaClinica}")]
        public async Task<IActionResult> Delete(int historiaClinica)
        {
            try
            {
                var medico = await _pacienteService.GetPacienteByHistoriaClinica(historiaClinica);

                if (medico == null)
                {
                    return NotFound();
                }

                await _pacienteService.DeletePaciente(historiaClinica);

                TempData["mensaje"] = "El paciente se ha eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
