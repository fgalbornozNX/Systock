using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.AccesoDatos;
using SyStock.Entidades;

namespace SyStock.LogicaNegocio.ClasedeDominio
{
    public class ControladorPersona
    {
        public int Agregar(PersonaAutorizada pPersona)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _personaDAO = factory.PersonaAutorizadaDAO;
                int idPersona = _personaDAO.VerificarNombre(pPersona.Nombre);
                factory.FinalizarConexion();
                if (idPersona == -1)
                {
                    factory.IniciarConexion();
                    _personaDAO.Agregar(pPersona);
                }
                return idPersona;

            }
            catch (DAOException)
            {
                factory.RollBack();
                return -1;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public int VerificarNombre(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                return _PersonaDAO.VerificarNombre(pNombre);
            }
            catch (Exception)
            {
                return -2;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public int Verificar(string pNombre, string pContraseña)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                return _PersonaDAO.Verificar(pNombre, pContraseña);
            }
            catch (Exception)
            {
                return -2;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<PersonaAutorizada> Listar()
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<PersonaAutorizada> _listaPersona = new List<PersonaAutorizada>();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                _listaPersona = _PersonaDAO.Listar();
                return _listaPersona;
            }
            catch (Exception)
            {
                _listaPersona.Clear();
                return _listaPersona;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public List<PersonaAutorizada> Listar(int idGrupo)
        {
            DAOFactory factory = DAOFactory.Instancia();
            List<PersonaAutorizada> _listaPersonas = new List<PersonaAutorizada>();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _personasDAO = factory.PersonaAutorizadaDAO;
                _listaPersonas = _personasDAO.Listar(idGrupo);
                return _listaPersonas;
            }
            catch (Exception)
            {
                _listaPersonas.Clear();
                return _listaPersonas;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }

        public PersonaAutorizada Obtener(int pIdPersona)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                PersonaAutorizada _Persona = new PersonaAutorizada(0, "", "", DateTime.Today, DateTime.Today, 0);
                _Persona = _PersonaDAO.Obtener(pIdPersona);
                return _Persona;
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

        public PersonaAutorizada Obtener(string pNombre)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                PersonaAutorizada _Persona = new PersonaAutorizada(0, "", "", DateTime.Today, DateTime.Today, 0);
                _Persona = _PersonaDAO.Obtener(pNombre);
                return _Persona;
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

        public bool Modificar(PersonaAutorizada pPersona)
        {
            DAOFactory factory = DAOFactory.Instancia();

            try
            {
                factory.IniciarConexion();
                IPersonaAutorizadaDAO _PersonaDAO = factory.PersonaAutorizadaDAO;
                _PersonaDAO.Modificar(pPersona);
                return true;
            }
            catch (DAOException)
            {
                factory.RollBack();
                return false;
            }
            finally
            {
                factory.FinalizarConexion();
            }
        }
    }
}
