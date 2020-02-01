using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Renglon"
    /// </summary>
    public interface IRenglonDAO
    {
        /// <summary>
        /// Allows add a new "Renglon" to the database
        /// </summary>
        /// <param name="pRenglon">Renglon to be added</param>
        void Agregar(RenglonEntrega pRenglon);
        
        /// <summary>
        /// Obtain an "Renglon" bi his ID
        /// </summary>
        /// <param name="pIdRenglon">ID to search by</param>
        /// <returns>Renglon</returns>
        RenglonEntrega Obtener(int pIdRenglon);
        
        /// <summary>
        /// Modify all field to an "Renglon"
        /// </summary>
        /// <param name="pRenglon">Renglon object with all filled fields</param>
        void Modificar(RenglonEntrega pRenglon);
        
        /// <summary>
        /// Generate a list of "RenglonEntrega" objects
        /// </summary>
        /// <param name="idEntrega">ID to search by</param>
        /// <returns>A list containing objects of class RenglonEntrega</returns>
        List<RenglonEntrega> Listar(int idEntrega);
    }
}
