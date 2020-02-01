using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Entrega"
    /// </summary>
    public interface IEntregaDAO
    {
        void Agregar(EntregaInsumos pEntrega);
        EntregaInsumos Obtener(int pIdEntrega);
        List<EntregaInsumos> Listar();
    }
}
