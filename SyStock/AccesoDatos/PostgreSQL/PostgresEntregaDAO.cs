using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "Entrega"
    /// </summary>
    public class PostgresEntregaDAO : IEntregaDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresEntregaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Entrega" to the database
        /// </summary>
        /// <param name="pEntrega">Entrega to be added</param>
        public void Agregar(EntregaInsumos pEntrega)
        {
            if (pEntrega == null)
                throw new ArgumentNullException(nameof(pEntrega));

            string query = "INSERT INTO \"Entrega\" (\"idUsuario\", \"idPersona\", fecha) VALUES (@usuario, @persona, @fecha)";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                comando.Parameters.AddWithValue("@usuario", pEntrega.IdUsuario);
                comando.Parameters.AddWithValue("@persona", pEntrega.IdPersona);
                comando.Parameters.AddWithValue("@fecha", pEntrega.Fecha.ToString());
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al agregar entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al agregar entrega: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Engtrega" by his ID
        /// </summary>
        /// <param name="pIdEntrega">ID to search by</param>
        public EntregaInsumos Obtener(int pIdEntrega)
        {
            string query = "SELECT * FROM \"Entrega\" WHERE \"idEntrega\" = '" + pIdEntrega + "'";
            EntregaInsumos entrega = null;

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
                        int _id = Convert.ToInt32(fila["idEntrega"]);
                        int _idUser = Convert.ToInt32(fila["idUsuario"]);
                        int _idPersona = Convert.ToInt32(fila["idPersona"]);
                        DateTime _fecha = Convert.ToDateTime(fila["fecha"]);

                        entrega = new EntregaInsumos(_id, _idUser, _idPersona, _fecha);
                    }
                    tabla.Dispose();
                }
                return entrega;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obetener entrega: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al obetener entrega: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of EntregaInsumos objects
        /// </summary>
        /// <returns>A list containing all EntregaInsumos objects</returns>
        public List<EntregaInsumos> Listar()
        {
            string query = "SELECT * FROM \"Entrega\"";
            List<EntregaInsumos> listaEntrega = new List<EntregaInsumos>();

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
                        int _id = Convert.ToInt32(fila["idEntrega"]);
                        int _idUser = Convert.ToInt32(fila["idUsuario"]);
                        int _idPersona = Convert.ToInt32(fila["idPersona"]);
                        DateTime _fecha = Convert.ToDateTime(fila["fecha"]);

                        listaEntrega.Add(new EntregaInsumos(_id, _idUser, _idPersona, _fecha));
                    }
                    tabla.Dispose();
                }
                return listaEntrega;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar entregas: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar entregas: " + e.Message);
            }
        }
    }
}
