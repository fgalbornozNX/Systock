using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "Categoria"
    /// </summary>
    public class PostgresCategoriaDAO: ICategoriaDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresCategoriaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Categoria" to the database
        /// </summary>
        /// <param name="pCategoria">Categoria to be added</param>
        public void Agregar(Categoria pCategoria)
        {
            if (pCategoria == null)
                throw new ArgumentNullException(nameof(pCategoria));

            string query = "INSERT INTO \"Categoria\" (nombre, estado, \"idUsuario\") VALUES (@nombre,@estado,@idusuario)";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                comando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);
                comando.Parameters.AddWithValue("@estado", pCategoria.Estado);
                comando.Parameters.AddWithValue("@idusuario", pCategoria.IdUsuario);

                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al agregar categoría: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al agregar categoría: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain a "Categoria" by his ID
        /// </summary>
        /// <param name="pIdCategoria">ID to search by</param>
        public Categoria Obtener(int pIdCategoria)
        {
            string query = "SELECT * FROM \"Categoria\" WHERE \"idCategoria\" = '" + pIdCategoria + "'";
            Categoria categoria = null;

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
                        int _id = Convert.ToInt32(fila["idCategoria"]);
                        int _idUser = Convert.ToInt32(fila["idUsuario"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);

                        categoria = new Categoria(_id, _nombre, _estado, _idUser);
                    }
                    tabla.Dispose();
                }
                return categoria;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obtener categoría: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al obtener categoría: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain a "Categoria" bi his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public Categoria Obtener(string pNombre)
        {
            string query = "SELECT * FROM \"Categoria\" WHERE nombre = '" + pNombre + "'";
            Categoria categoria = null;

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
                        int _id = Convert.ToInt32(fila["idCategoria"]);
                        int _idUser = Convert.ToInt32(fila["idUsuario"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);

                        categoria = new Categoria(_id, _nombre, _estado, _idUser);
                    }
                    tabla.Dispose();
                }
                return categoria;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al obtener categoría: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al obtener categoría: " + e.Message);
            }
        }

        /// <summary>
        /// Modify all fields in a "Categoria"
        /// </summary>
        /// <param name="pCategoria">Categoria object with filled fields</param>
        public void Modificar(Categoria pCategoria)
        {
            if (pCategoria == null)
                throw new ArgumentNullException(nameof(pCategoria));

            string query = "UPDATE \"Categoria\" SET nombre = @nombre, estado = @estado WHERE \"idCategoria\" = '" + pCategoria.IdCategoria + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);
                comando.Parameters.AddWithValue("@estado", pCategoria.Estado);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar categoría: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al modificar categoría: " + e.Message);
            }
        }

        /// <summary>
        /// Checks the existence of a "Categoria" by his name
        /// </summary>
        /// <param name="pNombre">name to match the search</param>
        /// <returns>ID of the Categoria. -1 if error</returns>
        public int VerificarNombre(string pNombre)
        {
            string query = "SELECT \"idCategoria\" FROM \"Categoria\" WHERE \"nombre\" = '" + pNombre + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                        return Int32.Parse(reader[0].ToString());
                    else
                        return -1;
                }
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar verificar el nombre de la categoría: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar verificar el nombre de la categoría: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of all available "Categoria" objects
        /// </summary>
        /// <returns>A list containing all Categoria objects</returns>
        public List<Categoria> Listar()
        {
            string query = "SELECT * FROM \"Categoria\"";
            List<Categoria> listaCategoria = new List<Categoria>();

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
                        int _id = Convert.ToInt32(fila["idCategoria"]);
                        int _idUser = Convert.ToInt32(fila["idUsuario"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        string _nombre = Convert.ToString(fila["nombre"]);

                        listaCategoria.Add(new Categoria(_id,_nombre,_estado,_idUser));
                    }
                    tabla.Dispose();
                }
                return listaCategoria;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar categorías: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar categorías: " + e.Message);
            }
        }

        /// <summary>
        /// Delete a "Categoria" from the database
        /// </summary>
        /// <param name="id">ID to search by</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM \"Categoria\" WHERE \"idCategoria\" = '" + id + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            try
            {
                comando.CommandText = query;
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar eliminar una categoria: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar eliminar una categoria: " + e.Message);
            }
        }
    }
}
