using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Insumo"
    /// </summary>
    public interface IInsumoDAO
    {
        /// <summary>
        /// Allows add a new "Insumo" to the database
        /// </summary>
        /// <param name="pInsumo">Insumo to be added</param>
        void Agregar(Insumo pInsumo);
        
        /// <summary>
        /// Verify the existence of an "Insumo"
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        int VerificarNombre(string pNombre);
        
        /// <summary>
        /// Obtain an "Insumo". Search by ID
        /// </summary>
        /// <param name="pIdInsumo">ID to search by</param>
        Insumo Obtener(int pIdInsumo);
        
        /// <summary>
        /// Obtain an "Insumo". Search by name
        /// </summary>
        /// <param name="pNombreInsumo">name to search by</param>
        Insumo Obtener(string pNombreInsumo);
        
        /// <summary>
        /// Modify all field in an "Insumo"
        /// </summary>
        /// <param name="pInsumo">Insumo with all filled fields</param>
        void Modificar(Insumo pInsumo);
        
        /// <summary>
        /// Generate a list of "Insumo" objects
        /// </summary>
        /// <returns>A list containing all available "Insumo" entries</returns>
        List<Insumo> Listar();
        
        /// <summary>
        /// Generate a list of "Insumo" objects that match a category
        /// </summary>
        /// <param name="idCategoria">category's ID to search by</param>
        /// <returns>A list containint all matching "Insumo" entries</returns>
        List<Insumo> Listar(int idCategoria);
    }
}
