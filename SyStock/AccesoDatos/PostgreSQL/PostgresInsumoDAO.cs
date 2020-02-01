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
    public class PostgresInsumoDAO : IInsumoDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresInsumoDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Agregar un nuevo insumo
        /// </summary>
        /// <param name="pInsumo">Insumo a agregar</param>
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
        /// Obtener un determinado insumo
        /// </summary>
        /// <param name="pIdCategoria">Id insumo a buscar</param>
        /// <returns></returns>
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
        /// Modificar un insumo
        /// </summary>
        /// <param name="pInsumo">Insumo a modificar</param>
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
        /// Listar los insumos
        /// </summary>
        /// <returns></returns>
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
