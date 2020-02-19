using System;

namespace SyStock.Entidades
{
    public class EntregaInsumos
    {
        public EntregaInsumos(int pIdUsuario, int pIdPersona, DateTime pFecha)
        {
            IdUsuario = pIdUsuario;
            IdPersona = pIdPersona;
            Fecha = pFecha;
        }

        public EntregaInsumos (int pIdEntrega, int pIdUsuario, int pIdPersona, DateTime pFecha)
        {
            IdEntrega = pIdEntrega;
            IdUsuario = pIdUsuario;
            IdPersona = pIdPersona;
            Fecha = pFecha;
        }

        public int IdEntrega { get; private set; }

        public int IdUsuario { get; set; }

        public int IdPersona { get; set; }

        public DateTime Fecha { get; set; }
    }
}
