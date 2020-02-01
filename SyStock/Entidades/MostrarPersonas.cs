using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class MostrarPersonas
    {
        int _idPersona;
        string _nombre;
        string _grupo;
        string _area;

        public MostrarPersonas(string pNombre, string pGrupo, string pArea)
        {
            _nombre = pNombre;
            _grupo = pGrupo;
            _area = pArea;
        }

        public MostrarPersonas(int pIdPersona, string pNombre, string pGrupo, string pArea)
        {
            _idPersona = pIdPersona;
            _nombre = pNombre;
            _grupo = pGrupo;
            _area = pArea;
        }

        public int IdPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        /// <summary>
        /// Nombre de la Persona.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Grupo de la Persona.
        /// </summary>
        public string Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        /// <summary>
        /// Area de la Persona.
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
    }
}
