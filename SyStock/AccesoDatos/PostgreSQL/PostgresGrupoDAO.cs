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
    public class PostgresGrupoDAO: IGrupoDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresGrupoDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

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

        public void Modificar(Grupo pGrupo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Grupo\" SET nombre = @nombre WHERE \"idGrupo\" = '" + pGrupo.IdGrupo + "'";

            comando.Parameters.AddWithValue("@nombre", pGrupo.Nombre);
            comando.Parameters.AddWithValue("@estado", pGrupo.Estado);
            comando.ExecuteNonQuery();
        }

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
