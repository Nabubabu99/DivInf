using System.ComponentModel.DataAnnotations;

namespace DivInf.Core.Models
{
    public class PersonasModel
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [MaxLength(55, ErrorMessage = "El Nombre debe tener como máximo 55 caracteres.")]
        public string Nombre { get; set; }
    }
}
