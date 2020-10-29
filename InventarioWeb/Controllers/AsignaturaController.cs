namespace InventarioWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Logica;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using Entity;
    using Datos;
    using InventarioWeb.Models;

    [Route("api/[controller]")]
    [ApiController]

    public class AsignaturaController : ControllerBase​
    {
        

        private readonly AsignaturaService _service;
        public AsignaturaController(InventarioContext context)
        {
            _service = new AsignaturaService(context);
        }
        // POST: api/Asignatura​
        [HttpPost]
        public ActionResult<AsignaturaViewModel> Post(AsignaturaInputModel asignaturaInput)
        {
            Asignatura asignatura = MapearAsignatura(asignaturaInput);
            var response = _service.GuardarAsignatura(asignatura);

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Asignatura);
        }

        //api/Asignatura
        [HttpGet]
        public ActionResult<AsignaturaViewModel> Get()
        {
            var response = _service.ConsultarAsignaturas();

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Asignaturas.Select(a => new AsignaturaViewModel(a)));
        }



        private Asignatura MapearAsignatura(AsignaturaInputModel asignaturaInput)
        {
            var asignatura = new Asignatura
            {
                Codigo = asignaturaInput.Codigo,
                Nombre = asignaturaInput.Nombre
            };
            return asignatura;
        }
    }
}