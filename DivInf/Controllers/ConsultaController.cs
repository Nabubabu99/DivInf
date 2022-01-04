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
    public class ConsultaController : Controller
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            try
            {
                ViewData["CostoSortParm"] = sortOrder == "costo" ? "costoDesc" : "costo";
                ViewData["fechaSortParm"] = sortOrder == "fecha" ? "fechaDesc" : "fecha";
                ViewData["CurrentFilter"] = searchString;

                var listConsultas = await _consultaService.GetConsultas();

                if (!String.IsNullOrEmpty(searchString))
                {
                    listConsultas = await _consultaService.GetConsultas(searchString);
                }

                switch (sortOrder)
                {
                    case "costo":
                        listConsultas = listConsultas.OrderBy(x => x.Costo);
                        break;
                    case "costoDesc":
                        listConsultas = listConsultas.OrderByDescending(x => x.Costo);
                        break;
                    case "fechaDesc":
                        listConsultas = listConsultas.OrderByDescending(x => x.Fecha);
                        break;
                    default:
                        listConsultas = listConsultas.OrderBy(x => x.Fecha);
                        break;
                }

                return View(listConsultas);
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
        public async Task<IActionResult> Create([FromForm] ConsultaDTO consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addConsulta = await _consultaService.AddConsulta(consulta);
                    if (addConsulta)
                    {
                        TempData["mensaje"] = "La consulta se ha creado correctamente.";
                        return RedirectToAction("Index");
                    }
                }
                TempData["mensaje"] = "La consulta no se ha creado correctamente, matricula o historia clinica incorrecta.";
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var consulta = await _consultaService.GetConsultaById(id);

                if (consulta == null)
                {
                    return NotFound();
                }

                return View(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditConsulta([FromForm] ConsultaUpdateDTO consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateConsulta = await _consultaService.UpdateConsulta(consulta);

                    if (updateConsulta)
                    {
                        TempData["mensaje"] = "La consulta se ha actualizado correctamente.";
                        return RedirectToAction("Index");
                    }
                }
                TempData["mensaje"] = "La consulta no se pudo actualizar correctamente, matricula o historia clinica incorrecta.";
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var paciente = await _consultaService.GetConsultaById(id);

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

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var medico = await _consultaService.GetConsultaById(id);

                if (medico == null)
                {
                    return NotFound();
                }

                await _consultaService.DeleteConsulta(id);

                TempData["mensaje"] = "La consulta se ha eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
