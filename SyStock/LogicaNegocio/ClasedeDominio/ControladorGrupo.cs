using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorGrupo
    {
        /// <summary>
        /// Método para agregar un grupo
        /// </summary>
        /// <param name="pGrupo">Grupo a agregar</param>
        /// <returns>Devuelve -1 si agregó el Grupo. sino el valor del Id del grupo ya existente</returns>
        public int Agregar(Grupo pGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                int idGrupo = _grupoDAO.VerificarNombre(pGrupo.Nombre, pGrupo.IdArea);
                factory.FinalizarConexion();
                if (idGrupo == -1)
                {
                    factory.IniciarConexion();
                    _grupoDAO.Agregar(pGrupo);
                }
                return idGrupo;
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
        /// Método para modificar un grupo
        /// </summary>
        /// <param name="pGrupo">Grupo a modificar</param>
        /// <returns>Devuelve true si logró modificarlo</returns>
        public bool Modificar(Grupo pGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                _grupoDAO.Modificar(pGrupo);
                return true;
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
        /// Método para listar los grupos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public List<Grupo> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Grupo> _listaGrupo = new List<Grupo>();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                _listaGrupo = _GrupoDAO.Listar();
                return _listaGrupo;
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
        /// Método para listar los grupos
        /// </summary>
        /// <param name="idArea">Id del Área de os grupos a listar</param>
        /// <returns>Lista de grupos para una determinada Área</returns>
        public List<Grupo> Listar(int idArea)
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<Grupo> _listaGrupo = new List<Grupo>();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _grupoDAO = factory.GrupoDAO;
                _listaGrupo = _grupoDAO.Listar(idArea);
                return _listaGrupo;
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
        /// Método para obtener un grupo dependiendo del nombre
        /// </summary>
        /// <param name="pNombre">Nombre del grupo</param>
        /// <returns>Devuelve el grupo. Null si no lo encontró</returns>
        public Grupo Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                Grupo _Grupo = new Grupo(0, "", true, 0, 0);
                _Grupo = _GrupoDAO.Obtener(pNombre);
                return _Grupo;
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
        /// Método para obtener un grupo dependiendo del ID
        /// </summary>
        /// <param name="pId">ID del grupo</param>
        /// <returns>Devuelve el grupo. Null si no lo encontró</returns>
        public Grupo Obtener(int pId)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IGrupoDAO _GrupoDAO = factory.GrupoDAO;
                Grupo _Grupo = new Grupo(0, "", true, 0, 0);
                _Grupo = _GrupoDAO.Obtener(pId);
                return _Grupo;
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
