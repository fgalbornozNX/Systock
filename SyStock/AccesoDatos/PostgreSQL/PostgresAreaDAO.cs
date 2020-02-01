using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Implementation of IAreaDAO for PostgreSQL engine
    /// </summary>
    public class PostgresAreaDAO: IAreaDAO
    {
        /// <summary>
        /// Represents the connection with the database
        /// </summary>
        private readonly NpgsqlConnection _conexion;

        /// <summary>
        /// Constructor for PostgresAreaDAO
        /// </summary>
        /// <param name="pConexion">The connection to the database</param>
        public PostgresAreaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Area" to the database
        /// </summary>
        /// <param name="pArea">Area to be added</param>
        public void Agregar(Area pArea)
        {
            if (pArea == null)
                throw new ArgumentNullException(nameof(pArea));

            try
            {
                string query = "INSERT INTO \"Area\" (nombre) VALUES (@var)";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@var", pArea.Nombre);

                comando.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar agregar un área a la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar agregar un área a la base de datos: " + e.Message);
            }
        }

        /// <summary>
        /// Varify the existence of an "Area" in the database by the field "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        /// <returns>the ID of the Area, if exists</returns>
        public int VerificarNombre(string pNombre)
        {
            try
            {
                string query = "SELECT \"idArea\" FROM \"Area\" WHERE nombre = '" + pNombre + "'";
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                using NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return Int32.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar verificar el nombre de área: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar verificar el nombre de área: " + e.Message);
            }
        }

        /// <summary>
        /// Obtains an "Area" by his ID
        /// </summary>
        /// <param name="pIdArea">ID to search by</param>
        /// <returns>Area object with filled fields</returns>
        public Area Obtener(int pIdArea)
        {
            string query = "SELECT * FROM \"Area\" WHERE \"idArea\" = '" + pIdArea + "'";
            Area area = null;

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
                        int idArea = Convert.ToInt32(fila["idArea"]);
                        string nombre = Convert.ToString(fila["nombre"]);

                        area = new Area(idArea, nombre);
                    }
                }
                return area;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar obtener un Area de la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar obtener un Area de la base de datos: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Area" by his "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        /// <returns>Area object with filled fields</returns>
        public Area Obtener(string pNombre)
        {
            string query = "SELECT * FROM \"Area\" WHERE nombre = '" + pNombre + "'";
            Area area = null;

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
                        int idArea = Convert.ToInt32(fila["idArea"]);
                        string nombre = Convert.ToString(fila["nombre"]);

                        area = new Area(idArea, nombre);
                    }
                }
                return area;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar obtener un Area de la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar obtener un Area de la base de datos: " + e.Message);
            }   
        }

        /// <summary>
        /// Modify an "Area" in the database. Search by ID
        /// </summary>
        /// <param name="pArea">Area object with the modified fields</param>
        public void Modificar(Area pArea)
        {
            if (pArea == null)
                throw new ArgumentNullException(nameof(pArea));

            string query = "UPDATE \"Area\" SET nombre = @var WHERE \"idArea\" = '" + pArea.IdArea + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", pArea.Nombre);
                comando.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar modificar un Area en la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar un Area en la base de datos: " + e.Message);
            }
            
        }

        /// <summary>
        /// List all the available areas
        /// </summary>
        /// <returns>All the areas in the database as Area objects</returns>
        public List<Area> Listar()
        {
            string query = "SELECT * FROM \"Area\"";
            List<Area> listaAreas = new List<Area>();

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
                        int idArea = Convert.ToInt32(fila["idArea"]);
                        string nombre = Convert.ToString(fila["nombre"]);

                        listaAreas.Add(new Area(idArea, nombre));
                    }
                }
                return listaAreas;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar listar áreas: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar listar áreas: " + e.Message);
            }
        }

        /// <summary>
        /// Delete an "Area"
        /// </summary>
        /// <param name="idArea">ID to identify and delete</param>
        public void Eliminar(int idArea)
        {
            string query = "DELETE FROM \"Area\" WHERE \"idArea\" = '" + idArea + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            try
            {
                comando.CommandText = query;
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar eliminar un área: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar eliminar un área: " + e.Message);
            }
        }
    }
}
