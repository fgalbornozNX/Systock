using Npgsql;
using System.Data;

namespace SyStock.AccesoDatos.PostgreSQL
{
    /// <summary>
    /// Implementation of DAOFactory for postgreSQL
    /// </summary>
    public class PostgresDAOFactory : DAOFactory
    {
        /// <summary>
        /// Define the connection atributes to access the database
        /// </summary>
        private const string STRING_CONEXION = "Host=localhost; Port=5432; Database=systock; User ID=postgres; Password=q3w2e1";

        private readonly NpgsqlConnection _conexion = null;
        private NpgsqlTransaction _transaction = null;

        private PostgresUsuarioDAO _usuarioDAO;
        private PostgresAreaDAO _areaDAO;
        private PostgresCategoriaDAO _categoriaDAO;
        private PostgresEntregaDAO _entregaDAO;
        private PostgresGrupoDAO _grupoDAO;
        private PostgresInsumoDAO _insumoDAO;
        private PostgresPersonaDAO _personaDAO;
        private PostgresRenglonDAO _renglonDAO;

        /// <summary>
        /// Set the conection atributes
        /// </summary>
        public PostgresDAOFactory()
        {
            //string _miIP = GetLocalIPv4();
            _conexion = new NpgsqlConnection(STRING_CONEXION);
        }

        // Conexión no-local, para revisar luego
        /*
        public string GetLocalIPv4()
        {
            string hostname = "";
            IPAddress[] ips;
            string _ip = "";

            hostname = Dns.GetHostName();
            ips = Dns.GetHostAddresses(hostname);
            _ip = ips[1].ToString();
            return _ip;
        }
        */

        /// <summary>
        /// Singleton. Return always the same UsuarioDAO objetct
        /// </summary>
        public override IUsuarioDAO UsuarioDAO
        {
            get { if (_usuarioDAO == null)
                  _usuarioDAO = new PostgresUsuarioDAO(_conexion);
                return _usuarioDAO; 
            }
        }

        /// <summary>
        /// Singleton. Return always the same CategoriaDAO objetct
        /// </summary>
        public override ICategoriaDAO CategoriaDAO
        {
            get { if (_categoriaDAO == null)
                    _categoriaDAO = new PostgresCategoriaDAO(_conexion);
                 return _categoriaDAO; 
            }
        }

        /// <summary>
        /// Singleton. Return always the same InsumoDAO objetct
        /// </summary>
        public override IInsumoDAO InsumoDAO
        {
            get { if (_insumoDAO == null)
                    _insumoDAO = new PostgresInsumoDAO(_conexion);
                return _insumoDAO;
            }
        }

        /// <summary>
        /// Singleton. Return always the same AreaDAO objetct
        /// </summary>
        public override IAreaDAO AreaDAO
        {
            get { if (_areaDAO == null)
                    _areaDAO = new PostgresAreaDAO(_conexion);
                return _areaDAO;
            }
        }

        /// <summary>
        /// Singleton. Return always the same GrupoDAO objetct
        /// </summary>
        public override IGrupoDAO GrupoDAO
        {
            get { if (_grupoDAO == null)
                    _grupoDAO = new PostgresGrupoDAO(_conexion);
                return _grupoDAO;
            }
        }

        /// <summary>
        /// Singleton. Return always the same PersonaDAO objetct
        /// </summary>
        public override IPersonaAutorizadaDAO PersonaAutorizadaDAO
        {
            get { if (_personaDAO == null)
                    _personaDAO = new PostgresPersonaDAO(_conexion);
                return _personaDAO;
            }
        }

        /// <summary>
        /// Singleton. Return always the same EntregaDAO object
        /// </summary>
        public override IEntregaDAO EntregaDAO
        {
            get { if (_entregaDAO == null)
                    _entregaDAO = new PostgresEntregaDAO(_conexion);
                return _entregaDAO;
            }
        }

        /// <summary>
        /// Singleton. Return always the same RenglonDAO object
        /// </summary>
        public override IRenglonDAO RenglonDAO
        {
            get { if (_renglonDAO == null)
                    _renglonDAO = new PostgresRenglonDAO(_conexion);
                return _renglonDAO;
            }
        }

        /// <summary>
        /// Begins a connection towards the database
        /// </summary>
        /// <returns>True if the connection is open, false otherwise</returns>
        public override bool IniciarConexion()
        {
            if (this._conexion.State != ConnectionState.Open)
                this._conexion.Open();

            return (this._conexion.State == ConnectionState.Open);
        }

        /// <summary>
        /// Ends the current connection with the database
        /// </summary>
        /// <returns>True if the connection is closed, false otherwise</returns>
        public override bool FinalizarConexion()
        {
            if (this._conexion.State == ConnectionState.Open)
                this._conexion.Close();

            return (this._conexion.State == ConnectionState.Closed);
        }

        /// <summary>
        /// Begins a transaction
        /// </summary>
        public override void IniciarTransaccion()
        {
            if (_conexion == null)
            {
                throw new DAOException("No se puede iniciar una transacción sin una conexión abierta");
            }

            _transaction = _conexion.BeginTransaction();
        }

        /// <summary>
        /// Commits a transaction
        /// </summary>
        public override void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        /// <summary>
        /// Revert the last transaction
        /// </summary>
        public override void RollBack()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
    }
}