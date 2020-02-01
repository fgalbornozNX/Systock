using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class RenglonEntrega
    {
        readonly int _idRenglon;
        int _idEntrega;
        int _idInsumo;
        int _cantidad;

        public RenglonEntrega(int pIdEntrega, int pIdInsumo, int pCantidad)
        {
            _idEntrega = pIdEntrega;
            _idInsumo = pIdInsumo;
            _cantidad = pCantidad;
        }

        public RenglonEntrega(int pIdRenglon, int pIdEntrega, int pIdInsumo, int pCantidad)
        {
            _idRenglon = pIdRenglon;
            _idEntrega = pIdEntrega;
            _idInsumo = pIdInsumo;
            _cantidad = pCantidad;
        }

        public int IdRenglon
        {
            get { return _idRenglon; }
        }

        public int IdEntrega
        {
            get { return _idEntrega; }
            set { _idEntrega = value; }
        }

        public int IdInsumo
        {
            get { return _idInsumo; }
            set { _idInsumo = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}
