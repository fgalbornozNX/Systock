using System;
using System.Collections.Generic;
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

        private List<Usuario> listaUsuarios = new List<Usuario>();

        private int idColumna = 0;

        public Usuario Usuario { get; set; }

        private void V_Usuario_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            listaUsuarios.Clear();
            listaUsuarios = ControladorFachada.ListarUsuarios();
            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var usu in listaUsuarios)
            {
                if (usu != null)
                {
                    String[] row;
                    if (usu.FechaAlta == usu.FechaBaja)
                    {
                        row = new String[] { usu.Nombre, Convert.ToString(usu.FechaAlta), Convert.ToString("") };
                    }
                    else
                    {
                        row = new String[] { usu.Nombre, Convert.ToString(usu.FechaAlta.Date), Convert.ToString(usu.FechaBaja.Date) };
                    }
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < listaUsuarios.Count))
            {
                Button_Modificar.Enabled = true;
                Button_Eliminar.Enabled = true;
                idColumna = e.RowIndex;
                this.Usuario.Nombre = listaUsuarios[idColumna].Nombre;
            }
            else
            {
                Button_Modificar.Enabled = false;
                Button_Eliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Método del boton Agregar Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Comprueba que se ingrese nombre de usuario
                if (string.IsNullOrEmpty(this.textBox_nombre.Text))
                {
                    MessageBox.Show("Falta ingresar Nombre");
                }
                else
                {
                    //Comprueba que se ingresa contraseña
                    if (string.IsNullOrEmpty(this.textBox_contraseña.Text))
                    {
                        MessageBox.Show("Falta ingresar Contraseña");
                    }
                    else
                    {
                        this.Usuario = ControladorFachada.AgregarUsuario(this.textBox_nombre.Text, this.textBox_contraseña.Text, this.checkBox1.Checked);

                        if (this.Usuario != null)
                        {
                            MessageBox.Show("Agregado con éxito");
                            this.textBox_nombre.Clear();
                            this.textBox_contraseña.Clear();
                            this.checkBox1.Checked = false;

                            listaUsuarios.Add(this.Usuario);
                            RefrescarDataGrid();
                        }
                        else
                            MessageBox.Show("El nombre de usuario ya existe");
                    }
                }
            }

            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método para modificar los datos de un Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modificar_Click(object sender, EventArgs e)
        {
            V_UsuarioModificar v_modificarUsuario = new V_UsuarioModificar()
            {
                UsuarioLogeado = false,
                Usuario = this.Usuario,
            };
            v_modificarUsuario.ShowDialog(this);
            this.Show();
            RefrescarDataGrid();
        }

        /// <summary>
        /// Método para dar de baja un Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a " + listaUsuarios[idColumna].Nombre + " de la lista?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool eliminar = false;
                    eliminar = ControladorFachada.EliminarUsuario(listaUsuarios[idColumna].Nombre);
                    if (eliminar)
                    {
                        RefrescarDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + listaUsuarios[idColumna].Nombre + " ya se encuentra dado de baja");
                    }

                }
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
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
