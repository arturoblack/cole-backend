using ColegioDivinoMaestroApi.MyDb.Tablas;
using Microsoft.EntityFrameworkCore;

namespace ColegioDivinoMaestroApi.MyDb.Contexts
{
    public class MyDbContext: DbContext
    {
        //DbContextOptions < EF_DataContext > options): base(options)
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }

    }
}
