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
    public class PostgresEntregaDAO : IEntregaDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresEntregaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        public void Agregar(EntregaInsumos pEntrega)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Entrega\"(\"idUsuario\", \"idPersona\", fecha) VALUES(@usuario, @persona, @fecha)";
            comando.Parameters.AddWithValue("@usuario", pEntrega.IdUsuario);
            comando.Parameters.AddWithValue("@persona", pEntrega.IdPersona);
            comando.Parameters.AddWithValue("@fecha", pEntrega.Fecha.ToString());
            Console.WriteLine(pEntrega.IdUsuario + pEntrega.IdPersona + pEntrega.Fecha.ToString());
            comando.ExecuteNonQuery();
        }

        public EntregaInsumos Obtener(int pIdEntrega)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Entrega\" WHERE \"idEntrega\" = '" + pIdEntrega + "'";
            EntregaInsumos _entrega = new EntregaInsumos(0, 0, DateTime.Today);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _entrega = new EntregaInsumos(Convert.ToInt32(fila["idEntrega"]), Convert.ToInt32(fila["idUsuario"]), Convert.ToInt32(fila["idPersonaRetira"]), Convert.ToDateTime(fila["fecha"]));
                }
            }
            return _entrega;
        }

        public List<EntregaInsumos> Listar()
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Entrega\"";

            List<EntregaInsumos> _listaEntrega = new List<EntregaInsumos>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaEntrega.Add(new EntregaInsumos(Convert.ToInt32(fila["idEntrega"]), Convert.ToInt32(fila["idUsuario"]), Convert.ToInt32(fila["idPersonaRetira"]), Convert.ToDateTime(fila["fecha"])));
                }
            }
            return _listaEntrega;
        }
    }
}
