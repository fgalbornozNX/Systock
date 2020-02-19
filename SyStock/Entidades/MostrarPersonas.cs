namespace SyStock.Entidades
{
    public class MostrarPersonas
    {
        public MostrarPersonas(string pNombre, string pGrupo, string pArea)
        {
            Nombre = pNombre;
            Grupo = pGrupo;
            Area = pArea;
        }

        public MostrarPersonas(int pIdPersona, string pNombre, string pGrupo, string pArea)
        {
            IdPersona = pIdPersona;
            Nombre = pNombre;
            Grupo = pGrupo;
            Area = pArea;
        }

        public int IdPersona { get; set; }

        /// <summary>
        /// Nombre de la Persona.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Grupo de la Persona.
        /// </summary>
        public string Grupo { get; set; }

        /// <summary>
        /// Area de la Persona.
        /// </summary>
        public string Area { get; set; }
    }
}
