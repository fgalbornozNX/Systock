namespace SyStock.Entidades
{
    public class Insumo
    {
        public Insumo(string pNombre, string pDescripcion, int pCantidad, int pCantidadMinima, bool pEstado, int pIdCategoria)
        {
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Cantidad = pCantidad;
            CantidadMinima = pCantidadMinima;
            Estado = pEstado;
            IdCategoria = pIdCategoria;
        }

        public Insumo(int pIdInsumo, string pNombre, string pDescripcion, int pCantidad, int pCantidadMinima, bool pEstado, int pIdCategoria)
        {
            IdInsumo = pIdInsumo;
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Cantidad = pCantidad;
            CantidadMinima = pCantidadMinima;
            Estado = pEstado;
            IdCategoria = pIdCategoria;
        }

        public int IdInsumo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public int CantidadMinima { get; set; }

        public bool Estado { get; set; }

        public int IdCategoria { get; set; }
    }
}
