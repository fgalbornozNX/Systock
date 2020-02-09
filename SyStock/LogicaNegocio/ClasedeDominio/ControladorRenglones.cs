using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorRenglones
    {
        /// <summary>
        /// Permite agregar un Renglón
        /// </summary>
        /// <param name="pRenglon">Renglón a agregar</param>
        /// <returns>-1 si tuvo éxito</returns>
        public static int Agregar(RenglonEntrega pRenglon)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                factory.RenglonDAO.Agregar(pRenglon);
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
        /// Lista todos los renglones de una determinada Entrega
        /// </summary>
        /// <param name="idEntrega">ID de la entrega a filtrar</param>
        /// <returns>Lista conteniendo todos los renglones de una entrega</returns>
        public static List<RenglonEntrega> Listar(int idEntrega)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<RenglonEntrega> listaRenglon = factory.RenglonDAO.Listar(idEntrega);
                factory.FinalizarConexion();

                return listaRenglon;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene un renglón de entrega
        /// </summary>
        /// <param name="idRenglon">ID del renglón a obtener</param>
        /// <returns></returns>
        public static RenglonEntrega Obtener(int idRenglon)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                RenglonEntrega renglon = factory.RenglonDAO.Obtener(idRenglon);
                factory.FinalizarConexion();

                return renglon;
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
