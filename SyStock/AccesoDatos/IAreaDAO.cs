using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Area"
    /// </summary>
    public interface IAreaDAO
    {
        /// <summary>
        /// Allows add a new "Area" to the database
        /// </summary>
        /// <param name="pArea">Area to be added</param>
        void Agregar(Area pArea);

        /// <summary>
        /// Varify the existence of an "Area" in the database by the field "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        /// <returns>the ID of the Area, if exists</returns>
        int VerificarNombre(string pNombre);

        /// <summary>
        /// Obtains an "Area" by his ID
        /// </summary>
        /// <param name="pIdArea">ID to search by</param>
        /// <returns>Area object with filled fields</returns>
        Area Obtener(int pIdArea);

        /// <summary>
        /// Obtain an "Area" by his "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        /// <returns>Area object with filled fields</returns>
        Area Obtener(string pNombre);

        /// <summary>
        /// Modify an "Area" in the database. Search by ID
        /// </summary>
        /// <param name="pArea">Area object with the modified fields</param>
        void Modificar(Area pArea);

        /// <summary>
        /// List all the available areas
        /// </summary>
        /// <returns>All the areas in the database as Area objects</returns>
        List<Area> Listar();

        /// <summary>
        /// Delete an "Area"
        /// </summary>
        /// <param name="idArea">ID to identify and delete</param>
        void Eliminar(int idArea);
    }
}
