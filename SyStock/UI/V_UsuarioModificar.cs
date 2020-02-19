using System;
using System.Windows.Forms;
using SyStock.LogicaNegocio;
using SyStock.Entidades;

namespace SyStock.UI
{
    public partial class V_UsuarioModificar : Form
    {
        public Usuario Usuario { get; set; }
        public bool UsuarioLogeado { get; set; }

        public V_UsuarioModificar()
        {
            InitializeComponent();
        }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            if (this.textBox_contraseña_nueva.Text != this.textBox_repetir.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                bool verificarModificacion = ControladorFachada.ModificarUsuario(this.Usuario,this.textBox_contraseña_antigua.Text, this.textBox_contraseña_nueva.Text);
                if (verificarModificacion)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña antigua no coincide");
                }
            }
            
        }

        private void V_UsuarioModificar_Load(object sender, EventArgs e)
        {
            if (this.UsuarioLogeado)
            {
                this.Usuario.IdUsuario = 0;
            }
            else
            {
                this.Usuario.IdUsuario = 1;
            }
            
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
