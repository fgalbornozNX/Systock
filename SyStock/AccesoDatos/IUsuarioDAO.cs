using System;
using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Usuario"
    /// </summary>
    public interface IUsuarioDAO
    {
        /// <summary>
        /// Allows add a new "Usuario" to the database
        /// </summary>
        /// <param name="pUsuario">Usuario to be added</param>
        void Agregar(Usuario pUsuario);

        /// <summary>
        /// Verify the existence of an "Usuario" by field "nombre"
        /// </summary>
        /// <param name="pNombre">"nombre" to be checked</param>
        /// <returns>Usuario's ID in the database. -1 if error</returns>
        int VerificarNombre(string pNombre);
        
        /// <summary>
        /// Verify the user credentials in the database
        /// </summary>
        /// <param name="pNombre">"Usuario"s name</param>
        /// <param name="pContraseña">password to be checked</param>
        /// <returns>Usuario's ID in the database. -1 if error</returns>
        int Verificar(string pNombre, string pContraseña);

        /// <summary>
        /// Generate a list of "Usuario" objects
        /// </summary>
        /// <returns>A list containing objects of class Usuario</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Obtain an "Usuario" by his ID
        /// </summary>
        /// <param name="idUsuario">"Usuario"s ID</param>
        Usuario Obtener(int pIdUsuario);

        /// <summary>
        /// Obtain an "Usuario" by the field "nombre"
        /// </summary>
        /// <param name="nombre">Field "nombre" to search</param>
        Usuario Obtener(string pNombreUsuario);

        //void Modificar(Usuario pUsuario);      //  [DEPRECATED]

        /// <summary>
        /// Modify an "Usuario"s field "nombre". Search by ID
        /// </summary>
        /// <param name="id">ID to match</param>
        /// <param name="nombre">New "nombre" for the finded "id"</param>
        void ModificarNombre(int id, string nombre);

        /// <summary>
        /// Modify an "Usuario"s field "nombre". Search by previous "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="nuevoNombre">new value for the field "nombre"</param>
        void ModificarNombre(string nombre, string nuevoNombre);

        /// <summary>
        /// Modify an "Usuario"s field "fechaAlta". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="fecha">new value to the field "fechaAlta"</param>
        void ModificarFechaAlta(string nombre, DateTime fecha);

        /// <summary>
        /// Modify an "Usuario"s field "fechaBaja". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="fecha">new value to the field "fechaBaja"</param>
        void ModificarFechaBaja(string nombre, DateTime fecha);

        /// <summary>
        /// Modify an "Usuario"s field "idUsuario". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="id">new value to field "idUsuario"</param>
        void ModificarIdUsuario(string nombre, int id);

        /// <summary>
        /// Modify the password for a given "Usuario"s "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="pass">new password</param>
        void ModificarContrasena(string nombre, string pass);

        /// <summary>
        /// Delete an "Usuario" from the database
        /// </summary>
        /// <param name="nombre">to search by</param>
        void EliminarUsuario(string nombre);

        /// <summary>
        /// Delete an "Usuario" from the database
        /// </summary>
        /// <param name="id">to search by</param>
        void EliminarUsuario(int id);
    }
}
