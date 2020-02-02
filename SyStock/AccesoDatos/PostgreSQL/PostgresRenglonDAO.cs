using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "Renglon"
    /// </summary>
    public class PostgresRenglonDAO: IRenglonDAO
    {
        /// <summary>
        /// Represent the conecction towards the database
        /// </summary>
        private readonly NpgsqlConnection _conexion;

        public PostgresRenglonDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Renglon" to the database
        /// </summary>
        /// <param name="pRenglon">Renglon to be added</param>
        public void Agregar(RenglonEntrega pRenglon)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Renglon\"(\"idEntrega\", \"idInsumo\", cantidad) VALUES(@entrega, @insumo, @cantidad)";
            comando.Parameters.AddWithValue("@entrega", pRenglon.IdEntrega);
            comando.Parameters.AddWithValue("@insumo", pRenglon.IdInsumo);
            comando.Parameters.AddWithValue("@cantidad", pRenglon.Cantidad);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Obtain an "Renglon" bi his ID
        /// </summary>
        /// <param name="pIdRenglon">ID to search by</param>
        /// <returns>Renglon</returns>
        public RenglonEntrega Obtener(int pIdRenglon)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Renglon\" WHERE \"idRenglon\" = '" + pIdRenglon + "'";
            RenglonEntrega _renglon = new RenglonEntrega(0,0,0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _renglon = new RenglonEntrega(Convert.ToInt32(fila["idRenglon"]), Convert.ToInt32(fila["idEntrega"]), Convert.ToInt32(fila["idInsumo"]), Convert.ToInt32(fila["cantidad"]));
                }
            }
            return _renglon;
        }

        /// <summary>
        /// Modify all field to an "Renglon"
        /// </summary>
        /// <param name="pRenglon">Renglon object with all filled fields</param>
        public void Modificar(RenglonEntrega pRenglon)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Renglon\" SET \"idInsumo\" = @insumo, cantidad = @cantidad WHERE \"idRenglon\" = '" + pRenglon.IdRenglon + "'";

            comando.Parameters.AddWithValue("@insumo", pRenglon.IdInsumo);
            comando.Parameters.AddWithValue("@cantidad", pRenglon.Cantidad);
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Generate a list of "RenglonEntrega" objects
        /// </summary>
        /// <param name="idEntrega">ID to search by</param>
        /// <returns>A list containing objects of class RenglonEntrega</returns>
        public List<RenglonEntrega> Listar(int idEntrega)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Renglon\" WHERE \"idRenglon\" = '" + idEntrega + "'";

            List<RenglonEntrega> _listaRenglon = new List<RenglonEntrega>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaRenglon.Add(new RenglonEntrega(Convert.ToInt32(fila["idRenglon"]), Convert.ToInt32(fila["idEntrega"]), Convert.ToInt32(fila["idInsumo"]), Convert.ToInt32(fila["cantidad"])));
                }
            }
            return _listaRenglon;
        }
    }
}