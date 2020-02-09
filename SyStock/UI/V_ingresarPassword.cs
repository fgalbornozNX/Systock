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
using SyStock.UI;

namespace SyStock.UI
{
    public partial class V_ingresarPassword : Form
    {
        public V_ingresarPassword()
        {
            InitializeComponent();
        }

        private readonly ControladorFachada Controlador = ControladorFachada.Instancia;

        public string _nombre = "";

        public string _contraseña = "";

        public bool _verificar = false;

        public bool _guardar = false;

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            _contraseña = textBox_contraseña.Text;
            if (_contraseña != string.Empty)
            {
                if (_verificar)
                {
                    VerificarPersona();
                }
                else
                {
                    _guardar = true;
                    this.Close();
                }
            }  
        }

        private void V_ingresarPassword_Load(object sender, EventArgs e)
        {
            this.textBox_nombre.Text = _nombre;
            this.textBox_nombre.Enabled = false;
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            _guardar = false;
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            ModificarPersona v_Persona = new ModificarPersona();
            v_Persona._nombre = this.textBox_nombre.Text;
            v_Persona.Show();
            this.Close();
        }

        private void VerificarPersona()
        {
            int verificar = Controlador.VerificarPersona(_nombre, textBox_contraseña.Text);
            if (verificar == -2)
            {
                MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
            }
            else
            {
                if (verificar == -1)
                {
                    this.textBox_contraseña.Text = "";
                    MessageBox.Show("Contraseña incorrecta");
                }
                else
                {
                    _guardar = true;
                    this.Close();
                }
            }
        }
    }
}
