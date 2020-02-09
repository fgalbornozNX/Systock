using System;
using System.Collections.Generic;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public static class ControladorCategoria
    {
        /// <summary>
        /// Método para agregar una categoría
        /// </summary>
        /// <param name="pCategoria">Categoría a agregar</param>
        /// <returns>Devuelve -1 si puede agregarla. Sino el ID de la categoría ya existente</returns>
        public static int Agregar(Categoria pCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;
                
                int idCategoria = -1;

                List<Categoria> listaCategorias = new List<Categoria>();
                listaCategorias = _categoriaDAO.Listar();


                for (int i = 0; i < listaCategorias.Count; i++)
                {
                    if (listaCategorias[i].Nombre.ToUpper() == pCategoria.Nombre.ToUpper())
                    {
                        idCategoria = listaCategorias[i].IdCategoria;
                    }
                }

                factory.FinalizarConexion();
                if (idCategoria == -1)
                {
                    factory.IniciarConexion();
                    _categoriaDAO.Agregar(pCategoria);
                }
                
                return idCategoria;
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

        public static List<Categoria> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Categoria> _listaCategoria = new List<Categoria>();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;
                _listaCategoria = _categoriaDAO.Listar();
                return _listaCategoria;
            }
            catch (Exception)
            {
                _listaCategoria.Clear();
                return _listaCategoria;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public static Categoria Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;
                Categoria _categoria = new Categoria(0, "", true, 0);
                _categoria = _categoriaDAO.Obtener(pNombre);
                return _categoria;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para modificar una categoría
        /// </summary>
        /// <param name="pCategoria"></param>
        /// <returns></returns>
        public static bool Modificar(Categoria pCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;


                int idCategoria = -1;
                string nombre = "";

                List<Categoria> listaCategorias = new List<Categoria>();
                listaCategorias = _categoriaDAO.Listar();


                for (int i = 0; i < listaCategorias.Count; i++)
                {
                    if ((listaCategorias[i].Nombre.ToUpper() == pCategoria.Nombre.ToUpper()) && (listaCategorias[i].IdCategoria != pCategoria.IdCategoria))
                    {
                        idCategoria = listaCategorias[i].IdCategoria;
                        nombre = listaCategorias[i].Nombre;
                    }
                }

                factory.FinalizarConexion();
                if (((idCategoria == -1) && (idCategoria != pCategoria.IdCategoria)) || ((nombre != pCategoria.Nombre) && (idCategoria == pCategoria.IdCategoria)))
                {
                    factory.IniciarConexion();
                    _categoriaDAO.Modificar(pCategoria);
                    return true;
                }
                else
                {
                    if (idCategoria == pCategoria.IdCategoria)
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

        public static bool Baja(Categoria pCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;

                if (pCategoria.Estado)
                {
                    pCategoria.Estado = false;
                    factory.IniciarConexion();
                    _categoriaDAO.Modificar(pCategoria);
                    return true;
                }
                else
                {
                    return false;
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

        public static bool Eliminar(Categoria pCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;

                if (!pCategoria.Estado)
                {
                    factory.IniciarConexion();
                    _categoriaDAO.Eliminar(pCategoria.IdCategoria);
                    return true;
                }
                else
                {
                    return false;
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
    }
}
