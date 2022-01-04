using System.ComponentModel.DataAnnotations;

namespace DivInf.Core.DTOs
{
    public class PacienteDTO
    {
        [Required(ErrorMessage = "La historia clinica es requerida.")]
        public int HistoriaClinica { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [MaxLength(55, ErrorMessage = "El Nombre debe tener como máximo 55 caracteres.")]
        public string Nombre { get; set; }
    }
}
