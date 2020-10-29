

namespace InventarioWeb.Controllers
{
    using System.Linq;
    using Datos;
    using Entity;
    using InventarioWeb.Models;
    using Logica;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {

        private readonly InsumoService _service;
        public InsumoController(InventarioContext context)
        {
            _service = new InsumoService(context);
        }
        // POST: api/Insumo​
        [HttpPost]
        public ActionResult<InsumoViewModel> Post(InsumoInputModel InsumoInput)
        {
            Insumo insumo = MapearInsumo(InsumoInput);
            var response = _service.GuardarInsumo(insumo);

            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Insumo);
        }

        //api/Insumo
        [HttpGet]
        public ActionResult<InsumoViewModel> Get()
        {
            var response = _service.ConsultarInsumos();

            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Insumos.Select(a => new InsumoViewModel(a)));
        }



        private Insumo MapearInsumo(InsumoInputModel InsumoInput)
        {
            var Insumo = new Insumo
            {
                Codigo = InsumoInput.Codigo,
                Nombre = InsumoInput.Nombre,
                Descripcion = InsumoInput.Descripcion,
                Cantidad = InsumoInput.Cantidad
            };
            return Insumo;
        }
    }
}