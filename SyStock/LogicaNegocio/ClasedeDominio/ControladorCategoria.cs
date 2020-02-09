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
            if ((pCategoria == null) || (pCategoria.Nombre.Length == 0))
                throw new ArgumentNullException(nameof(pCategoria));

            DAOFactory factory = DAOFactory.Instancia();
            int idCategoria = -1;

            try
            {
                factory.IniciarConexion();
                List<Categoria> listaCategorias = factory.CategoriaDAO.Listar();
                factory.FinalizarConexion();

                for (int i = 0; i < listaCategorias.Count; i++)
                {
                    if (listaCategorias[i].Nombre.ToUpper() == pCategoria.Nombre.ToUpper())
                    {
                        idCategoria = listaCategorias[i].IdCategoria;
                    }
                }

                if (idCategoria == -1)
                {
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Agregar(pCategoria);
                    factory.FinalizarConexion();
                }
                
                return idCategoria;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Lista las Categorías existentes
        /// </summary>
        /// <returns>Lista con todas las categorías</returns>
        public static List<Categoria> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                List<Categoria> listaCategoria = factory.CategoriaDAO.Listar();
                factory.FinalizarConexion();

                return listaCategoria;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene una Categoría
        /// </summary>
        /// <param name="pNombre">Nombre a buscar</param>
        /// <returns>Una Categoría cuyo nombre coincide con la búsqueda</returns>
        public static Categoria Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Categoria categoria = factory.CategoriaDAO.Obtener(pNombre);
                factory.FinalizarConexion();

                return categoria;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Obtiene una Categoría
        /// </summary>
        /// <param name="idCategoria">ID a buscar</param>
        /// <returns>Una Categoría cuyo ID coincide con la búsqueda</returns>
        public static Categoria Obtener(int idCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                Categoria categoria = factory.CategoriaDAO.Obtener(idCategoria);
                factory.FinalizarConexion();

                return categoria;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Modifica una Categoría
        /// </summary>
        /// <param name="pCategoria">Categoría con sus campos modificados, excepto su ID</param>
        /// <returns>True si tiene éxito. False en caso contrario</returns>
        public static bool Modificar(Categoria pCategoria)
        {
            if ((pCategoria == null) || (pCategoria.IdCategoria < 1))
                throw new ArgumentNullException(nameof(pCategoria));

            DAOFactory factory = DAOFactory.Instancia();
            int idCategoria = -1;
            string nombre = string.Empty;

            try
            {
                factory.IniciarConexion();
                List<Categoria> listaCategorias = factory.CategoriaDAO.Listar();
                factory.FinalizarConexion();

                for (int i = 0; i < listaCategorias.Count; i++)
                {
                    if ((listaCategorias[i].Nombre.ToUpper() == pCategoria.Nombre.ToUpper()) && (listaCategorias[i].IdCategoria != pCategoria.IdCategoria))
                    {
                        idCategoria = listaCategorias[i].IdCategoria;
                        nombre = listaCategorias[i].Nombre;
                    }
                }

                if (((idCategoria == -1) && (idCategoria != pCategoria.IdCategoria)) || ((nombre != pCategoria.Nombre) && (idCategoria == pCategoria.IdCategoria)))
                {
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Modificar(pCategoria);
                    factory.FinalizarConexion();

                    return true;
                }
                else
                {
                    if (idCategoria == pCategoria.IdCategoria)
                        return true;
                    else
                        return false;
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
        /// Da de baja una Categoría existente
        /// </summary>
        /// <param name="idCategoria">ID de la categoría a dar de baja</param>
        /// <returns>True si tiene éxito. False en caso contrario</returns>
        public static bool Baja(int idCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                Categoria cat = Obtener(idCategoria);

                if (cat.Estado == true)
                {
                    cat.Estado = false;
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Modificar(cat);
                    factory.FinalizarConexion();
                    return true;
                }
                else
                    return false;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Da de baja una Categoría existente
        /// </summary>
        /// <param name="categoria">categoría a dar de baja</param>
        /// <returns>True si tiene éxito. False en caso contrario</returns>
        public static bool Baja(Categoria pCategoria)
        {
            if ((pCategoria == null) || (pCategoria.IdCategoria < 1))
                throw new ArgumentNullException(nameof(pCategoria));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                if (pCategoria.Estado == true)
                {
                    pCategoria.Estado = false;
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Modificar(pCategoria);
                    factory.FinalizarConexion();
                    return true;
                }
                else
                    return false;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Elimina una Categoría de la base de datos
        /// </summary>
        /// <param name="idCategoria">ID de la categoría a eliminar</param>
        /// <returns>True si tiene éxito. False caso contrario</returns>
        public static bool Eliminar(int idCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                Categoria cat = Obtener(idCategoria);

                if (cat.Estado == false)
                {
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Eliminar(idCategoria);
                    factory.FinalizarConexion();

                    return true;
                }
                else
                    return false;
            }
            catch (DAOException e)
            {
                factory.RollBack();
                factory.FinalizarConexion();
                throw new LogicaException(e.Message);
            }
        }

        /// <summary>
        /// Elimina una Categoría de la base de datos
        /// </summary>
        /// <param name="pCategoria">Categoría a eliminar</param>
        /// <returns>True si tiene éxito. False caso contrario</returns>
        public static bool Eliminar(Categoria pCategoria)
        {
            if ((pCategoria == null) || (pCategoria.IdCategoria < 1))
                throw new ArgumentNullException(nameof(pCategoria));

            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                if (pCategoria.Estado == false)
                {
                    factory.IniciarConexion();
                    factory.CategoriaDAO.Eliminar(pCategoria.IdCategoria);
                    factory.FinalizarConexion();

                    return true;
                }
                else
                    return false;
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
