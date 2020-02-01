using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorRenglones
    {
        public int Agregar(RenglonEntrega pRenglon)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IRenglonDAO _renglonDAO = factory.RenglonDAO;
                _renglonDAO.Agregar(pRenglon);
                return 1;
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

        public List<RenglonEntrega> Listar(int idEntrega)
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<RenglonEntrega> _listaRenglon = new List<RenglonEntrega>();

            try
            {
                factory.IniciarConexion();
                IRenglonDAO _renglonDAO = factory.RenglonDAO;
                _listaRenglon = _renglonDAO.Listar(idEntrega);
                return _listaRenglon;
            }
            catch (Exception)
            {
                _listaRenglon.Clear();
                return _listaRenglon;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public RenglonEntrega Obtener(int idRenglon)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IRenglonDAO _renglonDAO = factory.RenglonDAO;
                RenglonEntrega _renglon = new RenglonEntrega(0, 0, 0);
                _renglon = _renglonDAO.Obtener(idRenglon);
                return _renglon;
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
