using System;
using System.Collections.Generic;
using Npgsql;
using SyStock.Entidades;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Implementation of IUsuarioDAO for postgreSQL engine
    /// </summary>
    public class PostgresUsuarioDAO : IUsuarioDAO
    {
        /// <summary>
        /// Represents the connection with the database
        /// </summary>
        private readonly NpgsqlConnection _conexion;

        /// <summary>
        /// Constructor for PostgresUsuarioDAO
        /// </summary>
        /// <param name="pConexion">The connection to the database</param>
        public PostgresUsuarioDAO(NpgsqlConnection pConexion)
        {
            _conexion = pConexion;
        }

        /// <summary>
        /// Allows add a new "Usuario" to the database
        /// </summary>
        /// <param name="pUsuario">Usuario to be added</param>
        public void Agregar(Usuario pUsuario)
        {
            if (pUsuario == null)
                throw new ArgumentNullException(nameof(pUsuario));

            try
            {
                string query = "INSERT INTO \"Usuario\" (nombre,contrasena, \"fechaAlta\", \"idCreadoPor\") VALUES (@nombre,@contrasena,@fechaalta,@idadmin)";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@nombre", pUsuario.Nombre);
                comando.Parameters.AddWithValue("@contrasena", pUsuario.Contraseña);
                comando.Parameters.AddWithValue("@fechaalta", pUsuario.FechaAlta);
                comando.Parameters.AddWithValue("@idadmin", pUsuario.IdUsuarioAdmin);

                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al agregar usuario: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al agregar usuario: " + e.Message);
            }
        }


        /// <summary>
        /// Verify the existence of an "Usuario" in the database by the field "nombre"
        /// </summary>
        /// <param name="pNombre">"nombre" for the datatable "Usuario"</param>
        /// <returns>ID of "Usuario" if exists, -1 if not</returns>
        public int VerificarNombre(string pNombre)
        {
            try
            {
                string query = "SELECT \"idUsuario\" FROM \"Usuario\" WHERE nombre = '" + pNombre + "'";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return int.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al verificar la existencia del usuario \""+ pNombre +"\": " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al verificar la existencia del usuario \"" + pNombre + "\": " + e.Message);
            }
        }

        /// <summary>
        /// Checks the username and password for an existing "Usuario" in the database
        /// </summary>
        /// <returns>Usuario object with filled fields</returns>
        public int Verificar(string pNombre, string pContrasena)
        {
            try
            {
                string query = "SELECT \"idUsuario\" FROM \"Usuario\" WHERE nombre = '" + pNombre + "' and contrasena = '" + pContrasena + "'";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                comando.CommandText = query;
                NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    return int.Parse(reader[0].ToString());
                else
                    return -1;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al verificar el usuario \"" + pNombre + "\": " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al verificar el usuario \"" + pNombre + "\": " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Usuario" objects
        /// </summary>
        /// <returns>A list containing objects of classs Usuario</returns>
        public List<Usuario> Listar()
        {
            try
            {
                string query = "SELECT * FROM \"Usuario\"";
                List<Usuario> _listaUsuario = new List<Usuario>();

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idUsuario"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (Convert.ToDateTime(fila["fechaBaja"]) != null)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        _listaUsuario.Add(new Usuario(id,nombre,pass,fechaAlta,fechaBaja,idCreador));
                    }
                    tabla.Dispose();
                }
                return _listaUsuario;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al listar usuarios: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al listar usuarios: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Usuario" by his ID
        /// </summary>
        /// <param name="idUsuario">"Usuario"s ID</param>
        /// <returns></returns>
        public Usuario Obtener(int idUsuario)
        {
            try
            {
                string query = "SELECT * FROM \"Usuario\" WHERE \"idUsuario\" = '" + idUsuario + "'";

                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;
                Usuario usuario = null;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idUsuario"]);
                        string nombre = Convert.ToString(fila["nombre"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (fila["fechaBaja"] != DBNull.Value) // This!
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        usuario = new Usuario(id, nombre, pass, fechaAlta, fechaBaja, idCreador);
                    }
                    tabla.Dispose();
                }
                return usuario;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al obtener el usuario con ID " + idUsuario + ": " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al obtener el usuario con ID " + idUsuario + ": " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Usuario" by the field "nombre"
        /// </summary>
        /// <param name="nombre">Field "nombre" to search</param>
        /// <returns></returns>
        public Usuario Obtener(string nombre)
        {
            try
            {
                string query = "SELECT * FROM \"Usuario\" WHERE nombre = '" + nombre + "'";
                Usuario usuario = null;

                using (NpgsqlCommand comando = this._conexion.CreateCommand())
                {
                    comando.CommandText = query;
                    using NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["idUsuario"]);
                        string pass = Convert.ToString(fila["contrasena"]);
                        DateTime fechaAlta = Convert.ToDateTime(fila["fechaAlta"]);
                        DateTime fechaBaja = DateTime.MinValue;
                        if (Convert.ToDateTime(fila["fechaBaja"]) != null)
                            fechaBaja = Convert.ToDateTime(fila["fechaBaja"]);
                        int idCreador = Convert.ToInt32(fila["idCreadoPor"]);

                        usuario = new Usuario(id, nombre, pass, fechaAlta, fechaBaja, idCreador);
                    }
                    tabla.Dispose();
                }
                return usuario;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al obtener el usuario con ID " + nombre + ": " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al obtener el usuario con ID " + nombre + ": " + e.Message);
            }
        }

        #region public void Modificar(Usuario usuario) [Deprecated]
        /*
        public void Modificar(Usuario usuario)
        {
            string query = "UPDATE \"Usuario\" SET contrasena";

            NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = "UPDATE \"Usuario\" SET contrasena = @contrasena, \"fechaBaja\" = @fechaBaja WHERE \"idUsuario\" = '" + pUsuario.IdUsuario + "'";

            comando.Parameters.AddWithValue("@contrasena", pUsuario.Contraseña);
            comando.Parameters.AddWithValue("@fechaBaja", Convert.ToString(pUsuario.FechaBaja));
            comando.ExecuteNonQuery();
        }
        */
        #endregion

        /// <summary>
        /// Modify an "Usuario"s field "nombre". Search by ID
        /// </summary>
        /// <param name="id">ID to match</param>
        /// <param name="nombre">New "nombre" for the finded "id"</param>
        public void ModificarNombre(int id, string nombre)
        {
            string query = "UPDATE \"Usuario\" SET nombre = @var WHERE \"idUsuario\" = '" + id + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", nombre);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar nombre de usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar nombre de usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Modify an "Usuario"s field "nombre". Search by previous "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="nuevoNombre">new value for the field "nombre"</param>
        public void ModificarNombre(string nombre, string nuevoNombre)
        {
            string query = "UPDATE \"Usuario\" SET nombre = @var WHERE nombre = '" + nombre + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", nuevoNombre);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar nombre de usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar nombre de usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Modify an "Usuario"s field "fechaAlta". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="fecha">new value to the field "fechaAlta"</param>
        public void ModificarFechaAlta(string nombre, DateTime fecha)
        {
            string query = "UPDATE \"Usuario\" SET \"fechaAlta\" = @var WHERE nombre = '" + nombre + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", fecha);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar fecha de alta de usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar fecha de alta de usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Modify an "Usuario"s field "fechaBaja". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="fecha">new value to the field "fechaBaja"</param>
        public void ModificarFechaBaja(string nombre, DateTime fecha)
        {
            string query = "UPDATE \"Usuario\" SET \"fechaBaja\" = @var WHERE nombre = '" + nombre + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", fecha);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar fecha de baja de usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar fecha de baja de usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Modify an "Usuario"s field "idUsuario". Search by "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="id">new value to field "idUsuario"</param>
        public void ModificarIdUsuario(string nombre, int id)
        {
            string query = "UPDATE \"Usuario\" SET \"idUsuario\" = @var WHERE nombre = '" + nombre + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", id);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar ID de usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar ID de usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Modify the password for a given "Usuario"s "nombre"
        /// </summary>
        /// <param name="nombre">to search by</param>
        /// <param name="pass">new password</param>
        public void ModificarContrasena(string nombre, string pass)
        {
            string query = "UPDATE \"Usuario\" SET contrasena = @var WHERE nombre = '" + nombre + "'";

            using NpgsqlCommand comando = this._conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@var", pass);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar la contraseña del usuario: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al modificar la contraseña del usuario: " + e.Message);
            }
        }

        /// <summary>
        /// Delete an "Usuario" from the database
        /// </summary>
        /// <param name="nombre">to search by</param>
        public void EliminarUsuario(string nombre)
        {
            string query = "DELETE FROM \"Usuario\" WHERE nombre = '" + nombre + "'";

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

        /// <summary>
        /// Delete an "Usuario" from the database
        /// </summary>
        /// <param name="id">to search by</param>
        public void EliminarUsuario(int id)
        {
            string query = "DELETE FROM \"Usuario\" WHERE \"idUsuario\" = '" + id + "'";

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
