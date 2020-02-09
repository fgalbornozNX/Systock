using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorInsumo
    {
        public static int Agregar(Insumo pInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                int idInsumo = _insumoDAO.VerificarNombre(pInsumo.Nombre);
                factory.FinalizarConexion();
                if (idInsumo == -1)
                {
                    factory.IniciarConexion();
                    _insumoDAO.Agregar(pInsumo);
                }
                return idInsumo;
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

        public static Insumo Obtener(int pIdInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                Insumo _insumo = new Insumo(0, "", "", 0, 0, true, 0);
                _insumo = _insumoDAO.Obtener(pIdInsumo);
                return _insumo;
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

        public static Insumo Obtener(string pNombreInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                Insumo _insumo = new Insumo(0, "", "", 0, 0, true, 0);
                _insumo = _insumoDAO.Obtener(pNombreInsumo);
                return _insumo;
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

        public static bool Modificar(Insumo pInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                _insumoDAO.Modificar(pInsumo);
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

        public static List<Insumo> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Insumo> _listaInsumo = new List<Insumo>();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                _listaInsumo = _insumoDAO.Listar();
                return _listaInsumo;
            }
            catch (Exception)
            {
                _listaInsumo.Clear();
                return _listaInsumo;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public static List<Insumo> Listar(int idCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Insumo> _listaInsumo = new List<Insumo>();

            try
            {
                factory.IniciarConexion();
                IInsumoDAO _insumoDAO = factory.InsumoDAO;
                _listaInsumo = _insumoDAO.Listar(idCategoria);
                return _listaInsumo;
            }
            catch (Exception)
            {
                _listaInsumo.Clear();
                return _listaInsumo;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}
