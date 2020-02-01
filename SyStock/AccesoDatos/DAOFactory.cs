using SyStock.AccesoDatos.PostgreSQL;

namespace SyStock.AccesoDatos
{
    /// <summary>
    /// Data Access Objects Factory
    /// </summary>
    public abstract class DAOFactory
    {
        /// <summary>
        /// Singleton. An instance of DAOFactory
        /// </summary>
        private static DAOFactory _instancia = null;
        
        public static DAOFactory Instancia()
        {
            if (_instancia == null)
                _instancia = new PostgresDAOFactory(); // This can be easily modified to use another database engine. In this case we use PostgreSQL
            return _instancia;
        }

        #region Abstract methods

        public abstract IUsuarioDAO UsuarioDAO { get; }
        public abstract ICategoriaDAO CategoriaDAO { get; }
        public abstract IInsumoDAO InsumoDAO { get; }
        public abstract IAreaDAO AreaDAO { get; }
        public abstract IGrupoDAO GrupoDAO { get; }
        public abstract IPersonaAutorizadaDAO PersonaAutorizadaDAO { get; }
        public abstract IEntregaDAO EntregaDAO { get; }
        public abstract IRenglonDAO RenglonDAO { get; }

        public abstract bool IniciarConexion();
        public abstract bool FinalizarConexion();
        public abstract void IniciarTransaccion();
        public abstract void Commit();
        public abstract void RollBack();

        #endregion
    }
}