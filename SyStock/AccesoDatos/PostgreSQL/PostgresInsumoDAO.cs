using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "Insumo"
    /// </summary>
    public class PostgresInsumoDAO : IInsumoDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresInsumoDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Insumo" to the database
        /// </summary>
        /// <param name="pInsumo">Insumo to be added</param>
        public void Agregar(Insumo pInsumo)
        {
            if (pInsumo == null)
                throw new ArgumentNullException(nameof(pInsumo));

            string query = "INSERT INTO \"Insumo\" (nombre, descripcion, cantidad, \"cantidadMinima\", estado, \"idCategoria\") VALUES (@nombre,@descripcion,@cantidad,@cantidadminima,@estado,@idCategoria)";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                comando.Parameters.AddWithValue("@nombre", pInsumo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", pInsumo.Descripcion);
                comando.Parameters.AddWithValue("@cantidad", pInsumo.Cantidad);
                comando.Parameters.AddWithValue("@cantidadminima", pInsumo.CantidadMinima);
                comando.Parameters.AddWithValue("@estado", pInsumo.Estado);
                comando.Parameters.AddWithValue("@idCategoria", pInsumo.IdCategoria);

                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al agregar insumo: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al agregar insumo: " + e.Message);
            }
        }

        /// <summary>
        /// Verify the existence of an "Insumo"
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public int VerificarNombre(string pNombre)
        {
            string query = "SELECT \"idInsumo\" FROM \"Insumo\" WHERE \"nombre\" = '" + pNombre + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return Int32.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al verificar existencia de insumo: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al verificar existencia de insumo: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Insumo". Search by ID
        /// </summary>
        /// <param name="pIdInsumo">ID to search by</param>
        public Insumo Obtener(int pIdInsumo)
        {
            string query = "SELECT * FROM \"Insumo\" WHERE \"idInsumo\" = '" + pIdInsumo + "'";
            Insumo insumo = null;

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
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);
                        int _cantidadMin = Convert.ToInt32(fila["cantidadMinima"]);
                        int _idCategoria = Convert.ToInt32(fila["idCategoria"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        string _descripcion = Convert.ToString(fila["descripcion"]);

                        insumo = new Insumo(_idInsumo, _nombre, _descripcion, _cantidad, _cantidadMin, _estado, _idCategoria);
                    }
                    tabla.Dispose();
                }
                return insumo;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obtener insumo: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al obtener insumo: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Insumo". Search by name
        /// </summary>
        /// <param name="pNombreInsumo">name to search by</param>
        public Insumo Obtener(string pNombreInsumo)
        {
            string query = "SELECT * FROM \"Insumo\" WHERE nombre = '" + pNombreInsumo + "'";
            Insumo insumo = null;

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
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);
                        int _cantidadMin = Convert.ToInt32(fila["cantidadMinima"]);
                        int _idCategoria = Convert.ToInt32(fila["idCategoria"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        string _descripcion = Convert.ToString(fila["descripcion"]);

                        insumo = new Insumo(_idInsumo, _nombre, _descripcion, _cantidad, _cantidadMin, _estado, _idCategoria);
                    }
                    tabla.Dispose();
                }
                return insumo;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obtener insumo: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al obtener insumo: " + e.Message);
            }
        }

        /// <summary>
        /// Modify all field in an "Insumo"
        /// </summary>
        /// <param name="pInsumo">Insumo with all filled fields</param>
        public void Modificar(Insumo pInsumo)
        {
            if (pInsumo == null)
                throw new ArgumentNullException(nameof(pInsumo));

            string query = "UPDATE \"Insumo\" SET nombre = @nombre, descripcion = @descripcion, cantidad = @cantidad, \"cantidadMinima\" = @minima, estado = @estado, \"idCategoria\" = @idCategoria WHERE \"idInsumo\" = '" + pInsumo.IdInsumo + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@nombre", pInsumo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", pInsumo.Descripcion);
                comando.Parameters.AddWithValue("@cantidad", pInsumo.Cantidad);
                comando.Parameters.AddWithValue("@minima", pInsumo.CantidadMinima);
                comando.Parameters.AddWithValue("@estado", pInsumo.Estado);
                comando.Parameters.AddWithValue("@idCategoria", pInsumo.IdCategoria);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar insumo: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar insumo: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Insumo" objects
        /// </summary>
        /// <returns>A list containing all available "Insumo" entries</returns>
        public List<Insumo> Listar()
        {
            string query = "SELECT * FROM \"Insumo\"";
            List<Insumo> listaInsumos = new List<Insumo>();

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
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);
                        int _cantidadMin = Convert.ToInt32(fila["cantidadMinima"]);
                        int _idCategoria = Convert.ToInt32(fila["idCategoria"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        string _descripcion = Convert.ToString(fila["descripcion"]);

                        listaInsumos.Add(new Insumo(_idInsumo, _nombre, _descripcion, _cantidad, _cantidadMin, _estado, _idCategoria));
                    }
                    tabla.Dispose();
                }
                return listaInsumos;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar insumos: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar insumos: " + e.Message);
            }

        }

        /// <summary>
        /// Generate a list of "Insumo" objects that match a category
        /// </summary>
        /// <param name="idCategoria">category's ID to search by</param>
        /// <returns>A list containint all matching "Insumo" entries</returns>
        public List<Insumo> Listar(int idCategoria)
        {
            string query = "SELECT * FROM \"Insumo\" WHERE \"idCategoria\" = '" + idCategoria + "'";
            List<Insumo> listaInsumos = new List<Insumo>();

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
                        int _cantidad = Convert.ToInt32(fila["cantidad"]);
                        int _cantidadMin = Convert.ToInt32(fila["cantidadMinima"]);
                        int _idCategoria = Convert.ToInt32(fila["idCategoria"]);
                        int _idInsumo = Convert.ToInt32(fila["idInsumo"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        string _descripcion = Convert.ToString(fila["descripcion"]);

                        listaInsumos.Add(new Insumo(_idInsumo, _nombre, _descripcion, _cantidad, _cantidadMin, _estado, _idCategoria));
                    }
                    tabla.Dispose();
                }
                return listaInsumos;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar insumos: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar insumos: " + e.Message);
            }
        }
    }
}
