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
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Categoria\"(nombre, estado, \"idUsuario\") VALUES(@nombre,@estado,@idusuario)";
            comando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);
            comando.Parameters.AddWithValue("@estado", pCategoria.Estado);
            comando.Parameters.AddWithValue("@idusuario", pCategoria.IdUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Obtain a "Categoria" by his ID
        /// </summary>
        /// <param name="pIdCategoria">ID to search by</param>
        public Categoria Obtener(int pIdCategoria)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Categoria\" WHERE \"idCategoria\" = '" + pIdCategoria + "'";
            Categoria _categoria = new Categoria("", true, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _categoria = new Categoria(Convert.ToInt32(fila["idCategoria"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idUsuario"]));
                }
            }
            return _categoria;
        }

        /// <summary>
        /// Obtain a "Categoria" bi his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public Categoria Obtener(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Categoria\" WHERE nombre = '" + pNombre + "'";
            Categoria _categoria = new Categoria("", true, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _categoria = new Categoria(Convert.ToInt32(fila["idCategoria"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idUsuario"]));
                }
            }
            return _categoria;
        }

        /// <summary>
        /// Modify all fields in a "Categoria"
        /// </summary>
        /// <param name="pCategoria">Categoria object with filled fields</param>
        public void Modificar(Categoria pCategoria)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Categoria\" SET nombre = @nombre, estado = @estado WHERE \"idCategoria\" = '" + pCategoria.IdCategoria + "'";

            comando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);
            comando.Parameters.AddWithValue("@estado", pCategoria.Estado);
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Checks the existence of a "Categoria" by his name
        /// </summary>
        /// <param name="pNombre">name to match the search</param>
        /// <returns>ID of the Categoria. -1 if error</returns>
        public int VerificarNombre(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "SELECT \"idCategoria\" FROM \"Categoria\" WHERE \"nombre\" = '" + pNombre + "'";
            NpgsqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return Int32.Parse(reader[0].ToString());
            }

            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Generate a list of all available "Categoria" objects
        /// </summary>
        /// <returns>A list containing all Categoria objects</returns>
        public List<Categoria> Listar()
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Categoria\"";

            List<Categoria> _listaCategoria = new List<Categoria>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaCategoria.Add(new Categoria(Convert.ToInt32(fila["idCategoria"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idUsuario"])));
                }
            }
            return _listaCategoria;
        }
    }
}
