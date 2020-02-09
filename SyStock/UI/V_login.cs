using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyStock.LogicaNegocio;
using System.Windows.Forms;

namespace SyStock.UI
{
    public partial class V_login : Form
    {
        private bool app_access = false;

        private readonly ControladorFachada controlador = ControladorFachada.Instancia;

        public V_login()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_iniciarFormClosed);
        }

        /// <summary>
        /// Iniciar la ventana principal o cerrar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_iniciarFormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.app_access)
            {
                (new V_principal()).Show();
            }   
            else
            {
                Application.Exit();
            }     
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            app_access = false;
            this.Close();
        }

        /// <summary>
        /// Inicia la aplicación en caso de poder logearse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica que se ingrese nombre de usuario
                switch (this.textBox_nombre.Text)
                {
                    case "":
                        MessageBox.Show("Falta ingresar Nombre");
                        break;
                    default:
                        {
                            //Verifica que se ingrese contraseña
                            switch (this.textBox_contraseña.Text)
                            {
                                case "":
                                    MessageBox.Show("Falta ingresar Contraseña");
                                    break;
                                default:
                                    {
                                        //Verifica si el usuario esta en la bd
                                        int _usuarioLogueado = controlador.VerificarUsuario(this.textBox_nombre.Text, this.textBox_contraseña.Text);
                                        switch (_usuarioLogueado)
                                        {
                                            case 1:
                                                MessageBox.Show("Usuario o contraseña incorrecta");
                                                break;

                                            case 2:
                                                MessageBox.Show("Usuario dado de baja");
                                                break;

                                            default:
                                                app_access = true;
                                                this.Close();
                                                break;
                                        }

                                        break;
                                    }
                            }

                            break;
                        }
                }
            }

            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
