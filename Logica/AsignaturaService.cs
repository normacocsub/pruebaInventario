using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
namespace Logica
{
    public class AsignaturaService
    {
        private readonly InventarioContext _context;

        public AsignaturaService(InventarioContext context)
        {
            _context = context;
        }

        public GuardarAsignaturaResponse GuardarAsignatura(Asignatura asignatura)
        {
            try
            {
                var findasignatura = _context.Asignaturas.Find(asignatura.Codigo);
                if(findasignatura == null)
                {
                    _context.Asignaturas.Add(asignatura);
                    _context.SaveChanges();
                    return new GuardarAsignaturaResponse(asignatura);
                }
                else
                {
                    return new GuardarAsignaturaResponse("Error: Ya se encuentra registrada la asignatura ");
                }
            }
            catch(Exception e)
            {
                return new GuardarAsignaturaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public ConsultarAsignaturaResponse ConsultarAsignaturas()
        {
            try
            {
                return new ConsultarAsignaturaResponse(_context.Asignaturas.ToList());
            }
            catch(Exception e)
            {
                return new ConsultarAsignaturaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public class ConsultarAsignaturaResponse
        {
            public ConsultarAsignaturaResponse(List<Asignatura> asignaturas)
            {
                Error = false;
                Asignaturas = asignaturas;
            }

            public ConsultarAsignaturaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Asignatura> Asignaturas { get; set; }
        }
        public class GuardarAsignaturaResponse
        {
            public GuardarAsignaturaResponse(Asignatura asignatura)
            {
                Asignatura = asignatura;
                Error = false;
            }

            public GuardarAsignaturaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Asignatura Asignatura { get; set; }
        }
    }
}