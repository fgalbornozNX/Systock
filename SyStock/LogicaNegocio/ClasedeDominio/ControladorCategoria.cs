using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorCategoria
    {
        public int Agregar(Categoria pCategoria)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                ICategoriaDAO _categoriaDAO = factory.CategoriaDAO;
                int idCategoria = _categoriaDAO.VerificarNombre(pCategoria.Nombre);
                factory.FinalizarConexion();
                if (idCategoria == -1)
                {
                    factory.IniciarConexion();
                    _categoriaDAO.Agregar(pCategoria);
                }
                return idCategoria;
            }
            catch (DAOException)
            {
                factory.RollBack();
                return -2;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<Categoria> Listar()
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

        public Categoria Obtener(string pNombre)
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
    }
}
