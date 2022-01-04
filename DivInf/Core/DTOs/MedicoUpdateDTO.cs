using System.ComponentModel.DataAnnotations;

namespace DivInf.Core.DTOs
{
    public class MedicoUpdateDTO
    {
        [Required(ErrorMessage = "La matricula es requerida.")]
        public int Matricula { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [MaxLength(55, ErrorMessage = "El Nombre debe tener como máximo 55 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especialidad es requerida.")]
        [MaxLength(55, ErrorMessage = "La especialidad debe tener como máximo 55 caracteres.")]
        public string Especialidad { get; set; }
    }
}
