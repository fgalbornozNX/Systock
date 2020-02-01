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
    public partial class V_Usuario : Form
    {
        public V_Usuario()
        {
            InitializeComponent();
        }

        private readonly Fachada _controlador = Fachada.Instancia;

        private List<Usuario> _listaUsuarios = new List<Usuario>();

        private int idColumna = 0;

        public Usuario _usuario = new Usuario("", "", DateTime.Now); 

        private void V_Usuario_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            _listaUsuarios.Clear();
            _listaUsuarios = _controlador.ListarUsuarios();
            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var _usu in _listaUsuarios)
            {
                if (_usu != null)
                {
                    String[] row;
                    if (_usu.FechaAlta == _usu.FechaBaja)
                    {
                        row = new String[] { _usu.Nombre, Convert.ToString(_usu.FechaAlta), Convert.ToString("") };
                    }
                    else
                    {
                        row = new String[] { _usu.Nombre, Convert.ToString(_usu.FechaAlta.Date), Convert.ToString(_usu.FechaBaja.Date) };
                    }
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listaUsuarios.Count()))
            {
                Button_Modificar.Enabled = true;
                Button_Eliminar.Enabled = true;
                idColumna = e.RowIndex;
                _usuario.Nombre = _listaUsuarios[idColumna].Nombre;
            }
            else
            {
                Button_Modificar.Enabled = false;
                Button_Eliminar.Enabled = false;
            }
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            //Comprueba que se ingrese nombre de usuario
            if (this.textBox_nombre.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar Nombre");
            }
            else
            {
                //Comprueba que se ingresa contraseña
                if (this.textBox_contraseña.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar Contraseña");
                }
                else
                {
                    _usuario = _controlador.AgregarUsuario(this.textBox_nombre.Text, this.textBox_contraseña.Text, this.checkBox1.Checked);

                    if (_usuario != null)
                    {
                        MessageBox.Show("Agregado con éxito");
                        this.textBox_nombre.Clear();
                        this.textBox_contraseña.Clear();
                        this.checkBox1.Checked = false;

                        _listaUsuarios.Add(_usuario);
                        RefrescarDataGrid();
                    }
                    else
                        MessageBox.Show("El nombre de usuario ya existe");
                }
            }
        }

        private void Button_Modificar_Click(object sender, EventArgs e)
        {
            V_UsuarioModificar v_modificarUsuario = new V_UsuarioModificar()
            {
                usuarioLogeado = false,
                _usu = _usuario,
            };
            v_modificarUsuario.ShowDialog(this);
            this.Show();
            RefrescarDataGrid();
        }

        private void Button_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a " + _listaUsuarios[idColumna].Nombre + " de la lista?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool _eliminar = false;
                _eliminar = _controlador.EliminarUsuario(_listaUsuarios[idColumna].Nombre);
                if (_eliminar)
                {
                    RefrescarDataGrid();
                }
                else
                {
                    MessageBox.Show("El usuario " + _listaUsuarios[idColumna].Nombre + " ya se encuentra dado de baja");
                }
                
            }
        }

        /// <summary>
        /// Cierra la ventana V_Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
