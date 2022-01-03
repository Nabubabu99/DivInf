using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.DTOs
{
    public class ConsultaDTO
    {
        public DateTime Fecha { get; set; }
        public int HistoriaClinica { get; set; }
        public string Especialidad { get; set; }
        public int Matricula { get; set; }
        public string Tipo { get; set; }
        public float Costo { get; set; }
        public string Descripcion { get; set; }
        public float CostoMaterial { get; set; }
    }
}
