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
            if (pRenglon == null)
                throw new ArgumentNullException(nameof(pRenglon));

            string query = "INSERT INTO \"Renglon\" (\"idEntrega\", \"idInsumo\", cantidad) VALUES (@entrega, @insumo, @cantidad)";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                comando.Parameters.AddWithValue("@entrega", pRenglon.IdEntrega);
                comando.Parameters.AddWithValue("@insumo", pRenglon.IdInsumo);
                comando.Parameters.AddWithValue("@cantidad", pRenglon.Cantidad);

                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al agregar renglón de entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al agregar renglón de entrega: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Renglon" bi his ID
        /// </summary>
        /// <param name="pIdRenglon">ID to search by</param>
        /// <returns>Renglon</returns>
        public RenglonEntrega Obtener(int pIdRenglon)
        {
            string query = "SELECT * FROM \"Renglon\" WHERE \"idRenglon\" = '" + pIdRenglon + "'";
            RenglonEntrega renglon = null;

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int _idRenglon = Convert.ToInt32(fila["idRenglon"]);
                        int _idEntrega = Convert.ToInt32(fila["idEntrega"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);

                        renglon = new RenglonEntrega(_idRenglon, _idEntrega, _idInsumo, _cantidad);
                    }
                    tabla.Dispose();
                }
                return renglon;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obtener renglón de entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al obtener renglón de entrega: " + e.Message);
            }
        }

        /// <summary>
        /// Modify all field to an "Renglon"
        /// </summary>
        /// <param name="pRenglon">Renglon object with all filled fields</param>
        public void Modificar(RenglonEntrega pRenglon)
        {
            if (pRenglon == null)
                throw new ArgumentNullException(nameof(pRenglon));

            string query = "UPDATE \"Renglon\" SET \"idInsumo\" = @insumo, cantidad = @cantidad WHERE \"idRenglon\" = '" + pRenglon.IdRenglon + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@insumo", pRenglon.IdInsumo);
                comando.Parameters.AddWithValue("@cantidad", pRenglon.Cantidad);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar renglón de entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar renglón de entrega: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "RenglonEntrega" objects
        /// </summary>
        /// <param name="idEntrega">ID to search by</param>
        /// <returns>A list containing objects of class RenglonEntrega</returns>
        public List<RenglonEntrega> Listar(int idEntrega)
        {
            string query = "SELECT * FROM \"Renglon\" WHERE \"idEntrega\" = '" + idEntrega + "'";
            List<RenglonEntrega> listaRenglon = new List<RenglonEntrega>();

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int _idRenglon = Convert.ToInt32(fila["idRenglon"]);
                        int _idEntrega = Convert.ToInt32(fila["idEntrega"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);

                        listaRenglon.Add(new RenglonEntrega(_idRenglon, _idEntrega, _idInsumo, _cantidad));
                    }
                    tabla.Dispose();
                }
                return listaRenglon;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar renglones de entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar renglones de entrega: " + e.Message);
            }
        }
    }
}