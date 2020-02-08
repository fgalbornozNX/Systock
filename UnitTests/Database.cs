using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyStock.AccesoDatos;
using SyStock.Entidades;
using SyStock.LogicaNegocio;

namespace UnitTests
{
    [TestClass]
    public class Database
    {
        readonly DAOFactory daoFactory =    DAOFactory.Instancia();
        readonly Usuario    user =          new Usuario("Add testing", "Test Password", DateTime.Today);
        readonly Area       area =          new Area("Area de pruebas");

        [TestMethod]
        public void ConnectDB()
        {
            // Returns true if connection is open
            Assert.IsTrue(daoFactory.IniciarConexion());
        }

        [TestMethod]
        public void DisconnectDB()
        {
            // Returns true if connection is closed
            Assert.IsTrue(daoFactory.FinalizarConexion());
        }

        [TestMethod]
        public void UsuarioDB()
        {
                Assert.IsTrue(AddUsuario());
                Assert.IsTrue(ModifyUsuario());
                Assert.IsTrue(VerifyUserName());
                Assert.IsTrue(ObtainUser());
                Assert.IsTrue(RemoveUsuario());
        }

        [TestMethod]
        public void PasswordDB()
        {
            daoFactory.IniciarConexion();
            string nombre = "Default";
            string pass = "thispassworddontwork";

            Assert.IsTrue(daoFactory.UsuarioDAO.Verificar(nombre, pass) == 1);
            daoFactory.FinalizarConexion();
        }

        [TestMethod]
        public void AreaDB()
        {
            Assert.IsTrue(AgregarArea());
            //Assert.IsTrue(VerificarArea());
            //Assert.IsTrue(ModificarArea());
            //Assert.IsTrue(ListarAreas());
            //Assert.IsTrue(EliminarArea());
        }

        #region UsuarioDB

        private bool AddUsuario()
        {
            try
            {
                daoFactory.IniciarConexion();
                daoFactory.UsuarioDAO.Agregar(user);
                return true;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool ModifyUsuario()
        {
            try
            {
                daoFactory.IniciarConexion();
                daoFactory.UsuarioDAO.ModificarNombre("Add testing", "Modify testing");
                daoFactory.UsuarioDAO.ModificarContrasena("Modify testing", "Modified password");
                daoFactory.UsuarioDAO.ModificarFechaAlta("Modify testing", DateTime.Today);
                daoFactory.UsuarioDAO.ModificarIdUsuario("Modify testing", -15); // Using a negative number to avoid conflict with the sequence generator in the DB
                return true;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool VerifyUserName()
        {
            try
            {
                daoFactory.IniciarConexion();
                if (daoFactory.UsuarioDAO.VerificarNombre("Modify testing") != -1)
                    return true;
                else
                    return false;
            }
            catch(DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool ObtainUser()
        {
            try
            {
                daoFactory.IniciarConexion();
                Usuario user = daoFactory.UsuarioDAO.Obtener(-15);
                if (user.Nombre == "Modify testing")
                    return true;
                else
                    return false;
            }
            catch(DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool RemoveUsuario()
        {
            try
            {
                daoFactory.IniciarConexion();
                daoFactory.UsuarioDAO.EliminarUsuario("Modify testing");
                return true;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }
        #endregion

        #region AreaDB
        private bool AgregarArea()
        {
            try
            {
                daoFactory.IniciarConexion();
                daoFactory.AreaDAO.Agregar(area);
                return true;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool VerificarArea()
        {
            try
            {
                daoFactory.IniciarConexion();
                int idArea = daoFactory.AreaDAO.VerificarNombre(area.Nombre);
                Area area1 = daoFactory.AreaDAO.Obtener(idArea);
                Area area2 = daoFactory.AreaDAO.Obtener(area.Nombre);
                if ((area1.IdArea == area2.IdArea) && (area1.Nombre == area2.Nombre))
                    return true;
                else
                    return false;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool ModificarArea()
        {
            try
            {
                daoFactory.IniciarConexion();
                int idArea = daoFactory.AreaDAO.VerificarNombre(area.Nombre);
                Area area1 = new Area(idArea, "Modified Area");
                daoFactory.AreaDAO.Modificar(area1);
                return true;
            }
            catch (DAOException)
            {
                return false;
            }
            finally
            {
                daoFactory.FinalizarConexion();
            }
        }

        private bool ListarAreas()
        {
            throw new NotImplementedException();
        }

        private bool EliminarArea()
        {
            throw new NotImplementedException();
            // prueba
        }
        #endregion

    }
}
