﻿using System.Collections.Generic;
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
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                int idArea = -1;

                List<Area> listaAreas = new List<Area>();
                listaAreas = _areaDAO.Listar();


                for (int i = 0; i < listaAreas.Count; i++)
                {
                    if (listaAreas[i].Nombre.ToUpper() == pArea.Nombre.ToUpper())
                    {
                        idArea = listaAreas[i].IdArea;
                    }
                }

                factory.FinalizarConexion();
                if (idArea == -1)
                {
                    factory.IniciarConexion();
                    _areaDAO.Agregar(pArea);
                }
                return idArea;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para listar las áreas
        /// </summary>
        /// <returns>Devuelve una lista de áreas, null si no encontró ninguna</returns>
        public static List<Area> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Area> _listaArea = new List<Area>();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;
                _listaArea = _areaDAO.Listar();
                return _listaArea;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para modificar un área
        /// </summary>
        /// <param name="pArea">Área a modificar</param>
        /// <returns>Devuelve true si o modificò. False en caso contrario</returns>
        public static bool Modificar(Area pArea)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IAreaDAO _areaDAO = factory.AreaDAO;


                int idArea = -1;
                string nombre = "";

                List<Area> listaAreas = new List<Area>();
                listaAreas = _areaDAO.Listar();


                for (int i = 0; i < listaAreas.Count; i++)
                {
                    if ((listaAreas[i].Nombre.ToUpper() == pArea.Nombre.ToUpper()) && (listaAreas[i].IdArea != pArea.IdArea))
                    {
                        idArea = listaAreas[i].IdArea;
                        nombre = listaAreas[i].Nombre;
                    }
                }

                factory.FinalizarConexion();
                if (((idArea == -1)&& (idArea != pArea.IdArea))||((nombre != pArea.Nombre) && (idArea == pArea.IdArea)))
                {
                    factory.IniciarConexion();
                    _areaDAO.Modificar(pArea);
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
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
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
                IAreaDAO _areaDAO = factory.AreaDAO;
                Area _area = new Area("");
                _area = _areaDAO.Obtener(pNombre);
                return _area;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
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
                IAreaDAO _areaDAO = factory.AreaDAO;
                Area _area = new Area("");
                _area = _areaDAO.Obtener(pId);
                return _area;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                throw new LogicaException(e.Message);
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}
