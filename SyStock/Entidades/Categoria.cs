using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class Categoria
    {
        readonly int _idCategoria;
        string _nombre;
        bool _estado;
        int _idUsuario;

        public Categoria(string pNombre, bool pEstado, int pIdUsuario)
        {
            _nombre = pNombre;
            _estado = pEstado;
            _idUsuario = pIdUsuario;
        }

        public Categoria(int pIdCategoria, string pNombre, bool pEstado, int pIdUsuario)
        {
            _idCategoria = pIdCategoria;
            _nombre = pNombre;
            _estado = pEstado;
            _idUsuario = pIdUsuario;
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
    }
}
