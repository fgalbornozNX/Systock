using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorEntrega
    {
        /// <summary>
        /// Permite agregar una Entrega
        /// </summary>
        /// <param name="pEntrega">Entrega a agregar</param>
        /// <returns>-1 si tuvo éxito</returns>
        public static int Agregar(EntregaInsumos pEntrega)
        {
            if (pEntrega == null)
                throw new ArgumentNullException(nameof(pEntrega));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                factory.EntregaDAO.Agregar(pEntrega);
                factory.FinalizarConexion();

                return -1;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista las Entregas existentes
        /// </summary>
        /// <returns>Lista con todas las entregas</returns>
        public static List<EntregaInsumos> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<EntregaInsumos> listaEntrega = factory.EntregaDAO.Listar();
                factory.FinalizarConexion();

                return listaEntrega;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Permite obtener una Entrega
        /// </summary>
        /// <param name="idEntrega">ID de la entrega a buscar</param>
        /// <returns>Entrega encontrada en caso de éxito. Null caso contrario</returns>
        public static EntregaInsumos Obtener(int idEntrega)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                EntregaInsumos entrega = factory.EntregaDAO.Obtener(idEntrega);
                factory.FinalizarConexion();

                return entrega;
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
