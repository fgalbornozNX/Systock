using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorUsuario
    {
        /// <summary>
        /// Mètodo para agregar un nuevo Usuario
        /// </summary>
        /// <param name="pUsuario">Usuario a agregar</param>
        /// <returns>Devuelve -1 si lo agregó o el Id del Usuario si existe ese nombre</returns>
        public static int Agregar(Usuario pUsuario)
        {
            if ((pUsuario == null) || (pUsuario.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pUsuario));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                int idUsuario = factory.UsuarioDAO.VerificarNombre(pUsuario.Nombre);
                factory.FinalizarConexion();

                if (idUsuario == -1)
                {
                    factory.IniciarConexion();
                    factory.UsuarioDAO.Agregar(pUsuario);
                    factory.FinalizarConexion();
                }

                return idUsuario;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Verifica los datos del usuario
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <param name="pContraseña">Contraeña del Usuario</param>
        /// <returns>Usuario validado. Null si no son válidos</returns>
        public static Usuario Verificar(string pNombre, string pContraseña)
        {
            DAOFactory factory = DAOFactory.Instancia();
            Usuario usuario = null;

            try
            {
                factory.IniciarConexion();
                int idUser = factory.UsuarioDAO.Verificar(pNombre, pContraseña);  //Trae el id del Usuario o -1 si no lo encontró
                factory.FinalizarConexion();

                if (idUser != -1)
                {
                    factory.IniciarConexion();
                    usuario = factory.UsuarioDAO.Obtener(idUser);
                    factory.FinalizarConexion();
                }

                return usuario;    
            }
            catch (DAOException e)
            {
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para listar los Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios. Null si no existen usuarios</returns>
        public static List<Usuario> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Usuario> _listaUsuarios = new List<Usuario>();

            try
            {
                factory.IniciarConexion();
                _listaUsuarios = factory.UsuarioDAO.Listar();
                factory.FinalizarConexion();

                return _listaUsuarios;
            }
            catch (DAOException e)
            {
                _listaUsuarios.Clear();
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene un determinado Usuario por ID
        /// </summary>
        /// <param name="pIdUsuario">Id del Usuario a buscar</param>
        /// <returns>Usuario encontrado. Null si no lo encontró</returns>
        public static Usuario Obtener(int pIdUsuario)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Usuario usuario = factory.UsuarioDAO.Obtener(pIdUsuario);
                factory.FinalizarConexion();

                return usuario;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene un determinado Usuario por Nombre
        /// </summary>
        /// <param name="pNombreUsuario">Nombre del Usuario</param>
        /// <returns>Usuario encontrado. Null si no lo encontró</returns>
        public static Usuario Obtener(string pNombreUsuario)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Usuario usuario = factory.UsuarioDAO.Obtener(pNombreUsuario);
                factory.FinalizarConexion();

                return usuario;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para modificar los datos del Usuario
        /// </summary>
        /// <param name="pUsuario"> Usuario a modificar</param>
        public static void Modificar(Usuario pUsuario)
        {
            if ((pUsuario == null) || (pUsuario.IdUsuario < 1))
                throw new ArgumentNullException(nameof(pUsuario));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                factory.UsuarioDAO.ModificarNombre(pUsuario.IdUsuario, pUsuario.Nombre);
                factory.UsuarioDAO.ModificarContrasena(pUsuario.Nombre, pUsuario.Contraseña);
                factory.UsuarioDAO.ModificarFechaAlta(pUsuario.Nombre, pUsuario.FechaAlta);
                factory.UsuarioDAO.ModificarFechaBaja(pUsuario.Nombre, pUsuario.FechaBaja);
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