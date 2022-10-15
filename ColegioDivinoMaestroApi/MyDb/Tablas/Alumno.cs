using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColegioDivinoMaestroApi.MyDb.Tablas
{
    [Table("Alumnos")]
    public class Alumno
    {
        [Key]
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string codigo { get; set; }
    }
}
