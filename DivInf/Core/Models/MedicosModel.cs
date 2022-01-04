using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DivInf.Core.Models
{
    public class MedicosModel : PersonasModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "La especialidad es requerida.")]
        [MaxLength(55, ErrorMessage = "La especialidad debe tener como máximo 55 caracteres.")]
        public string Especialidad { get; set; }
    }
}
