using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SyStock.AccesoDatos;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    public class PostgresPersonaDAO: IPersonaAutorizadaDAO
    {
        /// <summary>
        /// Conexión con la Base de Datos
        /// </summary>
        private readonly NpgsqlConnection _conexion;

        /// <summary>
        /// Conecta a la base de datos con los usuarios
        /// </summary>
        /// <param name="pConexion"></param>
        public PostgresPersonaDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Permite agregar un nuevo usuario
        /// </summary>
        /// <param name="pUsuario">Datos del usuario</param>
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
        /// Verificar si el nombre de la persona ya existe
        /// </summary>
        /// <param name="pNombre">Nombre de la persona</param>
        /// <returns>Devuelve el ID si existe, -1 si esta disponible</returns>
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
        /// Verifica si el usuario y contraseña coinciden
        /// </summary>
        /// <returns> ID de usuario, devuelve -1 si no lo encuentra</returns>
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
        /// Listar Personas
        /// </summary>
        /// <returns>Lista de Personas</returns>
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
        /// Listar Personas
        /// </summary>
        /// <param name="idGrupo">ID del Grupo a listar</param>
        /// <returns>Lista de Personas en un grupo</returns>
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
        /// Obtener una determinada Persona
        /// </summary>
        /// <param name="idPersona">ID de la Persona</param>
        /// <returns>Devuelve la Persona encontrada, si ID == 0 es null</returns>
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
        /// Obtener una determinada persona
        /// </summary>
        /// <param name="pNombre">Nombre de la persona</param>
        /// <returns>Devuelve la Persona encontrada, si ID == 0 es null</returns>
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
        /// Modificar datos persona
        /// </summary>
        /// <param name="pPersona">Persona a modificar</param>
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
