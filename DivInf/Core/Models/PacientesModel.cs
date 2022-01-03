using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Models
{
    public class PacientesModel : PersonasModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int HistoriaClinica { get; set; }
    }
}
