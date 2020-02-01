using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Grupo"
    /// </summary>
    public interface IGrupoDAO
    {
        /// <summary>
        /// Allows add a new "Grupo" to the database
        /// </summary>
        /// <param name="pGrupo">Grupo to be added</param>
        void Agregar(Grupo pGrupo);
        
        /// <summary>
        /// Verify the existence of a "Grupo" in an "Area"
        /// </summary>
        /// <param name="pNombre">Grupo's name to search by</param>
        /// <param name="idArea">Area's ID</param>
        /// <returns></returns>
        int VerificarNombre(string pNombre, int idArea);
        
        /// <summary>
        /// Obtain an "Grupo" by his ID
        /// </summary>
        /// <param name="pIdGrupo">ID to search by</param>
        Grupo Obtener(int pIdGrupo);
        
        /// <summary>
        /// Obtain an "Grupo" by his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        Grupo Obtener(string pNombre);
        
        /// <summary>
        /// Modify all fields of an "Grupo"
        /// </summary>
        /// <param name="pGrupo">Grupo object with all filled fields</param>
        void Modificar(Grupo pGrupo);
        
        /// <summary>
        /// Generate a list of "Grupo" objects
        /// </summary>
        /// <returns>A list containing objects of class Grupo</returns>
        List<Grupo> Listar();
        
        /// <summary>
        /// Generate a list of "Grupo" objects in an "Area"
        /// </summary>
        /// <param name="idArea">Area's ID to match the search</param>
        /// <returns>A list containing all matching objects</returns>
        List<Grupo> Listar(int idArea);
    }
}
