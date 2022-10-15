using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColegioDivinoMaestroApi.MyDb.Tablas
{
    [Table("Carreras")]
    public class Carrera
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string especialidad { get; set; }
        public string descripcion { get; set; }

    }
}
