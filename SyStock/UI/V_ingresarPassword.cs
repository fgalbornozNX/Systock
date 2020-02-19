using System;
using System.Windows.Forms;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public partial class V_ingresarPassword : Form
    {
        public V_ingresarPassword()
        {
            InitializeComponent();
        }

        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public bool Verificar { get; set; }

        public bool Guardar { get; set; }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            this.Contraseña = textBoxContraseña.Text;
            if (this.Contraseña.Length != 0)
            {
                if (this.Verificar)
                {
                    VerificarPersona();
                }
                else
                {
                    this.Guardar = true;
                    this.Close();
                }
            }  
        }

        private void V_ingresarPassword_Load(object sender, EventArgs e)
        {
            this.textBoxNombre.Text = this.Nombre;
            this.textBoxNombre.Enabled = false;
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Guardar = false;
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            ModificarPersona v_Persona = new ModificarPersona
            {
                Nombre = this.textBoxNombre.Text
            };
            v_Persona.Show();
            this.Close();
        }

        private void VerificarPersona()
        {
            int verificar = ControladorFachada.VerificarPersona(this.Nombre, textBoxContraseña.Text);
            if (verificar == -2)
            {
                MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
            }
            else
            {
                if (verificar == -1)
                {
                    this.textBoxContraseña.Text = "";
                    MessageBox.Show("Contraseña incorrecta");
                }
                else
                {
                    this.Guardar = true;
                    this.Close();
                }
            }
        }
    }
}
