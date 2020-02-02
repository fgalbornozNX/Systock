using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Postgresql implementation for Data Access Object "PersonaAutorizada"
    /// </summary>
    public class PostgresPersonaDAO: IPersonaAutorizadaDAO
    {
        /// <summary>
        /// Represent the conecction towards the database
        /// </summary>
        private readonly NpgsqlConnection _conexion;

        public PostgresPersonaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Persona" to the database
        /// </summary>
        /// <param name="pPersona">Persona to be added</param>
        public void Agregar(PersonaAutorizada pPersona)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "INSERT INTO \"Persona\"(nombre,contrasena, \"fechaAlta\", \"fechaBaja\", \"idGrupo\") VALUES(@nombre,@contrasena,@fechaalta,@fechabaja,@idarea)";
            comando.Parameters.AddWithValue("@nombre", pPersona.Nombre);
            comando.Parameters.AddWithValue("@contrasena", pPersona.Contraseña);
            comando.Parameters.AddWithValue("@fechaalta", pPersona.FechaAlta);
            comando.Parameters.AddWithValue("@fechabaja", pPersona.FechaAlta);
            comando.Parameters.AddWithValue("@idarea", pPersona.IdGrupo);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Verify the existence of an "Persona" by field "nombre"
        /// </summary>
        /// <param name="pNombre">"nombre" to be checked</param>
        /// <returns></returns>
        public int VerificarNombre(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();

            comando.CommandText = "SELECT \"idPersona\" FROM \"PersonaRetira\" WHERE \"nombre\" = '" + pNombre + "'";
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
        /// Verify the user credentials in the database
        /// </summary>
        /// <param name="pNombre">"Persona"s name</param>
        /// <param name="pContraseña">password to be checked</param>
        /// <returns>Persona's ID in the database. -1 if error</returns>
        public int Verificar(string pNombre, string pContraseña)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT \"idPersona\" FROM \"Persona\" WHERE \"nombre\" = '" + pNombre + "' and contrasena = '" + pContraseña + "'";
            NpgsqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
                return Int32.Parse(reader[0].ToString());
            else
                return -1;
        }

        /// <summary>
        /// Generate a list of "Persona" objects
        /// </summary>
        /// <returns>A list containing objects of class PersonaAutorizada</returns>
        public List<PersonaAutorizada> Listar()
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Persona\"";

            List<PersonaAutorizada> _listaPersona = new List<PersonaAutorizada>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaPersona.Add(new PersonaAutorizada(Convert.ToInt32(fila["idPersona"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["contrasena"]), Convert.ToDateTime(fila["fechaAlta"]), Convert.ToDateTime(fila["fechaBaja"]), Convert.ToInt32(fila["idArea"])));
                }
            }
            return _listaPersona;
        }

        /// <summary>
        /// Generate a list of "Persona" objects in a group
        /// </summary>
        /// <param name="idGrupo">ID of the group</param>
        /// <returns></returns>
        public List<PersonaAutorizada> Listar(int idGrupo)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Persona\" WHERE \"idGrupo\" = '" + idGrupo + "'";

            List<PersonaAutorizada> _listaPersona = new List<PersonaAutorizada>();

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    _listaPersona.Add(new PersonaAutorizada(Convert.ToInt32(fila["idPersona"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["contrasena"]), Convert.ToDateTime(fila["fechaAlta"]), Convert.ToDateTime(fila["fechaBaja"]), Convert.ToInt32(fila["idGrupo"])));
                }
            }
            return _listaPersona;
        }

        /// <summary>
        /// Obtain an "Persona" by his ID
        /// </summary>
        /// <param name="pIdPersona">ID to search by</param>
        public PersonaAutorizada Obtener(int idPersona)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Persona\" WHERE \"idPersona\" = '" + idPersona + "'";
            PersonaAutorizada _PersonaRetira = new PersonaAutorizada(0, "", "", DateTime.Today, DateTime.Today, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _PersonaRetira = new PersonaAutorizada(Convert.ToInt32(fila["idPersona"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["contrasena"]), Convert.ToDateTime(fila["fechaAlta"]), Convert.ToDateTime(fila["fechaBaja"]), Convert.ToInt32(fila["idGrupo"]));
                }
            }
            return _PersonaRetira;
        }

        /// <summary>
        /// Obtain an "Persona" by his field "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        public PersonaAutorizada Obtener(string pNombre)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM \"Persona\" WHERE nombre = '" + pNombre + "'";
            PersonaAutorizada _PersonaRetira = new PersonaAutorizada(0, "", "", DateTime.Today, DateTime.Today, 0);

            using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    _PersonaRetira = new PersonaAutorizada(Convert.ToInt32(fila["idPersona"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["contrasena"]), Convert.ToDateTime(fila["fechaAlta"]), Convert.ToDateTime(fila["fechaBaja"]), Convert.ToInt32(fila["idGrupo"]));
                }
            }
            return _PersonaRetira;
        }

        /// <summary>
        /// Modify all fields for a "Persona" 
        /// </summary>
        /// <param name="pPersona">Persona with all filled fields</param>
        public void Modificar(PersonaAutorizada pPersona)
        {
            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Persona\" SET nombre = @nombre, contrasena = @contrasena, \"fechaBaja\" = @fechaBaja WHERE \"idPersona\" = '" + pPersona.IdPersona + "'";

            comando.Parameters.AddWithValue("@nombre", pPersona.Nombre);
            comando.Parameters.AddWithValue("@contrasena", pPersona.Contraseña);
            comando.Parameters.AddWithValue("@fechaBaja", Convert.ToString(pPersona.FechaBaja));
            comando.ExecuteNonQuery();
        }
    }
}
