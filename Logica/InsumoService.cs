using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class InsumoService
    {
        private readonly InventarioContext _context;

        public InsumoService(InventarioContext context)
        {
            _context = context;
        }

        public GuardarInsumoResponse GuardarInsumo(Insumo insumo)
        {
            try
            {
                var findInsumo = _context.Insumos.Find(insumo.Codigo);
                if(findInsumo == null)
                {
                    _context.Insumos.Add(insumo);
                    _context.SaveChanges();
                    return new GuardarInsumoResponse(insumo);
                }
                else
                {
                    return new GuardarInsumoResponse("Error: Ya se encuentra registrado el Insumo ");
                }
            }
            catch(Exception e)
            {
                return new GuardarInsumoResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public ConsultarInsumoResponse ConsultarInsumos()
        {
            try
            {
                return new ConsultarInsumoResponse(_context.Insumos.ToList());
            }
            catch(Exception e)
            {
                return new ConsultarInsumoResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public class ConsultarInsumoResponse
        {
            public ConsultarInsumoResponse(List<Insumo> insumos)
            {
                Error = false;
                Insumos = insumos;
            }

            public ConsultarInsumoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Insumo> Insumos { get; set; }
        }
        public class GuardarInsumoResponse
        {
            public GuardarInsumoResponse(Insumo insumo)
            {
                Insumo = insumo;
                Error = false;
            }

            public GuardarInsumoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Insumo Insumo { get; set; }
        }
    }
}