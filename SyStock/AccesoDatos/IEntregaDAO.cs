using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Entrega"
    /// </summary>
    public interface IEntregaDAO
    {
        /// <summary>
        /// Allows add a new "Entrega" to the database
        /// </summary>
        /// <param name="pEntrega">Entrega to be added</param>
        void Agregar(EntregaInsumos pEntrega);
        
        /// <summary>
        /// Obtain an "Engtrega" by his ID
        /// </summary>
        /// <param name="pIdEntrega">ID to search by</param>
        EntregaInsumos Obtener(int pIdEntrega);
        
        /// <summary>
        /// Generate a list of EntregaInsumos objects
        /// </summary>
        /// <returns>A list containing all EntregaInsumos objects</returns>
        List<EntregaInsumos> Listar();
    }
}
