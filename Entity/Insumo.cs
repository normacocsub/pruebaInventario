using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Insumo
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}