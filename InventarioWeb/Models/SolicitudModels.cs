namespace InventarioWeb.Models
{
    using System.Collections.Generic;
    using Entity;

    public class SolicitudInputModel​
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public Asignatura Asignatura { get; set; }
        public List<Detalle> Detalles { get; set; }
    }

    public class SolicitudViewModel : SolicitudInputModel​
    {
        public SolicitudViewModel()
        {
        }
        public SolicitudViewModel(Solicitud solicitud)
        {
            Identificacion = solicitud.Identificacion;
            Nombre = solicitud.Nombre;
            Edad = solicitud.Edad;
            Sexo = solicitud.Sexo;
            Detalles = solicitud.Detalles;
            Numero = solicitud.Numero;
            Asignatura = solicitud.Asignatura;
        }
        public string Numero { get; set; }
    }
}