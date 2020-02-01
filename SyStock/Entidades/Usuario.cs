using System;

namespace SyStock.Entidades
{
    public class Usuario
    {
        int _idUsuario;
        string _nombre;
        string _contraseña;
        DateTime _fechaAlta;
        DateTime _fechaBaja;
        int _idUsuarioAdmin;

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public Usuario(string pNombre, string pContraseña, DateTime pFechaAlta)
        {
            _nombre = pNombre;
            _contraseña = pContraseña;
            _fechaAlta = pFechaAlta;
            _fechaBaja = DateTime.MinValue;
            _idUsuarioAdmin = 1;
        }

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public Usuario(int pIdUsuario, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja)
        {
            _idUsuario = pIdUsuario;
            _nombre = pNombre;
            _contraseña = pContraseña;
            _fechaAlta = pFechaAlta;
            _fechaBaja = pFechaBaja;
        }
       
        /// <summary>
        /// Representa un usuario de la aplicación.
        /// </summary>
        public Usuario(int pIdUsuario, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdAdmin)
        {
            _idUsuario = pIdUsuario;
            _nombre = pNombre;
            _contraseña = pContraseña;
            _fechaAlta = pFechaAlta;
            _fechaBaja = pFechaBaja;
            _idUsuarioAdmin = pIdAdmin;
        }

        /// <summary>
        /// ID del Usuario
        /// </summary>
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
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

        /// <summary>
        /// ID del Usuario Admin
        /// </summary>
        public int IdUsuarioAdmin
        {
            get { return _idUsuarioAdmin; }
            set { _idUsuarioAdmin = value; }
        }
    }
}