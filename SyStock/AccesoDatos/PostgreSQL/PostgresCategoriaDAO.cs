using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    public class PostgresCategoriaDAO: ICategoriaDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresCategoriaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Agregar una nueva categoría
        /// </summary>
        /// <param name="pCategoria">Categoría a agregar</param>
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
        /// Obtener una determinada categoría
        /// </summary>
        /// <param name="pIdCategoria">Id categoria a buscar</param>
        /// <returns></returns>
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
        /// Modificar una categoría
        /// </summary>
        /// <param name="pCategoria">Categoría a modificar</param>
        public void Modificar(Categoria pCategoria)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Categoria\" SET nombre = @nombre, estado = @estado WHERE \"idCategoria\" = '" + pCategoria.IdCategoria + "'";

            comando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);
            comando.Parameters.AddWithValue("@estado", pCategoria.Estado);
            comando.ExecuteNonQuery();
        }

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
        /// Listar las categorias
        /// </summary>
        /// <returns></returns>
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
