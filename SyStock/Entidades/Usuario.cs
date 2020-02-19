using System;

namespace SyStock.Entidades
{
    public class Usuario
    {
        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public Usuario(string pNombre, string pContraseña, DateTime pFechaAlta)
        {
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = DateTime.MinValue;
            IdUsuarioAdmin = 1;
        }

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public Usuario(int pIdUsuario, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja)
        {
            IdUsuario = pIdUsuario;
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = pFechaBaja;
        }
       
        /// <summary>
        /// Representa un usuario de la aplicación.
        /// </summary>
        public Usuario(int pIdUsuario, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdAdmin)
        {
            IdUsuario = pIdUsuario;
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = pFechaBaja;
            IdUsuarioAdmin = pIdAdmin;
        }

        /// <summary>
        /// ID del Usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña del Usuario.
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Fecha de alta del Usuario
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Fecha de baja del Usuario
        /// </summary>
        public DateTime FechaBaja { get; set; }

        /// <summary>
        /// ID del Usuario Admin
        /// </summary>
        public int IdUsuarioAdmin { get; set; }
    }
}