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
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Insumo\"(nombre, descripcion, cantidad, \"cantidadMinima\", estado, \"idCategoria\") VALUES(@nombre,@descripcion,@cantidad,@cantidadminima,@estado,@idCategoria)";
            comando.Parameters.AddWithValue("@nombre", pInsumo.Nombre);
            comando.Parameters.AddWithValue("@descripcion", pInsumo.Descripcion);
            comando.Parameters.AddWithValue("@cantidad", pInsumo.Cantidad);
            comando.Parameters.AddWithValue("@cantidadminima", pInsumo.CantidadMinima);
            comando.Parameters.AddWithValue("@estado", pInsumo.Estado);
            comando.Parameters.AddWithValue("@idCategoria", pInsumo.IdCategoria);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Verify the existence of an "Insumo"
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public int VerificarNombre(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "SELECT \"idInsumo\" FROM \"Insumo\" WHERE \"nombre\" = '" + pNombre + "'";
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
        /// Obtain an "Insumo". Search by ID
        /// </summary>
        /// <param name="pIdInsumo">ID to search by</param>
        public Insumo Obtener(int pIdInsumo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Insumo\" WHERE \"idInsumo\" = '" + pIdInsumo + "'";
            Insumo _insumo = new Insumo("", "", 0, 0, true, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _insumo = new Insumo(Convert.ToInt32(fila["idInsumo"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["descripcion"]), Convert.ToInt32(fila["cantidad"]), Convert.ToInt32(fila["cantidadMinima"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idCategoria"]));
                }
            }
            return _insumo;
        }

        /// <summary>
        /// Obtain an "Insumo". Search by name
        /// </summary>
        /// <param name="pNombreInsumo">name to search by</param>
        public Insumo Obtener(string pNombreInsumo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Insumo\" WHERE nombre = '" + pNombreInsumo + "'";
            Insumo _insumo = new Insumo("", "", 0, 0, true, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _insumo = new Insumo(Convert.ToInt32(fila["idInsumo"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["descripcion"]), Convert.ToInt32(fila["cantidad"]), Convert.ToInt32(fila["cantidadMinima"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idCategoria"]));
                }
            }
            return _insumo;
        }

        /// <summary>
        /// Modify all field in an "Insumo"
        /// </summary>
        /// <param name="pInsumo">Insumo with all filled fields</param>
        public void Modificar(Insumo pInsumo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Insumo\" SET nombre = @nombre, descripcion = @descripcion, cantidad = @cantidad, \"cantidadMinima\" = @minima, estado = @estado WHERE \"idInsumo\" = '" + pInsumo.IdInsumo + "'";

            comando.Parameters.AddWithValue("@nombre", pInsumo.Nombre);
            comando.Parameters.AddWithValue("@descripcion", pInsumo.Descripcion);
            comando.Parameters.AddWithValue("@cantidad", pInsumo.Cantidad);
            comando.Parameters.AddWithValue("@minima", pInsumo.CantidadMinima);
            comando.Parameters.AddWithValue("@estado", pInsumo.Estado);
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Generate a list of "Insumo" objects
        /// </summary>
        /// <returns>A list containing all available "Insumo" entries</returns>
        public List<Insumo> Listar()
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Insumo\"";

            List<Insumo> _listaInsumos = new List<Insumo>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaInsumos.Add(new Insumo(Convert.ToInt32(fila["idInsumo"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["descripcion"]), Convert.ToInt32(fila["cantidad"]), Convert.ToInt32(fila["cantidadMinima"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idCategoria"])));
                }
            }
            return _listaInsumos;
        }

        /// <summary>
        /// Generate a list of "Insumo" objects that match a category
        /// </summary>
        /// <param name="idCategoria">category's ID to search by</param>
        /// <returns>A list containint all matching "Insumo" entries</returns>
        public List<Insumo> Listar(int idCategoria)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Insumo\" WHERE \"idCategoria\" = '" + idCategoria + "'";

            List<Insumo> _listaInsumos = new List<Insumo>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaInsumos.Add(new Insumo(Convert.ToInt32(fila["idInsumo"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["descripcion"]), Convert.ToInt32(fila["cantidad"]), Convert.ToInt32(fila["cantidadMinima"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idCategoria"])));
                }
            }
            return _listaInsumos;
        }
    }
}
