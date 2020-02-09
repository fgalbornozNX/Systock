using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorPersona
    {
        /// <summary>
        /// Agrega una Persona Autorizada a la base de datos
        /// </summary>
        /// <param name="pPersona">Persona a agregar</param>
        /// <returns></returns>
        public static int Agregar(PersonaAutorizada pPersona)
        {
            if ((pPersona == null) || (pPersona.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pPersona));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                int idPersona = factory.PersonaAutorizadaDAO.VerificarNombre(pPersona.Nombre);
                factory.FinalizarConexion();
                
                if (idPersona == -1)
                {
                    factory.IniciarConexion();
                    factory.PersonaAutorizadaDAO.Agregar(pPersona);
                    factory.FinalizarConexion();
                }
                return idPersona;

            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Verifica la existencia de una Persona por nombre
        /// </summary>
        /// <param name="pNombre">Nombre de la Persona para realizar la búsqueda</param>
        /// <returns>ID de la persona verificada. -1 en caso de error</returns>
        public static int VerificarNombre(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                int idPersona = factory.PersonaAutorizadaDAO.VerificarNombre(pNombre);
                factory.FinalizarConexion();

                return idPersona;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Verifica las credenciales de una Persona
        /// </summary>
        /// <param name="pNombre">Nombre de la Persona</param>
        /// <param name="pContraseña">Contraseña</param>
        /// <returns>Persona verificada. Null en caso de error</returns>
        public static int Verificar(string pNombre, string pContraseña)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                int idPersona = factory.PersonaAutorizadaDAO.Verificar(pNombre,pContraseña);
                factory.FinalizarConexion();

                return idPersona;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista todas las Personas Autorizadas para el retiro
        /// </summary>
        /// <returns>Lista de todas las Personas Autorizadas</returns>
        public static List<PersonaAutorizada> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<PersonaAutorizada> listaPersona = factory.PersonaAutorizadaDAO.Listar();
                factory.FinalizarConexion();
                
                return listaPersona;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista todas las Personas Autorizadas que perteneces a un determinado Grupo
        /// </summary>
        /// <param name="idGrupo">ID del grupo</param>
        /// <returns>Lista de todas las Personas en un determinado Grupo</returns>
        public static List<PersonaAutorizada> Listar(int idGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<PersonaAutorizada> listaPersonas = factory.PersonaAutorizadaDAO.Listar(idGrupo);
                factory.FinalizarConexion();

                return listaPersonas;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene una Persona Autorizada
        /// </summary>
        /// <param name="pIdPersona">ID de la persona para realizar la búsqueda</param>
        /// <returns>Persona Autorizada. Null en caso de error</returns>
        public static PersonaAutorizada Obtener(int pIdPersona)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                PersonaAutorizada persona = factory.PersonaAutorizadaDAO.Obtener(pIdPersona);
                factory.FinalizarConexion();

                return persona;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene una Persona Autorizada
        /// </summary>
        /// <param name="pNombre">Nombre de la Persona para realizar la búsqueda</param>
        /// <returns>Persona Autorizada. Null en caso de error</returns>
        public static PersonaAutorizada Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                PersonaAutorizada persona = factory.PersonaAutorizadaDAO.Obtener(pNombre);
                factory.FinalizarConexion();

                return persona;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Modifica los datos de una Persona
        /// </summary>
        /// <param name="pPersona">Persona con los datos actualizados. Busca por ID</param>
        /// <returns>True en caso de éxito. False caso contrario</returns>
        public static void Modificar(PersonaAutorizada pPersona)
        {
            if ((pPersona == null) || (pPersona.IdPersona < 1))
                throw new ArgumentNullException(nameof(pPersona));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                factory.PersonaAutorizadaDAO.ModificarNombre(pPersona.IdPersona, pPersona.Nombre);
                factory.PersonaAutorizadaDAO.ModificarContrasena(pPersona.IdPersona, pPersona.Contraseña);
                factory.PersonaAutorizadaDAO.ModificarGrupo(pPersona.IdPersona, pPersona.IdGrupo);
                factory.PersonaAutorizadaDAO.ModificarFechaAlta(pPersona.IdPersona, pPersona.FechaAlta);
                factory.PersonaAutorizadaDAO.ModificarFechaBaja(pPersona.IdPersona, pPersona.FechaBaja);
                factory.FinalizarConexion();
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }
    }
}
