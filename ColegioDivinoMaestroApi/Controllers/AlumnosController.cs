using ColegioDivinoMaestroApi.MyDb.Contexts;
using ColegioDivinoMaestroApi.MyDb.Tablas;
using Microsoft.AspNetCore.Mvc;

namespace ColegioDivinoMaestroApi.Controllers
{
    [Controller]
    [Route("/alumnos")]
    public class AlumnosController: ControllerBase
    {
        private readonly MyDbContext db;
        public AlumnosController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Alumno> alumnos = db.Alumnos.ToList();
            return Ok(alumnos);
        }
        [HttpGet]
        [Route("{alumnoId}")]
        public ActionResult ObtenerPorId([FromRoute] int alumnoId)
        {
            Alumno? alumno = db.Alumnos
                .Where(a => a.id == alumnoId)
                .FirstOrDefault();
            if (alumno == null)
            {
                return NotFound(new { message = "alumno no encotrado."});
            }
            return Ok(alumno);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Alumno alumno)
        {
            db.Alumnos.Add(alumno);
            db.SaveChanges();
            return Ok(alumno);
        }

        [HttpPut]
        [Route("{alumnoId}")]
        public ActionResult Actualizar(
            [FromRoute] int alumnoId, 
            [FromBody] Alumno alumnoDatos)
        {
            Alumno? alumno = db.Alumnos
                .Where(a => a.id == alumnoId)
                .FirstOrDefault();
            if (alumno == null)
            {
                return NotFound(new { message = "alumno no encotrado." });
            }
            alumno.nombres = alumnoDatos.nombres;
            alumno.apellidos = alumnoDatos.apellidos;
            alumno.tipoDocumento = alumnoDatos.tipoDocumento;
            alumno.numeroDocumento = alumnoDatos.numeroDocumento;
            alumno.genero = alumnoDatos.genero;
            alumno.codigo = alumnoDatos.codigo;
            alumno.fechaNacimiento = alumnoDatos.fechaNacimiento;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{alumnoId}")]
        public ActionResult Eliminar(
            [FromRoute] int alumnoId)
        {
            Alumno? alumno = db.Alumnos
                .Where(a => a.id == alumnoId)
                .FirstOrDefault();
            if (alumno == null)
            {
                return NotFound(new { message = "alumno no encotrado." });
            }
            db.Alumnos.Remove(alumno);
            db.SaveChanges();
            return NoContent();
        }

    }
}
