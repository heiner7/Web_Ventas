using Application;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VentasBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        IApplication<Persona> _persona;

        public PersonasController(IApplication<Persona> persona)
        {
            _persona = persona;
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(Persona), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Personas/ObtenerPersonas")]
        public IActionResult ObtenerPersonas()
        {
            return _persona.GetById(0,"Personas").Count > 0 ? Ok(_persona.GetById(0, "Personas")) : NoContent();
        }
    }
}
