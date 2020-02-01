namespace SyStock.Entidades
{
    public class Area
    {
        public Area(string pNombre)
        {
            Nombre = pNombre;
        }

        public Area(int pIdArea, string pNombre)
        {
            IdArea = pIdArea;
            Nombre = pNombre;
        }

        public int IdArea { get; }

        public string Nombre { get; set; }
    }
}
