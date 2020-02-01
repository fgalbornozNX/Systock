using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Persona"
    /// </summary>
    public interface IPersonaAutorizadaDAO
    {
        void Agregar(PersonaAutorizada pPersona);
        int VerificarNombre(string pNombre);
        int Verificar(string pNombre, string pContraseña);
        List<PersonaAutorizada> Listar();
        List<PersonaAutorizada> Listar(int idGrupo);
        PersonaAutorizada Obtener(int pIdUsuario);
        PersonaAutorizada Obtener(string pNombre);
        void Modificar(PersonaAutorizada pPersona);
    }
}
