using DivInf.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivInf.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<ConsultaModel> Consulta { get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }
    }
}
