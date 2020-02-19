using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SyStock.Entidades;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public partial class V_ActualizarStock : Form
    {
        public V_ActualizarStock()
        {
            InitializeComponent();
        }

        private void V_ActualizarStock_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarInsumos();
        }

        private void Button_AgregarInsumo_Click(object sender, EventArgs e)
        {
            V_Insumos v_Insumos = new V_Insumos();
            v_Insumos.Show();
        }

        private void ListarCategorias()
        {
            this.comboBox_categoria.Items.Clear();
            this.comboBox_categoria.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Categoria> listaCategorias;
            listaCategorias = ControladorFachada.ListarCategorias();
            for (int i = 0; i < listaCategorias.Count; i++)
                this.comboBox_categoria.Items.Add(listaCategorias[i].Nombre);
        }

        private void ListarInsumos()
        {
            this.comboBox_nombre.Items.Clear();
            this.comboBox_nombre.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Insumo> _listaInsumos = new List<Insumo>();
            if (this.comboBox_categoria.Text.Length == 0)
            {
                _listaInsumos = ControladorFachada.ListarInsumos();
            }
            else
            {
                _listaInsumos = ControladorFachada.ListarInsumos(this.comboBox_categoria.Text);
            }
            
            for (int i = 0; i < _listaInsumos.Count; i++)
                this.comboBox_nombre.Items.Add(_listaInsumos[i].Nombre);
        }

        private void ComboBox_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarInsumos();
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
                if ((this.comboBox_nombre.Text.Length == 0) || (this.textBox_cantidad.Text.Length == 0))
                {
                    MessageBox.Show("Falta ingresar algunos datos");
                }
                else
                {
                DialogResult result = MessageBox.Show("¿Seguro que deseas agregar el stock?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool modificado = ControladorFachada.SumarStock(this.comboBox_nombre.Text.ToUpper(), Convert.ToInt32(this.textBox_cantidad.Text));
                    if (!modificado)
                    {
                        MessageBox.Show("Problemas al actualizar el Stock. Vuelva a intentarlo");
                    }
                    else
                    {
                        ListarCategorias();
                        ListarInsumos();
                        this.textBox_cantidad.Clear();
                    }
                }
            }
        }
    }
}
