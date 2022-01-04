using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.DTOs
{
    public class ConsultaUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La historia clinica es requerida.")]
        public int HistoriaClinica { get; set; }

        [Required(ErrorMessage = "La matricula del profesional es requerida.")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "El tipo de consulta es requerido.")]
        [MaxLength(20, ErrorMessage = "El tipo debe tener como máximo 20 caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El costo es requerido.")]
        public float Costo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [MaxLength(20, ErrorMessage = "La descripción debe tener como máximo 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El costo es requerido.")]
        public float CostoMaterial { get; set; }
    }
}
