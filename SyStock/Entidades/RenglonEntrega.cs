namespace SyStock.Entidades
{
    public class RenglonEntrega
    {
        /// <summary>
        /// Representa un renglón de una entrega
        /// </summary>
        public RenglonEntrega(int pIdEntrega, int pIdInsumo, int pCantidad)
        {
            IdEntrega = pIdEntrega;
            IdInsumo = pIdInsumo;
            Cantidad = pCantidad;
        }

        /// <summary>
        /// Representa un renglón de una entrega
        /// </summary>
        public RenglonEntrega(int pIdRenglon, int pIdEntrega, int pIdInsumo, int pCantidad)
        {
            IdRenglon = pIdRenglon;
            IdEntrega = pIdEntrega;
            IdInsumo = pIdInsumo;
            Cantidad = pCantidad;
        }

        public int IdRenglon { get; }

        public int IdEntrega { get; set; }

        public int IdInsumo { get; set; }

        public int Cantidad { get; set; }
    }
}
