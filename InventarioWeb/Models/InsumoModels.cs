using Entity;

namespace InventarioWeb.Models
{
    public class InsumoInputModel
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }

    public class InsumoViewModel : InsumoInputModel 
    {
        public InsumoViewModel(){ }

        public InsumoViewModel(Insumo insumo)
        {
            Codigo = insumo.Codigo;
            Nombre = insumo.Nombre;
            Descripcion = insumo.Descripcion;
            Cantidad = insumo.Cantidad;
        }
    }
}