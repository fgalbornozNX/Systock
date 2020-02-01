using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Grupo"
    /// </summary>
    public interface IGrupoDAO
    {
        void Agregar(Grupo pGrupo);
        int VerificarNombre(string pNombre, int idArea);
        Grupo Obtener(int pIdGrupo);
        Grupo Obtener(string pNombre);
        void Modificar(Grupo pGrupo);
        List<Grupo> Listar();
        List<Grupo> Listar(int idArea);
    }
}
