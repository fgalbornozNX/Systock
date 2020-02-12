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
    public partial class V_Insumos : Form
    {
        public V_Insumos()
        {
            InitializeComponent();
        }

        private readonly ControladorFachada Controlador = ControladorFachada.Instancia;

        private List<Insumo> _listaInsumos = new List<Insumo>();

        private readonly Listar _listar = new Listar();

        Insumo _insumo;

        private void V_Insumos_Load(object sender, EventArgs e)
        {
            this.Button_ModificarInsumo.Enabled = false;
            _listar.Categorias(this.comboBox_categoria);
            _listar.Categorias(this.comboBox_filtrar);
            this.comboBox_filtrar.Text = "TODOS";
            RefrescarDataGrid();
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            _listar.Categorias(this.comboBox_categoria);
            _listar.Categorias(this.comboBox_filtrar);
            _listaInsumos = Controlador.ListarInsumos();

            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var _ins in _listaInsumos)
            {
                if (_ins != null)
                {
                    String[] row;
                    row = new String[] { _ins.Nombre, Convert.ToString(_ins.Cantidad), Convert.ToString(_ins.CantidadMinima), _ins.Descripcion };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void Button_AgregarCategoria_Click(object sender, EventArgs e)
        {
            V_Categoria v_Categoria = new V_Categoria();
            v_Categoria.Show();
            RefrescarDataGrid();
        }

        private void Button_AgregarInsumo_Click(object sender, EventArgs e)
        {
            if (this.Button_AgregarInsumo.Text == "Agregar")
            {
                AgregarInsumos();
            }
            else
            {
                ModificarInsumos();
            }
        }

        private void AgregarInsumos()
        {
            if ((this.textBox_nombre.Text == string.Empty) || (this.comboBox_categoria.Text == string.Empty) || (this.textBox_cantidad.Text == string.Empty) || (this.textBox_stock.Text == string.Empty))
            {
            MessageBox.Show("Falta ingresar algunos datos");
        }
            else
            {
            DialogResult result = MessageBox.Show("¿Seguro que deseas Agregar este Insumo?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int agregado = Controlador.AgregarInsumo(this.textBox_nombre.Text.ToUpper(), this.richTextBox_descripcion.Text, this.textBox_cantidad.Text, this.textBox_stock.Text, this.comboBox_categoria.Text);
                if (agregado == -2)
                {
                    MessageBox.Show("Problemas al agregar el Insumo. Vuelva a intentarlo");
                }
                else
                {
                    if (agregado != -1)
                    {
                        MessageBox.Show("Nombre de Insumo ya existente");
                    }
                    else
                    {
                        this.textBox_nombre.Clear();
                        this.comboBox_categoria.Text = string.Empty;
                        this.richTextBox_descripcion.Clear();
                        this.textBox_cantidad.Clear();
                        this.textBox_stock.Clear();
                        RefrescarDataGrid();
                    }
                }
            }
        }
        }

        private void ModificarInsumos()
        {
            _insumo.Descripcion = this.richTextBox_descripcion.Text;
            _insumo.CantidadMinima = Convert.ToInt32(this.textBox_stock.Text);
            bool _modifica = Controlador.ModificarInsumo(_insumo);
            if (_modifica)
            {
                DesactivarModificar();
                RefrescarDataGrid();
                MessageBox.Show("Modificado con éxito");
            }
            else
            {
                MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
            }
        }

        private void ComboBox_filtrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string pCategoria = this.comboBox_filtrar.Text;
            if (pCategoria == "TODOS")
            {
                _listaInsumos = Controlador.ListarInsumos();
            }
            else
            {
                _listaInsumos = Controlador.ListarInsumos(pCategoria);
            }

            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var _ins in _listaInsumos)
            {
                if (_ins != null)
                {
                    String[] row;
                    row = new String[] { _ins.Nombre, Convert.ToString(_ins.Cantidad), _ins.Descripcion };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_ModificarInsumo_Click(object sender, EventArgs e)
        {
            ActivarModificar();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listaInsumos.Count()))
            {
                Button_ModificarInsumo.Enabled = true;
                Modificar(e.RowIndex);
            }
            else
            {
                DesactivarModificar();
                Button_ModificarInsumo.Enabled = false;
            }
        }

        private void Modificar(int pIdInsumo)
        {
            string _nombre = _listaInsumos[pIdInsumo].Nombre;
            _insumo = new Insumo("", "", 0, 0, true, 0);
            _insumo = Controlador.ObtenerInsumo(_nombre);
        }

        private void ActivarModificar()
        {
            this.Button_AgregarCategoría.Visible = false;
            this.comboBox_categoria.Enabled = false;
            this.textBox_nombre.Text = _insumo.Nombre;
            this.textBox_nombre.ReadOnly = true;
            this.richTextBox_descripcion.Text = _insumo.Descripcion;
            this.textBox_cantidad.Text = _insumo.Cantidad.ToString();
            this.textBox_cantidad.ReadOnly = true;
            this.textBox_stock.Text = _insumo.CantidadMinima.ToString();
            this.Button_AgregarInsumo.Text = "Aceptar";
        }

        private void DesactivarModificar()
        {
            this.Button_AgregarCategoría.Visible = true;
            this.comboBox_categoria.Enabled = true;
            this.textBox_nombre.Text = "";
            this.textBox_nombre.ReadOnly = false;
            this.richTextBox_descripcion.Text = "";
            this.textBox_cantidad.Text = "";
            this.textBox_cantidad.ReadOnly = false;
            this.textBox_stock.Text = "";
            this.Button_AgregarInsumo.Text = "Agregar";
        }
    }
}
