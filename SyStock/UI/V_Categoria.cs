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

        /// <summary>
        /// Método para cargar la ventana Categoría
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void V_Categoria_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            this.Button_Editar.Enabled = false;
            this.Button_Eliminar.Enabled = false;
        }

        private readonly ControladorFachada Controlador = ControladorFachada.Instancia;

        private readonly Listar _listar = new Listar(); 
        
        private List<Categoria> _listaCategorias;

        private int idColumna = 0;

        public Categoria _categoria = new Categoria("",true,0);

        /// <summary>
        /// Método para refrescar la ventana
        /// </summary>
        private void RefrescarDataGrid()
        {
            _listaCategorias = Controlador.ListarCategorias();
            _listaCategorias.Sort(delegate (Categoria a1, Categoria a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            _listar.Categorias(dataGridView1, _listaCategorias);
        }

        /// <summary>
        /// Método para traer la categoría seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listaCategorias.Count()))
            {
                Button_Editar.Enabled = true;
                Button_Eliminar.Enabled = true;
                idColumna = e.RowIndex;
                _categoria.Nombre = _listaCategorias[idColumna].Nombre;
            }
            else
            {
                Button_Editar.Enabled = false;
                Button_Eliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Método para agregar una categoría
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Agregar categoría
                if (this.button_Agregar.Text == "Agregar")
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas Agregar esta Categoría?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(this.textBox_nombre.Text))
                        {
                            MessageBox.Show("Falta ingresar Nombre");
                        }
                        else
                        {
                            int agregado = Controlador.AgregarCategoria(this.textBox_nombre.Text);
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

                //Modificar categoría
                else
                {
                    if (string.IsNullOrEmpty(this.textBox_nombre.Text))
                    {
                        MessageBox.Show("Falta ingresar nombre de categoría");
                    }
                    else
                    {
                        if (Controlador.ModificarCategoria(_categoria.Nombre, this.textBox_nombre.Text))
                        {
                            this.button_Agregar.Text = "Agregar";
                            MessageBox.Show("Modificado con éxito");
                            RefrescarDataGrid();
                            this.dataGridView1.Enabled = true;
                            this.dataGridView1.ReadOnly = false;
                        }
                        else
                        {
                            MessageBox.Show("Nombre de categoría ya existente");
                        }
                    }
                }
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Método para eliminar una categoría
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoria.Estado)
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas dar de baja esta Categoría?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (Controlador.BajaCategoria(_categoria))
                        {
                            MessageBox.Show("Categoría dada de baja");
                        }
                        else
                        {
                            MessageBox.Show("La categoría ya está dada de baja");
                        }

                        this.Button_Editar.Enabled = false;
                        this.Button_Eliminar.Enabled = false;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar esta Categoría?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (Controlador.EliminarCategoria(_categoria))
                        {
                            MessageBox.Show("Categoría eliminada con éxito");
                        }

                        this.Button_Editar.Enabled = false;
                        this.Button_Eliminar.Enabled = false;
                    }
                }
                RefrescarDataGrid();
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método para cerrar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método para modificar una determinada categoría
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Editar_Click(object sender, EventArgs e)
        {
            this.button_Agregar.Text = "Aceptar";
            this.textBox_nombre.Text = _categoria.Nombre;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.ReadOnly = true;
            this.Button_Editar.Enabled = false;
            this.Button_Eliminar.Enabled = false;
        }
    }
}
