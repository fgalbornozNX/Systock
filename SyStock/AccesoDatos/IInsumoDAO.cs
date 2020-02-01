using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Insumo"
    /// </summary>
    public interface IInsumoDAO
    {
        void Agregar(Insumo pInsumo);
        int VerificarNombre(string pNombre);
        Insumo Obtener(int pIdInsumo);
        Insumo Obtener(string pNombreInsumo);
        void Modificar(Insumo pInsumo);
        List<Insumo> Listar();
        List<Insumo> Listar(int idCategoria);
    }
}
