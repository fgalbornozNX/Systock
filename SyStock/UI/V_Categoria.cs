using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyStock.Entidades;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public partial class V_Categoria : Form
    {
        public V_Categoria()
        {
            InitializeComponent();
        }

        private void V_Categoria_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            this.Button_agregarInsumo.Enabled = false;
            this.Button_Editar.Enabled = false;
            this.Button_Eliminar.Enabled = false;
        }

        private readonly Fachada Controlador = Fachada.Instancia;

        private List<Categoria> _listaCategorias;

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            _listaCategorias = Controlador.ListarCategorias();
            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var _cat in _listaCategorias)
            {
                if (_cat != null)
                {
                    String[] row;
                    row = new String[] { _cat.Nombre };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas Agregar esta Categoría?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (this.textBox_nombre.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar Nombre");
                }
                else
                {
                    int agregado = Controlador.AgregarCategoria(this.textBox_nombre.Text.ToUpper());
                    if (agregado == -2)
                    {
                        MessageBox.Show("Problemas al agregar la categoría. Vuelva a intentarlo");
                    }
                    else
                    {
                        if (agregado != -1)
                        {
                            MessageBox.Show("Nombre de Categoría ya existente");
                        }
                        else
                        {
                            this.textBox_nombre.Clear();
                            RefrescarDataGrid();
                        }
                    }
                }
            }

        }

        private void Button_Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
