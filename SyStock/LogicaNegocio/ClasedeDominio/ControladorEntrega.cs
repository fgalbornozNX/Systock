using System;
using System.Collections.Generic;
using System.Linq;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorEntrega
    {
        public static int Agregar(EntregaInsumos pEntrega)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IEntregaDAO _entregaDAO = factory.EntregaDAO;
                _entregaDAO.Agregar(pEntrega);
                List<EntregaInsumos> _list = new List<EntregaInsumos>();
                _list = _entregaDAO.Listar();
                return _list.Count();
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

        public static List<EntregaInsumos> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<EntregaInsumos> _listaEntrega = new List<EntregaInsumos>();

            try
            {
                factory.IniciarConexion();
                IEntregaDAO _entregaDAO = factory.EntregaDAO;
                _listaEntrega = _entregaDAO.Listar();
                return _listaEntrega;
            }
            catch (Exception)
            {
                _listaEntrega.Clear();
                return _listaEntrega;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public static EntregaInsumos Obtener(int idEntrega)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IEntregaDAO _entregaDAO = factory.EntregaDAO;
                EntregaInsumos _entrega = new EntregaInsumos(0,0,DateTime.Today);
                _entrega = _entregaDAO.Obtener(idEntrega);
                return _entrega;
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
