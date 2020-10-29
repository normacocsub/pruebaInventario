using Entity;
namespace InventarioWeb.Models
{
    public class AsignaturaInputModel
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class AsignaturaViewModel: AsignaturaInputModel
    {
        public AsignaturaViewModel()
        {

        }

        public AsignaturaViewModel(Asignatura asignatura)
        {
            Codigo = asignatura.Codigo;
            Nombre = asignatura.Nombre;
        }
    }
}