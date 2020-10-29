using System;
using Entity;
using Datos;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class SolicitudService
    {
        private readonly InventarioContext _context;

        public SolicitudService(InventarioContext context)
        {
            _context = context;
        }

        public GuardarInventarioResponse GuardarSolicitud(Solicitud solicitud)
        {
            try
            {
                int total = _context.Solicitudes.ToList().Count;
                solicitud.Numero = (total + 1).ToString();
                solicitud.CodigoAsignatura = solicitud.Asignatura.Codigo;
                foreach (var item in solicitud.Detalles)
                {
                    item.Numero += solicitud.Numero;
                }
                _context.Solicitudes.Add(solicitud);
                _context.SaveChanges();
                return new GuardarInventarioResponse(solicitud);
            }
            catch(Exception e)
            {
                return new GuardarInventarioResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public ConsultarInventarioResponse ConsultarSolicitudes()
        {
            try
            {
                List<Solicitud> Solicitudes = _context.Solicitudes.Include(s => s.Detalles).ToList();
                foreach (var item in Solicitudes)
                {
                    item.Asignatura = _context.Asignaturas.Find(item.CodigoAsignatura);
                }

                return new ConsultarInventarioResponse(Solicitudes);
            }
            catch(Exception e)
            {
                return new ConsultarInventarioResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public class ConsultarInventarioResponse
        {
            public ConsultarInventarioResponse(List<Solicitud> solicitudes)
            {
                Error = false;
                Solicitudes = solicitudes;
            }

            public ConsultarInventarioResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Solicitud> Solicitudes { get; set; }
        }
        public class GuardarInventarioResponse
        {
            public GuardarInventarioResponse(Solicitud solicitud)
            {
                Solicitud = solicitud;
                Error = false;
            }

            public GuardarInventarioResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Solicitud Solicitud { get; set; }
        }
    }
}
