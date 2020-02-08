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
            if (pPersona == null)
                throw new ArgumentNullException(nameof(pPersona));

            try
            {
                string query = "INSERT INTO \"Persona\"(nombre,contrasena, \"fechaAlta\", \"idGrupo\") VALUES(@nombre,@contrasena,@fechaalta,@idgrupo)";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@nombre", pPersona.Nombre);
                comando.Parameters.AddWithValue("@contrasena", pPersona.Contraseña);
                comando.Parameters.AddWithValue("@fechaalta", pPersona.FechaAlta);
                comando.Parameters.AddWithValue("@idgrupo", pPersona.IdGrupo);

                comando.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al agregar Persona: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al agregar Persona: " + e.Message);
            }
        }

        /// <summary>
        /// Verify the existence of an "Persona" by field "nombre"
        /// </summary>
        /// <param name="pNombre">"nombre" to be checked</param>
        /// <returns></returns>
        public int VerificarNombre(string pNombre)
        {
            string query = "SELECT \"idPersona\" FROM \"Persona\" WHERE \"nombre\" = '" + pNombre + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                
                using NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return Int32.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al verificar el nombre de la persona autorizada: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al verificar el nombre de la persona autorizada: " + e.Message);
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
            string query = "SELECT \"idPersona\" FROM \"Persona\" WHERE \"nombre\" = '" + pNombre + "' and contrasena = '" + pContraseña + "'";
            
            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                using NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return Int32.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al verificar credenciales de la persona autorizada para el retiro: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al verificar credenciales de la persona autorizada para el retiro: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Persona" objects
        /// </summary>
        /// <returns>A list containing objects of class PersonaAutorizada</returns>
        public List<PersonaAutorizada> Listar()
        {
            string query = "SELECT * FROM \"Persona\"";
            List<PersonaAutorizada> _listaPersona = new List<PersonaAutorizada>();

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idPersona"]);
                        int idGrupo = Convert.ToInt32(fila["idGrupo"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (fila["fechaBaja"] != DBNull.Value)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        _listaPersona.Add(new PersonaAutorizada(id, nombre, pass, fechaAlta, fechaBaja, idGrupo, idCreador));
                    }
                    tabla.Dispose();
                }
                return _listaPersona;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al generar lista de personas: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al generar lista de personas: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Persona" objects in a group
        /// </summary>
        /// <param name="pIdGrupo">ID of the group</param>
        /// <returns></returns>
        public List<PersonaAutorizada> Listar(int pIdGrupo)
        {
            string query = "SELECT * FROM \"Persona\" WHERE \"idGrupo\" = '" + pIdGrupo + "'";
            List<PersonaAutorizada> _listaPersona = new List<PersonaAutorizada>();

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idPersona"]);
                        int idGrupo = Convert.ToInt32(fila["idGrupo"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (fila["fechaBaja"] != DBNull.Value)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        _listaPersona.Add(new PersonaAutorizada(id, nombre, pass, fechaAlta, fechaBaja, idGrupo, idCreador));
                    }
                    tabla.Dispose();
                }
                return _listaPersona;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al listar las personas autorizadas: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al listar las personas autorizadas: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Persona" by his ID
        /// </summary>
        /// <param name="pIdPersona">ID to search by</param>
        public PersonaAutorizada Obtener(int idPersona)
        {
            string query = "SELECT * FROM \"Persona\" WHERE \"idPersona\" = '" + idPersona + "'";
            PersonaAutorizada _PersonaRetira = null;

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                
                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idPersona"]);
                        int idGrupo = Convert.ToInt32(fila["idGrupo"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (fila["fechaBaja"] != DBNull.Value)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        _PersonaRetira = new PersonaAutorizada(id, nombre, pass, fechaAlta, fechaBaja, idGrupo, idCreador);
                    }
                    tabla.Dispose();
                }
                return _PersonaRetira;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al obtener la persona autorizada: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al obtener la persona autorizada: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Persona" by his field "nombre"
        /// </summary>
        /// <param name="pNombre">to search by</param>
        public PersonaAutorizada Obtener(string pNombre)
        {
            string query = "SELECT * FROM \"Persona\" WHERE nombre = '" + pNombre + "'";
            PersonaAutorizada _PersonaRetira = null;

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idPersona"]);
                        int idGrupo = Convert.ToInt32(fila["idGrupo"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (fila["fechaBaja"] != DBNull.Value)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        _PersonaRetira = new PersonaAutorizada(id,nombre,pass,fechaAlta,fechaBaja,idGrupo,idCreador);
                    }
                    tabla.Dispose();
                }
                return _PersonaRetira;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar obtener los datos de la persona \"" + pNombre + "\": " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar obtener los datos de la persona \"" + pNombre + "\": " + e.Message);
            }
        }

        /// <summary>
        /// Modify all fields for a "Persona" 
        /// </summary>
        /// <param name="pPersona">Persona with all filled fields</param>
        public void Modificar(PersonaAutorizada pPersona)
        {
            if (pPersona == null)
                throw new ArgumentNullException(nameof(pPersona));

            string query = "UPDATE \"Persona\" SET nombre = @nombre, contrasena = @contrasena, \"fechaBaja\" = @fechaBaja WHERE \"idPersona\" = '" + pPersona.IdPersona + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@nombre", pPersona.Nombre);
                comando.Parameters.AddWithValue("@contrasena", pPersona.Contraseña);
                comando.Parameters.AddWithValue("@fechaBaja", Convert.ToString(pPersona.FechaBaja));
                comando.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Modify a "Persona"s field "nombre". Search by ID
        /// </summary>
        /// <param name="id">ID to match</param>
        /// <param name="nombre">New "nombre" for the finded "id"</param>
        public void ModificarNombre(int id, string nombre)
        {
            string query = "UPDATE \"Persona\" SET nombre = @var WHERE \"idPersona\" = '" + id + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", nombre);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Modify a "Persona"s field "fechaAlta". Search by "nombre"
        /// </summary>
        /// <param name="idPersona">to search by</param>
        /// <param name="fecha">new value to the field "fechaAlta"</param>
        public void ModificarFechaAlta(int idPersona, DateTime fecha)
        {
            string query = "UPDATE \"Persona\" SET \"fechaAlta\" = @var WHERE \"idPersona\" = '" + idPersona + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", fecha);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Modify a "Persona"s field "fechaBaja". Search by "nombre"
        /// </summary>
        /// <param name="idPersona">to search by</param>
        /// <param name="fecha">new value to the field "fechaBaja"</param>
        public void ModificarFechaBaja(int idPersona, DateTime fecha)
        {
            string query = "UPDATE \"Persona\" SET \"fechaBaja\" = @var WHERE \"idPersona\" = '" + idPersona + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", fecha);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Modify the password for a given "Persona"s "nombre"
        /// </summary>
        /// <param name="idPersona">to search by</param>
        /// <param name="pass">new password</param>
        public void ModificarContrasena(int idPersona, string pass)
        {
            string query = "UPDATE \"Persona\" SET contrasena = @var WHERE \"idPersona\" = '" + idPersona + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", pass);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Modify the group for a given "Persona"
        /// </summary>
        /// <param name="idPersona">ID to search by</param>
        /// <param name="idGrupo">new "Grupo"s ID</param>
        public void ModificarGrupo(int idPersona, int idGrupo)
        {
            string query = "UPDATE \"Persona\" SET \"idGrupo\" = @var WHERE \"idPersona\" = '" + idPersona + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@var", idGrupo);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar modificar datos de la persona: " + e.Message);
            }
        }

        /// <summary>
        /// Delete a "Persona" from the database
        /// </summary>
        /// <param name="id">to search by</param>
        public void EliminarPersona(int id)
        {
            string query = "DELETE FROM \"Persona\" WHERE \"idPersona\" = '" + id + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            try
            {
                comando.CommandText = query;
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar eliminar un usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al intentar eliminar un usuario: " + e.Message);
            }
        }
    }
}
