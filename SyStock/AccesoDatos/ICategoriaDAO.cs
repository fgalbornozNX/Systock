using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Categoria"
    /// </summary>
    public interface ICategoriaDAO
    {
        /// <summary>
        /// Allows add a new "Categoria" to the database
        /// </summary>
        /// <param name="pCategoria">Categoria to be added</param>
        void Agregar(Categoria pCategoria);
        
        /// <summary>
        /// Obtain a "Categoria" by his ID
        /// </summary>
        /// <param name="pIdCategoria">ID to search by</param>
        Categoria Obtener(int pIdCategoria);
        
        /// <summary>
        /// Obtain a "Categoria" bi his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        Categoria Obtener(string pNombre);
        
        /// <summary>
        /// Modify all fields in a "Categoria"
        /// </summary>
        /// <param name="pCategoria">Categoria object with filled fields</param>
        void Modificar(Categoria pCategoria);
        
        /// <summary>
        /// Checks the existence of a "Categoria" by his name
        /// </summary>
        /// <param name="pNombre">name to match the search</param>
        /// <returns>ID of the Categoria. -1 if error</returns>
        int VerificarNombre(string pNombre);
        
        /// <summary>
        /// Generate a list of all available "Categoria" objects
        /// </summary>
        /// <returns>A list containing all Categoria objects</returns>
        List<Categoria> Listar();

        /// <summary>
        /// Delete a "Categoria" from the database
        /// </summary>
        /// <param name="id">ID to search by</param>
        void Eliminar(int id);
    }
}
