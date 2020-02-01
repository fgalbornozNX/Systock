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
        void Agregar(Usuario pUsuario);
        int VerificarNombre(string pNombre);
        int Verificar(string pNombre, string pContraseña);
        List<Usuario> Listar();
        Usuario Obtener(int pIdUsuario);
        Usuario Obtener(string pNombreUsuario);
        //void Modificar(Usuario pUsuario);      //  [DEPRECATED]
        void ModificarNombre(int id, string nombre);
        void ModificarNombre(string nombre, string nuevoNombre);
        void ModificarFechaAlta(string nombre, DateTime fecha);
        void ModificarFechaBaja(string nombre, DateTime fecha);
        void ModificarIdUsuario(string nombre, int id);
        void ModificarContrasena(string nombre, string pass);
        void EliminarUsuario(string nombre);
        void EliminarUsuario(int id);
    }
}
