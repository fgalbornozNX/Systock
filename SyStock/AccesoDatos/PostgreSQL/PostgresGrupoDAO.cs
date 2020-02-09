using System;
using System.Collections.Generic;
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
            if (pGrupo == null)
                throw new ArgumentNullException(nameof(pGrupo));

            string query = "INSERT INTO \"Grupo\"(nombre, estado, \"idArea\", \"idUsuario\") VALUES (@nombre, @estado, @idArea, @idUsuario)";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                comando.Parameters.AddWithValue("@nombre", pGrupo.Nombre);
                comando.Parameters.AddWithValue("@estado", pGrupo.Estado);
                comando.Parameters.AddWithValue("@idArea", pGrupo.IdArea);
                comando.Parameters.AddWithValue("@idUsuario", pGrupo.IdUsuario);

                comando.ExecuteNonQuery();
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al agregar un nuevo grupo: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al agregar un nuevo grupo: " + e.Message);
            }
        }

        /// <summary>
        /// Verify the existence of a "Grupo" in an "Area"
        /// </summary>
        /// <param name="pNombre">Grupo's name to search by</param>
        /// <param name="idArea">Area's ID</param>
        /// <returns></returns>
        public int VerificarNombre(string pNombre, int pIdArea)
        {
            string query = "SELECT \"idGrupo\" FROM \"Grupo\" WHERE nombre = '" + pNombre + "' and \"idArea\" = '" + pIdArea + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();

                comando.CommandText = query;
                using (NpgsqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                        return Int32.Parse(reader[0].ToString());
                    else
                        return -1;
                }
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al verificar el nombre de grupo: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al verificar el nombre de grupo: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Grupo" by his ID
        /// </summary>
        /// <param name="pIdGrupo">ID to search by</param>
        public Grupo Obtener(int pIdGrupo)
        {
            string query = "SELECT * FROM \"Grupo\" WHERE \"idGrupo\" = '" + pIdGrupo + "'";
            Grupo grupo = null;

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
                        int _id = Convert.ToInt32(fila["idGrupo"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        int _idArea = Convert.ToInt32(fila["idArea"]);
                        int _idUsuario = Convert.ToInt32(fila["idUsuario"]);

                        grupo = new Grupo(_id, _nombre, _estado, _idArea, _idUsuario);
                    }
                    tabla.Dispose();
                }
                return grupo;
            }
            catch(PostgresException e)
            {
                throw new DAOException("Error al intentar obtener el grupo de la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar obtener el grupo de la base de datos: " + e.Message);
            }
        }

        /// <summary>
        /// Obtain an "Grupo" by his name
        /// </summary>
        /// <param name="pNombre">name to search by</param>
        public Grupo Obtener(string pNombre)
        {
            string query = "SELECT * FROM \"Grupo\" WHERE nombre = '" + pNombre + "'";
            Grupo grupo = null;

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
                        int _id = Convert.ToInt32(fila["idGrupo"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        int _idArea = Convert.ToInt32(fila["idArea"]);
                        int _idUsuario = Convert.ToInt32(fila["idUsuario"]);

                        grupo = new Grupo(_id, _nombre, _estado, _idArea, _idUsuario);
                    }
                    tabla.Dispose();
                }
                return grupo;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al intentar obtener el grupo de la base de datos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al intentar obtener el grupo de la base de datos: " + e.Message);
            }
        }

        /// <summary>
        /// Modify all fields of an "Grupo"
        /// </summary>
        /// <param name="pGrupo">Grupo object with all filled fields</param>
        public void Modificar(Grupo pGrupo)
        {
            if (pGrupo == null)
                throw new ArgumentNullException(nameof(pGrupo));

            string query = "UPDATE \"Grupo\" SET nombre = @nombre WHERE \"idGrupo\" = '" + pGrupo.IdGrupo + "'";

            try
            {
                using NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                comando.Parameters.AddWithValue("@nombre", pGrupo.Nombre);
                comando.Parameters.AddWithValue("@estado", pGrupo.Estado);
                comando.ExecuteNonQuery();
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al modificar grupo: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al modificar grupo: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Grupo" objects
        /// </summary>
        /// <returns>A list containing objects of class Grupo</returns>
        public List<Grupo> Listar()
        {
            string query = "SELECT * FROM \"Grupo\"";
            List<Grupo> listaGrupo = new List<Grupo>();

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
                        int _id = Convert.ToInt32(fila["idGrupo"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        int _idArea = Convert.ToInt32(fila["idArea"]);
                        int _idUsuario = Convert.ToInt32(fila["idUsuario"]);

                        listaGrupo.Add(new Grupo(_id,_nombre,_estado,_idArea,_idUsuario));
                    }
                    tabla.Dispose();
                }
                return listaGrupo;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar grupos: " + e.Message);
            }
            catch (NpgsqlException e)
            {
                throw new DAOException("Error al listar grupos: " + e.Message);
            }
        }

        /// <summary>
        /// Generate a list of "Grupo" objects in an "Area"
        /// </summary>
        /// <param name="idArea">Area's ID to match the search</param>
        /// <returns>A list containing all matching objects</returns>
        public List<Grupo> Listar(int idArea)
        {
            string query = "SELECT * FROM \"Grupo\" WHERE \"idArea\" = '" + idArea + "'";
            List<Grupo> listaGrupo = new List<Grupo>();

            try
            {
                NpgsqlCommand comando = this._conexion.CreateCommand();
                comando.CommandText = query;

                using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int _id = Convert.ToInt32(fila["idGrupo"]);
                        string _nombre = Convert.ToString(fila["nombre"]);
                        bool _estado = Convert.ToBoolean(fila["estado"]);
                        int _idArea = Convert.ToInt32(fila["idArea"]);
                        int _idUsuario = Convert.ToInt32(fila["idUsuario"]);

                        listaGrupo.Add(new Grupo(_id, _nombre, _estado, _idArea, _idUsuario));
                    }
                    tabla.Dispose();
                }
                return listaGrupo;
            }
            catch (PostgresException e)
            {
                throw new DAOException("Error al listar grupos: " + e.Message);
            }
            catch(NpgsqlException e)
            {
                throw new DAOException("Error al listar grupos: " + e.Message);
            }
        }
    }
}
