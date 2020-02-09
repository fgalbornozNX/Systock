using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorInsumo
    {
        /// <summary>
        /// Permite agregar un Insumo
        /// </summary>
        /// <param name="pInsumo">Insumo a agregar</param>
        /// <returns>-1 si hubo éxito</returns>
        public static int Agregar(Insumo pInsumo)
        {
            if ((pInsumo == null) || (pInsumo.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pInsumo));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                int idInsumo = factory.InsumoDAO.VerificarNombre(pInsumo.Nombre);
                factory.FinalizarConexion();

                if (idInsumo == -1)
                {
                    factory.IniciarConexion();
                    factory.InsumoDAO.Agregar(pInsumo);
                    factory.FinalizarConexion();
                }
                return idInsumo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Permite obtener un Insumo. Buscar por ID
        /// </summary>
        /// <param name="pIdInsumo">ID del insumo a buscar</param>
        /// <returns>Insumo encontrado. Null en caso de error</returns>
        public static Insumo Obtener(int pIdInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Insumo insumo = factory.InsumoDAO.Obtener(pIdInsumo);
                factory.FinalizarConexion();

                return insumo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Permite obtener un Insumo. Buscar por nombre
        /// </summary>
        /// <param name="pNombreInsumo">Nombre del insumo a buscar</param>
        /// <returns>Insumo encontrado. Null en caso de error</returns>
        public static Insumo Obtener(string pNombreInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Insumo insumo = factory.InsumoDAO.Obtener(pNombreInsumo);
                factory.FinalizarConexion();

                return insumo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Permite modificar un Insumo
        /// </summary>
        /// <param name="pInsumo">Insumo a modificar. Busca por su ID</param>
        public static void Modificar(Insumo pInsumo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                factory.InsumoDAO.Modificar(pInsumo);
                factory.FinalizarConexion();
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista todos los insumos
        /// </summary>
        /// <returns>Lista conteniendo todos los insumos disponibles</returns>
        public static List<Insumo> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Insumo> listaInsumo = factory.InsumoDAO.Listar();
                factory.FinalizarConexion();

                return listaInsumo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista todos los insumos que pertenecen a una Categoría
        /// </summary>
        /// <param name="idCategoria">ID de la categoría a filtrar</param>
        /// <returns>Lista conteniendo todos los insumos de una Categoría</returns>
        public static List<Insumo> Listar(int idCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Insumo> listaInsumo = factory.InsumoDAO.Listar(idCategoria);
                factory.FinalizarConexion();

                return listaInsumo;
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
