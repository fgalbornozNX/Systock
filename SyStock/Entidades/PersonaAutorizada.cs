using System;

namespace SyStock.Entidades
{
    public class PersonaAutorizada
    {
        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public  PersonaAutorizada(string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdGrupo)
        {
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = pFechaBaja;
            IdGrupo = pIdGrupo;
        }

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public PersonaAutorizada(int pIdPersona, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdGrupo)
        {
            IdPersona = pIdPersona;
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = pFechaBaja;
            IdGrupo = pIdGrupo;
        }

        /// <summary>
        /// Representa un usuario Administrador de la aplicación
        /// </summary>
        public PersonaAutorizada(int pIdPersona, string pNombre, string pContraseña, DateTime pFechaAlta, DateTime pFechaBaja, int pIdGrupo, int pIdCreadoPor)
        {
            IdPersona = pIdPersona;
            Nombre = pNombre;
            Contraseña = pContraseña;
            FechaAlta = pFechaAlta;
            FechaBaja = pFechaBaja;
            IdGrupo = pIdGrupo;
            IdCreador = pIdCreadoPor;
        }

        /// <summary>
        /// ID del Usuario
        /// </summary>
        public int IdPersona { get; set; }

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
        /// Referencia al grupo al que pertenece la persona
        /// </summary>
        public int IdGrupo { get; set; }

        /// <summary>
        /// Almacena el ID del usuario que agregó a esta persona
        /// </summary>
        public int IdCreador { get; set; }
    }
}
