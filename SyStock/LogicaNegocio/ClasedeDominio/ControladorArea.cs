using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorArea
    {
        /// <summary>
        /// Método para agregar un área
        /// </summary>
        /// <param name="pArea">Área a agregar</param>
        /// <returns>Devuelve -1 si logra agregarla, o sino el ID del Área</returns>
        public static int Agregar(Area pArea)
        {
            if ((pArea == null) || (pArea.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pArea));

            DAOFactory factory = DAOFactory.Instancia();
            int idArea = -1;

            try
            {
                factory.IniciarConexion();
                List<Area> listaAreas = factory.AreaDAO.Listar();
                factory.FinalizarConexion();

                for (int i = 0; i < listaAreas.Count; i++)
                {
                    if (listaAreas[i].Nombre.ToUpper() == pArea.Nombre.ToUpper())
                    {
                        idArea = listaAreas[i].IdArea;
                    }
                }

                if (idArea == -1)
                {
                    factory.IniciarConexion();
                    factory.AreaDAO.Agregar(pArea);
                    factory.FinalizarConexion();
                }
                return idArea;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para listar las áreas
        /// </summary>
        /// <returns>Devuelve una lista de áreas, null si no encontró ninguna</returns>
        public static List<Area> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Area> listaArea = factory.AreaDAO.Listar();
                factory.FinalizarConexion();

                return listaArea;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para modificar un área
        /// </summary>
        /// <param name="pArea">Área a modificar</param>
        /// <returns>Devuelve true si o modificò. False en caso contrario</returns>
        public static bool Modificar(Area pArea)
        {
            if ((pArea == null) || (pArea.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pArea));

            DAOFactory factory = DAOFactory.Instancia();
            int idArea = -1;
            string nombre = string.Empty;

            try
            {
                factory.IniciarConexion();
                List<Area> listaAreas = factory.AreaDAO.Listar();
                factory.FinalizarConexion();

                for (int i = 0; i < listaAreas.Count; i++)
                {
                    if ((listaAreas[i].Nombre.ToUpper() == pArea.Nombre.ToUpper()) && (listaAreas[i].IdArea != pArea.IdArea))
                    {
                        idArea = listaAreas[i].IdArea;
                        nombre = listaAreas[i].Nombre;
                    }
                }

                if (((idArea == -1) && (idArea != pArea.IdArea)) || ((nombre != pArea.Nombre) && (idArea == pArea.IdArea)))
                {
                    factory.IniciarConexion();
                    factory.AreaDAO.Modificar(pArea);
                    factory.FinalizarConexion();

                    return true;
                }
                else
                {
                    if(idArea == pArea.IdArea)
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
        /// Método para obtener una determinada Área
        /// </summary>
        /// <param name="pNombre">Nombde del área</param>
        /// <returns>Devuelve el área encontrada. Null en caso de no encontrarla</returns>
        public static Area Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Area area = factory.AreaDAO.Obtener(pNombre);
                factory.FinalizarConexion();

                return area;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Método para obtener una determinada Área
        /// </summary>
        /// <param name="pId">Id del área</param>
        /// <returns>Devuelve el área encontrada. Null en caso de no encontrarla</returns>
        public static Area Obtener(int pId)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Area area = factory.AreaDAO.Obtener(pId);
                factory.FinalizarConexion();

                return area;
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
