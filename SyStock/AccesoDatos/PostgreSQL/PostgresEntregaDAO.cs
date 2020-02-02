using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "Entrega"
    /// </summary>
    public class PostgresEntregaDAO : IEntregaDAO
    {
        private readonly NpgsqlConnection _conexion;

        public PostgresEntregaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Entrega" to the database
        /// </summary>
        /// <param name="pEntrega">Entrega to be added</param>
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

        /// <summary>
        /// Obtain an "Engtrega" by his ID
        /// </summary>
        /// <param name="pIdEntrega">ID to search by</param>
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

        /// <summary>
        /// Generate a list of EntregaInsumos objects
        /// </summary>
        /// <returns>A list containing all EntregaInsumos objects</returns>
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
