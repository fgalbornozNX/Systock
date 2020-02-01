using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorArea
    {
        public int Agregar(Area pArea)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                int idArea = _areaDAO.VerificarNombre(pArea.Nombre);
                factory.FinalizarConexion();
                if (idArea == -1)
                {
                    factory.IniciarConexion();
                    _areaDAO.Agregar(pArea);
                }
                return idArea;
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

        public List<Area> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Area> _listaArea = new List<Area>();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                _listaArea = _areaDAO.Listar();
                return _listaArea;
            }
            catch (Exception)
            {
                _listaArea.Clear();
                return _listaArea;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public bool Modificar(Area pArea)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                _areaDAO.Modificar(pArea);
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

        public Area Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                Area _area = new Area("");
                _area = _areaDAO.Obtener(pNombre);
                return _area;
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

        public Area Obtener(int pId)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                Area _area = new Area("");
                _area = _areaDAO.Obtener(pId);
                return _area;
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
