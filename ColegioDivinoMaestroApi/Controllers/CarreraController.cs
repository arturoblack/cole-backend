using ColegioDivinoMaestroApi.MyDb.Contexts;
using ColegioDivinoMaestroApi.MyDb.Tablas;
using Microsoft.AspNetCore.Mvc;

namespace ColegioDivinoMaestroApi.Controllers
{

    [Controller]
    [Route("/carerras")]
    public class CarreraController : ControllerBase
    {
        private readonly MyDbContext db;
        public CarreraController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Carrera> carreras = db.Carreras.ToList();
            return Ok(carreras);
        }
        [HttpGet]
        [Route("{carreraId}")]
        public ActionResult ObtenerPorId([FromRoute] int carreraId)
        {
            Carrera? carrera = db.Carreras
                .Where(a => a.id == carreraId)
                .FirstOrDefault();
            if (carrera == null)
            {
                return NotFound(new { message = "Carrera no encotrado." });
            }
            return Ok(carrera);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Carrera carrera)
        {
            db.Carreras.Add(carrera);
            db.SaveChanges();
            return Ok(carrera);
        }

        [HttpPut]
        [Route("{carreraId}")]
        public ActionResult Actualizar(
            [FromRoute] int carreraId,
            [FromBody] Carrera carreraDatos)
        {
            Carrera? carrera = db.Carreras
                .Where(a => a.id == carreraId)
                .FirstOrDefault();
            if (carrera == null)
            {
                return NotFound(new { message = "Carrera no encotrado." });
            }
            carrera.nombre = carreraDatos.nombre;
            carrera.codigo = carreraDatos.codigo;
            carrera.especialidad = carreraDatos.especialidad;
            carrera.descripcion = carreraDatos.descripcion;


            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{carreraId}")]
        public ActionResult Eliminar(
            [FromRoute] int carreraId)
        {
            Carrera? carrera = db.Carreras
                .Where(a => a.id == carreraId)
                .FirstOrDefault();
            if (carrera == null)
            {
                return NotFound(new { message = "Carrera no encotrado." });
            }
            db.Carreras.Remove(carrera);
            db.SaveChanges();
            return NoContent();
        }

    }
}
