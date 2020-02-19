using System;
using System.Windows.Forms;

namespace SyStock.UI
{
    public partial class V_Consulta : Form
    {
        public V_Consulta()
        {
            InitializeComponent();
        }

        private void ComboBox_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Grupo(this.comboBox_grupo, this.comboBox_Area);
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
            Listar.Areas(this.comboBox_Area);

            //TabControl2
            Listar.Categorias(this.comboBox_categoria);

            //TabControl3
            Listar.Areas(this.comboBox_area2);

        }

        private void ComboBox_area2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Grupo(this.comboBox_grupo2, this.comboBox_area2);
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

        private void ComboBox_grupo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Persona(this.comboBox_nombre, this.comboBox_grupo2.Text);
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
