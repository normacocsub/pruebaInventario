using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Solicitud
    {
        [Key]
        public string Numero { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        [ NotMapped ]
        public Asignatura Asignatura { get; set; }

        public List<Detalle> Detalles { get; set; }
        
        public string CodigoAsignatura { get; set; }
    }
}
