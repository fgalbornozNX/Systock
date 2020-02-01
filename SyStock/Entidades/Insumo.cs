using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class Insumo
    {
        readonly int _idInsumo;
        string _nombre;
        string _descripcion;
        int _cantidad;
        int _cantidadMinima;
        bool _estado;
        int _idCategoria;

        public Insumo(string pNombre, string pDescripcion, int pCantidad, int pCantidadMinima, bool pEstado, int pIdCategoria)
        {
            _nombre = pNombre;
            _descripcion = pDescripcion;
            _cantidad = pCantidad;
            _cantidadMinima = pCantidadMinima;
            _estado = pEstado;
            _idCategoria = pIdCategoria;
        }

        public Insumo(int pIdInsumo, string pNombre, string pDescripcion, int pCantidad, int pCantidadMinima, bool pEstado, int pIdCategoria)
        {
            _idInsumo = pIdInsumo;
            _nombre = pNombre;
            _descripcion = pDescripcion;
            _cantidad = pCantidad;
            _cantidadMinima = pCantidadMinima;
            _estado = pEstado;
            _idCategoria = pIdCategoria;
        }

        public int IdInsumo
        {
            get { return _idInsumo; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int CantidadMinima
        {
            get { return _cantidadMinima; }
            set { _cantidadMinima = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
    }
}
