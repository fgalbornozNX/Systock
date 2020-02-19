using System;
using System.Windows.Forms;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public partial class ModificarPersona : Form
    {
        public ModificarPersona()
        {
            InitializeComponent();
        }

        public string Nombre { get; set; }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            if (this.textBox_contraseña_nueva.Text != this.textBox_repetir.Text)
            {
                MessageBox.Show("Las contraseñas de la persona no coinciden");
            }
            else
            {
                int _verificar = ControladorFachada.VerificarUsuario("", this.textBox_contraseñaUsuario.Text);
                switch (_verificar)
                {
                    case 1:
                        MessageBox.Show("Contraseña de usuario incorrecta");
                        break;
                    case 2:
                        MessageBox.Show("El usuario se encuentra dado de baja");
                        break;
                    case 3:
                        ModificarContraseña();
                        break;
                }
            }
        }

        private void ModificarContraseña()
        {
            bool modifica = ControladorFachada.ModificarPersona(this.Nombre, this.textBox_contraseña_nueva.Text);
            if (modifica)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un problema, inténtelo nuevamente");
            }
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
