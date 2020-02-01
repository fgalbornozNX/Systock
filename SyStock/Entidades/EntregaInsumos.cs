using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class EntregaInsumos
    {
        readonly int _idEntrega;
        int _idUsuario;
        int _idPersona;
        DateTime _fecha;

        public EntregaInsumos(int pIdUsuario, int pIdPersona, DateTime pFecha)
        {
            _idUsuario = pIdUsuario;
            _idPersona = pIdPersona;
            _fecha = pFecha;
        }

        public EntregaInsumos (int pIdEntrega, int pIdUsuario, int pIdPersona, DateTime pFecha)
        {
            _idEntrega = pIdEntrega;
            _idUsuario = pIdUsuario;
            _idPersona = pIdPersona;
            _fecha = pFecha;
        }

        public int IdEntrega
        {
            get { return _idEntrega; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
    }
}
