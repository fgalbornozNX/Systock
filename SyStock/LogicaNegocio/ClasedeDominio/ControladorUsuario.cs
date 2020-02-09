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
                }
                return idUsuario;

            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
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
            Usuario user = null;
            int idUser = -1;

            try
            {
                factory.IniciarConexion();
                idUser = factory.UsuarioDAO.Verificar(pNombre, pContraseña);  //Trae el id del Usuario o -1 si no lo encontró

                if (idUser != -1)
                {
                    user = factory.UsuarioDAO.Obtener(idUser);
                    factory.FinalizarConexion();
                    return user;
                }
                else
                {
                    factory.FinalizarConexion();
                    return null;
                }
                    
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
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                _listaUsuarios = _usuarioDAO.Listar();
                return _listaUsuarios;
            }
            catch (DAOException e)
            {
                _listaUsuarios.Clear();
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
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
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                Usuario _usuario = new Usuario(0, "", "", DateTime.Today, DateTime.Today, 0);
                _usuario = _usuarioDAO.Obtener(pIdUsuario);
                return _usuario;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);

            }
            finally
            {
                factory.FinalizarConexion();
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
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                Usuario _usuario = new Usuario(0, "", "", DateTime.Today, DateTime.Today, 0);
                _usuario = _usuarioDAO.Obtener(pNombreUsuario);
                return _usuario;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para modificar los datos del Usuario
        /// </summary>
        /// <param name="pUsuario"> Usuario a modificar</param>
        public static void Modificar(Usuario pUsuario)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                _usuarioDAO.ModificarNombre(pUsuario.IdUsuario, pUsuario.Nombre);
                _usuarioDAO.ModificarContrasena(pUsuario.Nombre, pUsuario.Contraseña);
                _usuarioDAO.ModificarFechaAlta(pUsuario.Nombre, pUsuario.FechaAlta);
                _usuarioDAO.ModificarFechaBaja(pUsuario.Nombre, pUsuario.FechaBaja);
                //_usuarioDAO.Modificar(pUsuario);
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}