using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorGrupo
    {
        public int Agregar(Grupo pGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                int idGrupo = _grupoDAO.VerificarNombre(pGrupo.Nombre, pGrupo.IdArea);
                factory.FinalizarConexion();
                if (idGrupo == -1)
                {
                    factory.IniciarConexion();
                    _grupoDAO.Agregar(pGrupo);
                }
                return idGrupo;
            }
            catch (DAOException)
            {
                factory.RollBack();
                return -2;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public bool Modificar(Grupo pGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                _grupoDAO.Modificar(pGrupo);
                return true;
            }
            catch (DAOException)
            {
                factory.RollBack();
                return false;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<Grupo> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Grupo> _listaGrupo = new List<Grupo>();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                _listaGrupo = _GrupoDAO.Listar();
                return _listaGrupo;
            }
            catch (Exception)
            {
                _listaGrupo.Clear();
                return _listaGrupo;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<Grupo> Listar(int idArea)
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Grupo> _listaGrupo = new List<Grupo>();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                _listaGrupo = _grupoDAO.Listar(idArea);
                return _listaGrupo;
            }
            catch (Exception)
            {
                _listaGrupo.Clear();
                return _listaGrupo;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public Grupo Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                Grupo _Grupo = new Grupo(0, "", true, 0, 0);
                _Grupo = _GrupoDAO.Obtener(pNombre);
                return _Grupo;
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

        public Grupo Obtener(int pId)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                Grupo _Grupo = new Grupo(0, "", true, 0, 0);
                _Grupo = _GrupoDAO.Obtener(pId);
                return _Grupo;
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
    }
}
