﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Core.Models
{
    public class PacienteModel : PersonaModel
    {
        [Key]
        public int HistoriaClinica { get; set; }
    }
}
