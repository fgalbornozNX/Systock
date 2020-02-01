using System.Collections.Generic;
using SyStock.Entidades;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Interface for Data Access Object "Renglon"
    /// </summary>
    public interface IRenglonDAO
    {
        void Agregar(RenglonEntrega pRenglon);
        RenglonEntrega Obtener(int pIdRenglon);
        void Modificar(RenglonEntrega pRenglon);
        List<RenglonEntrega> Listar(int idEntrega);
    }
}
