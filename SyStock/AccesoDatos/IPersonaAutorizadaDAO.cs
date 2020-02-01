using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Persona"
    /// </summary>
    public interface IPersonaAutorizadaDAO
    {
        /// <summary>
        /// Allows add a new "Persona" to the database
        /// </summary>
        /// <param name="pPersona">Persona to be added</param>
        void Agregar(PersonaAutorizada pPersona);
        
        /// <summary>
        /// Verify the existence of an "Persona" by field "nombre"
        /// </summary>
        /// <param name="pNombre">"nombre" to be checked</param>
        /// <returns></returns>
        int VerificarNombre(string pNombre);
        
        /// <summary>
        /// Verify the user credentials in the database
        /// </summary>
        /// <param name="pNombre">"Persona"s name</param>
        /// <param name="pContraseña">password to be checked</param>
        /// <returns>Persona's ID in the database. -1 if error</returns>
        int Verificar(string pNombre, string pContraseña);
        
        /// <summary>
        /// Generate a list of "Persona" objects
        /// </summary>
        /// <returns>A list containing objects of class PersonaAutorizada</returns>
        List<PersonaAutorizada> Listar();
        
        /// <summary>
        /// Generate a list of "Persona" objects in a group
        /// </summary>
        /// <param name="idGrupo">ID of the group</param>
        /// <returns></returns>
        List<PersonaAutorizada> Listar(int idGrupo);
        
        /// <summary>
        /// Obtain an "Persona" by his ID
        /// </summary>
        /// <param name="pIdPersona">ID to search by</param>
        PersonaAutorizada Obtener(int pIdPersona);
        
        /// <summary>
        /// Obtain an "Persona" by his field "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        PersonaAutorizada Obtener(string pNombre);
        
        /// <summary>
        /// Modify all fields for a "Persona" 
        /// </summary>
        /// <param name="pPersona">Persona with all filled fields</param>
        void Modificar(PersonaAutorizada pPersona);
    }
}
