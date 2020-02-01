using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class Grupo
    {
        readonly int _idGrupo;
        string _nombre;
        bool _estado;
        int _idArea;
        int _idUsuario;

        public Grupo(string pNombre, bool pEstado, int pIdArea, int pIdUsuario)
        {
            _nombre = pNombre;
            _estado = pEstado;
            _idArea = pIdArea;
            _idUsuario = pIdUsuario;
        }

        public Grupo(int pIdGrupo, string pNombre, bool pEstado, int pIdArea, int pIdUsuario)
        {
            _idGrupo = pIdGrupo;
            _nombre = pNombre;
            _estado = pEstado;
            _idArea = pIdArea;
            _idUsuario = pIdUsuario;
        }

        public int IdGrupo
        {
            get { return _idGrupo; }
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

        public int IdArea
        {
            get { return _idArea; }
            set { _idArea = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
    }
}
