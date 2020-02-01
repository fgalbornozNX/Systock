using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.Entidades
{
    public class PersonaAutorizada
    {
        int _idPersona;
        string _nombre;
        string _contraseña;
        DateTime _fechaAlta;
        DateTime _fechaBaja;
        int _idGrupo;

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public  PersonaAutorizada(string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdGrupo)
        {
            _nombre = pNombre;
            _contraseña = pContraseña;
            _fechaAlta = pFechaAlta;
            _fechaBaja = pFechaBaja;
            _idGrupo = pIdGrupo;
        }

        public PersonaAutorizada(int pIdPersona, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdGrupo)
        {
            _idPersona = pIdPersona;
            _nombre = pNombre;
            _contraseña = pContraseña;
            _fechaAlta = pFechaAlta;
            _fechaBaja = pFechaBaja;
            _idGrupo = pIdGrupo;
        }

        /// <summary>
        /// ID del Usuario
        /// </summary>
        public int IdPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Contraseña del Usuario.
        /// </summary>
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        /// <summary>
        /// Fecha de alta del Usuario
        /// </summary>
        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        /// <summary>
        /// Fecha de baja del Usuario
        /// </summary>
        public DateTime FechaBaja
        {
            get { return _fechaBaja; }
            set { _fechaBaja = value; }
        }

        public int IdGrupo
        {
            get { return _idGrupo; }
            set { _idGrupo = value; }
        }
    }
}
