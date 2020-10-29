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

    public class SolicitudController : ControllerBase​
    {
        // POST: api/Persona​

        private readonly SolicitudService _service;
        public SolicitudController(InventarioContext context)
        {
            _service = new SolicitudService(context);
        }

        //api/Solicitud
        [HttpPost]
        public ActionResult<SolicitudViewModel> Post(SolicitudInputModel solicitudInput)
        {
            Solicitud solicitud = MapearSolicitud(solicitudInput);
            var response = _service.GuardarSolicitud(solicitud);

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Solicitud);
        }

        //api/Solicitud
        [HttpGet]
        public ActionResult<SolicitudViewModel> Get()
        {
            var response = _service.ConsultarSolicitudes();

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Solicitudes.Select(s => new SolicitudViewModel(s)));
        }



        private Solicitud MapearSolicitud(SolicitudInputModel solicitudInput)
        {
            var solicitud = new Solicitud
            {
                Identificacion = solicitudInput.Identificacion,
                Nombre = solicitudInput.Nombre,
                Edad = solicitudInput.Edad,
                Sexo = solicitudInput.Sexo,
                Detalles = solicitudInput.Detalles,
                Asignatura = solicitudInput.Asignatura
            };
            return solicitud;
        }
    }
}