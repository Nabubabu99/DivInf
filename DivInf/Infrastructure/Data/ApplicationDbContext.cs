using DivInf.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DivInf.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MedicosModel> Medicos { get; set; }
        public DbSet<ConsultasModel> Consultas { get; set; }
        public DbSet<PacientesModel> Pacientes { get; set; }
    }
}
