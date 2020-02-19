namespace SyStock.Entidades
{
    public class Grupo
    {
        public Grupo(string pNombre, bool pEstado, int pIdArea, int pIdUsuario)
        {
            Nombre = pNombre;
            Estado = pEstado;
            IdArea = pIdArea;
            IdUsuario = pIdUsuario;
        }

        public Grupo(int pIdGrupo, string pNombre, bool pEstado, int pIdArea, int pIdUsuario)
        {
            IdGrupo = pIdGrupo;
            Nombre = pNombre;
            Estado = pEstado;
            IdArea = pIdArea;
            IdUsuario = pIdUsuario;
        }

        public int IdGrupo { get; private set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int IdArea { get; set; }

        public int IdUsuario { get; set; }
    }
}
