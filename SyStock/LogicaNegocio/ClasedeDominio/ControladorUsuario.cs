using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorUsuario
    {
        public int Agregar(Usuario pUsuario)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                int idUsuario = _usuarioDAO.VerificarNombre(pUsuario.Nombre);
                factory.FinalizarConexion();
                if (idUsuario == -1)
                {
                    factory.IniciarConexion();
                    _usuarioDAO.Agregar(pUsuario);
                }
                return idUsuario;

            }
            catch (DAOException)
            {
                factory.RollBack();
                return -1;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public Usuario Verificar(string pNombre, string pContraseña)
        {
            DAOFactory factory = DAOFactory.Instancia();
            Usuario user;
            int idUser;

            try
            {
                factory.IniciarConexion();
                IUsuarioDAO _usuarioDAO = factory.UsuarioDAO;
                idUser = _usuarioDAO.Verificar(pNombre, pContraseña);  //Trae el id del Usuario o -1 si no lo encontró
                if (idUser == -1) {
                    return null;
                }
                else {
                    user = _usuarioDAO.Obtener(idUser);
                    return user; 
                }
            }
            catch (DAOException e)
            {
                idUser = -1;
                user = null;
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<Usuario> Listar()
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
            catch (Exception)
            {
                _listaUsuarios.Clear();
                return _listaUsuarios;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public Usuario Obtener(int pIdUsuario)
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
            catch (Exception)
            {
                return null;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public Usuario Obtener(string pNombreUsuario)
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
            catch (Exception)
            {
                return null;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public void Modificar(Usuario pUsuario)
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
            catch (DAOException)
            {
                factory.RollBack();
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}
