using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Categoria"
    /// </summary>
    public interface ICategoriaDAO
    {
        void Agregar(Categoria pCategoria);
        Categoria Obtener(int pIdCategoria);
        Categoria Obtener(string pNombre);
        void Modificar(Categoria pCategoria);
        int VerificarNombre(string pNombre);
        List<Categoria> Listar();
    }
}
