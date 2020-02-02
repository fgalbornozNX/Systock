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
    /// <summary>
    /// Postgresql implementation for Data Access Object "Grupo"
    /// </summary>
    public class PostgresGrupoDAO: IGrupoDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresGrupoDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Grupo" to the database
        /// </summary>
        /// <param name="pGrupo">Grupo to be added</param>
        public void Agregar(Grupo pGrupo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Grupo\"(nombre, estado, \"idArea\", \"idUsuario\") VALUES(@nombre, @estado, @idArea, @idUsuario)";
            comando.Parameters.AddWithValue("@nombre", pGrupo.Nombre);
            comando.Parameters.AddWithValue("@estado", pGrupo.Estado);
            comando.Parameters.AddWithValue("@idArea", pGrupo.IdArea);
            comando.Parameters.AddWithValue("@idUsuario", pGrupo.IdUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Verify the existence of a "Grupo" in an "Area"
        /// </summary>
        /// <param name="pNombre">Grupo's name to search by</param>
        /// <param name="idArea">Area's ID</param>
        /// <returns></returns>
        public int VerificarNombre(string pNombre, int pIdArea)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "SELECT \"idGrupo\" FROM \"Grupo\" WHERE nombre = '" + pNombre + "' and \"idArea\" = '" + pIdArea + "'";
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
        /// Obtain an "Grupo" by his ID
        /// </summary>
        /// <param name="pIdGrupo">ID to search by</param>
        public Grupo Obtener(int pIdGrupo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Grupo\" WHERE \"idGrupo\" = '" + pIdGrupo + "'";
            Grupo _grupo = new Grupo("",true,0,0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _grupo = new Grupo(Convert.ToInt32(fila["idGrupo"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idArea"]), Convert.ToInt32(fila["idUsuario"]));
                }
            }
            return _grupo;
        }

        /// <summary>
        /// Obtain an "Grupo" by his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public Grupo Obtener(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Grupo\" WHERE nombre = '" + pNombre + "'";
            Grupo _grupo = new Grupo("",true,0,0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _grupo = new Grupo(Convert.ToInt32(fila["idGrupo"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idArea"]), Convert.ToInt32(fila["idUsuario"]));
                }
            }
            return _grupo;
        }

        /// <summary>
        /// Modify all fields of an "Grupo"
        /// </summary>
        /// <param name="pGrupo">Grupo object with all filled fields</param>
        public void Modificar(Grupo pGrupo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Grupo\" SET nombre = @nombre WHERE \"idGrupo\" = '" + pGrupo.IdGrupo + "'";

            comando.Parameters.AddWithValue("@nombre", pGrupo.Nombre);
            comando.Parameters.AddWithValue("@estado", pGrupo.Estado);
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Generate a list of "Grupo" objects
        /// </summary>
        /// <returns>A list containing objects of class Grupo</returns>
        public List<Grupo> Listar()
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Grupo\"";

            List<Grupo> _listaGrupo = new List<Grupo>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaGrupo.Add(new Grupo(Convert.ToInt32(fila["idGrupo"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idArea"]), Convert.ToInt32(fila["idUsuario"])));
                }
            }
            return _listaGrupo;
        }

        /// <summary>
        /// Generate a list of "Grupo" objects in an "Area"
        /// </summary>
        /// <param name="idArea">Area's ID to match the search</param>
        /// <returns>A list containing all matching objects</returns>
        public List<Grupo> Listar(int idArea)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Grupo\" WHERE \"idArea\" = '" + idArea + "'";

            List<Grupo> _listaGrupo = new List<Grupo>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaGrupo.Add(new Grupo(Convert.ToInt32(fila["idGrupo"]), Convert.ToString(fila["nombre"]), Convert.ToBoolean(fila["estado"]), Convert.ToInt32(fila["idArea"]), Convert.ToInt32(fila["idUsuario"])));
                }
            }
            return _listaGrupo;
        }
    }
}
