using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DivInf.Core.Models
{
    public class PacientesModel : PersonasModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int HistoriaClinica { get; set; }
    }
}
