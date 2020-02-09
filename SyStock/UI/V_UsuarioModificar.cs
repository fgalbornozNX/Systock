using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyStock.LogicaNegocio;
using SyStock.Entidades;

namespace SyStock.UI
{
    public partial class V_UsuarioModificar : Form
    {

        private readonly ControladorFachada Controlador = ControladorFachada.Instancia;

        public Usuario _usu = new Usuario("", "", DateTime.Now);

        public bool usuarioLogeado = false;

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
                bool verificarModificacion = Controlador.ModificarUsuario(_usu,this.textBox_contraseña_antigua.Text, this.textBox_contraseña_nueva.Text);
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
            if (usuarioLogeado)
            {
                _usu.IdUsuario = 0;
            }
            else
            {
                _usu.IdUsuario = 1;
            }
            
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
