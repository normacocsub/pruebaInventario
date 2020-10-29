using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Detalle
    {
        [Key]
        public string Numero { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public string CodigoInsumo { get; set; }
        [ NotMapped ]
        public Insumo Insumo { get; set; }
        
    }
}