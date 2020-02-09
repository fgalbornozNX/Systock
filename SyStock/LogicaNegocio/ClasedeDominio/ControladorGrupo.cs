using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorGrupo
    {
        /// <summary>
        /// Método para agregar un grupo
        /// </summary>
        /// <param name="pGrupo">Grupo a agregar</param>
        /// <returns>Devuelve -1 si agregó el Grupo. sino el valor del Id del grupo ya existente</returns>
        public static int Agregar(Grupo pGrupo)
        {
            if ((pGrupo == null) || (pGrupo.IdArea < 1))
                throw new ArgumentNullException(nameof(pGrupo));

            DAOFactory factory = DAOFactory.Instancia();
            int idGrupo = -1;

            try
            {
                factory.IniciarConexion();
                List<Grupo> listaGrupos = factory.GrupoDAO.Listar(pGrupo.IdArea);
                factory.FinalizarConexion();

                for (int i = 0; i < listaGrupos.Count; i++)
                {
                    if (listaGrupos[i].Nombre.ToUpper() == pGrupo.Nombre.ToUpper())
                    {
                        idGrupo = listaGrupos[i].IdGrupo;
                    }
                }

                if (idGrupo == -1)
                {
                    factory.IniciarConexion();
                    factory.GrupoDAO.Agregar(pGrupo);
                    factory.FinalizarConexion();
                }
                return idGrupo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para modificar un grupo
        /// </summary>
        /// <param name="pGrupo">Grupo a modificar</param>
        /// <returns>Devuelve true si logró modificarlo</returns>
        public static bool Modificar(Grupo pGrupo)
        {
            if ((pGrupo == null) || (pGrupo.IdArea < 1))
                throw new ArgumentNullException(nameof(pGrupo));

            DAOFactory factory = DAOFactory.Instancia();
            int idGrupo = -1;
            string nombre = string.Empty;

            try
            {
                factory.IniciarConexion();
                List<Grupo> listaGrupos = factory.GrupoDAO.Listar(pGrupo.IdArea);
                factory.FinalizarConexion();

                for (int i = 0; i < listaGrupos.Count; i++)
                {
                    if ((listaGrupos[i].Nombre.ToUpper() == pGrupo.Nombre.ToUpper()) && (listaGrupos[i].IdGrupo != pGrupo.IdGrupo))
                    {
                        idGrupo = listaGrupos[i].IdGrupo;
                        nombre = listaGrupos[i].Nombre;
                    }
                }
                
                if (((idGrupo == -1) && (idGrupo != pGrupo.IdGrupo)) || ((nombre != pGrupo.Nombre) && (idGrupo == pGrupo.IdArea)))
                {
                    factory.IniciarConexion();
                    factory.GrupoDAO.Modificar(pGrupo);
                    factory.FinalizarConexion();

                    return true;
                }
                else
                {
                    if (idGrupo == pGrupo.IdGrupo)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }

            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public static List<Grupo> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Grupo> listaGrupo = factory.GrupoDAO.Listar();
                factory.FinalizarConexion();

                return listaGrupo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <param name="idArea">Id del Área de os grupos a listar</param>
        /// <returns>Lista de grupos para una determinada Área</returns>
        public static List<Grupo> Listar(int idArea)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Grupo> _listaGrupo = factory.GrupoDAO.Listar(idArea);
                factory.FinalizarConexion();

                return _listaGrupo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para obtener un grupo dependiendo del nombre
        /// </summary>
        /// <param name="pNombre">Nombre del grupo</param>
        /// <returns>Devuelve el grupo. Null si no lo encontró</returns>
        public static Grupo Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Grupo grupo = factory.GrupoDAO.Obtener(pNombre);
                factory.FinalizarConexion();

                return grupo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para obtener un grupo dependiendo del ID
        /// </summary>
        /// <param name="pId">ID del grupo</param>
        /// <returns>Devuelve el grupo. Null si no lo encontró</returns>
        public static Grupo Obtener(int pId)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Grupo grupo = factory.GrupoDAO.Obtener(pId);
                factory.FinalizarConexion();

                return grupo;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }
    }
}
