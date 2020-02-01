using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyStock.UI
{
    public partial class V_Consulta : Form
    {
        public V_Consulta()
        {
            InitializeComponent();
        }

        private readonly Listar _listar = new Listar();

        private void ComboBox_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Grupo(this.comboBox_grupo, this.comboBox_Area);
            if (this.comboBox_grupo.Items.Count == 1)
            {
                this.comboBox_grupo.Text = this.comboBox_Area.Text;
                this.comboBox_grupo.Enabled = false;
            }
            else
            {
                this.comboBox_grupo.Enabled = true;
            }
        }

        private void V_Consulta_Load(object sender, EventArgs e)
        {
            //TabControl1
            _listar.Areas(this.comboBox_Area);

            //TabControl2
            _listar.Categorias(this.comboBox_categoria);

            //TabControl3
            _listar.Areas(this.comboBox_area2);

        }

        private void ComboBox_area2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Grupo(this.comboBox_grupo2, this.comboBox_area2);
            if (this.comboBox_grupo2.Items.Count == 1)
            {
                this.comboBox_grupo2.Text = this.comboBox_area2.Text;
                this.comboBox_grupo2.Enabled = false;
            }
            else
            {
                this.comboBox_grupo2.Enabled = true;
            }
        }

        private void comboBox_grupo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Persona(this.comboBox_nombre, this.comboBox_grupo2.Text);
            if (this.comboBox_grupo.Items.Count == 1)
            {
                this.comboBox_grupo.Text = this.comboBox_Area.Text;
                this.comboBox_grupo.Enabled = false;
            }
            else
            {
                this.comboBox_grupo.Enabled = true;
            }
        }
    }
}
