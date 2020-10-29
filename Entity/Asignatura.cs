using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Asignatura
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}