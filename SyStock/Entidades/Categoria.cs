namespace SyStock.Entidades
{
    public class Categoria
    {
        public Categoria(string pNombre, bool pEstado, int pIdUsuario)
        {
            Nombre = pNombre;
            Estado = pEstado;
            IdUsuario = pIdUsuario;
        }

        public Categoria(int pIdCategoria, string pNombre, bool pEstado, int pIdUsuario)
        {
            IdCategoria = pIdCategoria;
            Nombre = pNombre;
            Estado = pEstado;
            IdUsuario = pIdUsuario;
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int IdUsuario { get; set; }
    }
}
