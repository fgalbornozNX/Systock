using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SyStock.LogicaNegocio;
using SyStock.Entidades;

namespace SyStock.UI
{
    public partial class V_PersonasAutorizadas : Form
    {
        public V_PersonasAutorizadas()
        {
            InitializeComponent();
        }

        private List<MostrarPersonas> _listarPersonas = new List<MostrarPersonas>();

        public string Area { get; set; }
        public string Grupo { get; set; }
        public string NombreAntiguo { get; set; }

        private int _idPersona = 0;

        private void V_PersonasAutorizadas_Load(object sender, EventArgs e)
        {
            comboBox_area.Text = this.Area;
            Listar.Areas(this.comboBox_area);
            if (!String.IsNullOrEmpty(this.Area))
            {
                Listar.Grupo(this.comboBox_grupo, this.comboBox_area);
            }
           
            Listar.Areas(this.comboBox_area2);
            Listar.Grupo(this.ComboBox_grupo2);

            RefrescarDataGrid();
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.ColumnHeadersVisible = true;
            _listarPersonas = ControladorFachada.MostrarPersonas();
            foreach (var _per in _listarPersonas)
            {
                if (_per != null)
                {
                    String[] row;
                    row = new String[] { _per.Area, _per.Grupo, _per.Nombre };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        private void Desactivar()
        {
            this.comboBox_area.Enabled = false;
            this.comboBox_grupo.Enabled = false;
            this.comboBox_area2.Enabled = false;
            this.ComboBox_grupo2.Enabled = false;
            this.Button_Modificar.Enabled = false;
            this.Button_Eliminar.Enabled = false;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.ClearSelection();
        }

        private void Activar()
        {
            this.comboBox_area.Enabled = true;
            this.comboBox_grupo.Enabled = true;
            this.comboBox_area2.Enabled = true;
            this.ComboBox_grupo2.Enabled = true;
            this.dataGridView1.Enabled = true;
            this.textBox_nombre.Text = "";
        }

        private void ComboBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_grupo.Enabled = true;
            Listar.Grupo(this.comboBox_grupo, this.comboBox_area);
            if(this.comboBox_grupo.Items.Count == 1)
            {
                this.comboBox_grupo.Text = this.comboBox_grupo.Items[0].ToString();
                this.comboBox_grupo.Enabled = false;
            }
            this.comboBox_grupo.Enabled = true;
        }

        private void ComboBox_area2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Grupo(ComboBox_grupo2, comboBox_area2);
            _listarPersonas = ControladorFachada.MostrarPersonas(this.comboBox_area2.Text,string.Empty);
            RefrescarDataGrid();
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            //Agregar una nueva persona
            if (this.button_Agregar.Text == "Agregar")
            {
                if ((this.textBox_nombre.Text.Length == 0) || (this.comboBox_area.Text.Length == 0))
                {
                    if ((this.comboBox_grupo.Items.Count == 1) && (this.comboBox_grupo.Text.Length == 0))
                    {
                        MessageBox.Show("Falta seleccionar el grupo al que pertenece la persona");
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar datos");
                    }

                }
                else
                {
                    switch (ControladorFachada.VerificarNombre(this.textBox_nombre.Text.ToUpper()))
                    {
                        case -1:
                            //Nombre disponible
                            string _contraseña = "";
                            V_ingresarPassword v_pass = new V_ingresarPassword()
                            {
                                Nombre = this.textBox_nombre.Text,
                            };
                            v_pass.linkLabel1.Visible = false;
                            v_pass.ShowDialog(this);
                            _contraseña = v_pass.Contraseña;
                            if (v_pass.Guardar)
                            {
                                int _idPersona = ControladorFachada.AgregarPersona(this.textBox_nombre.Text.ToUpper(), _contraseña, this.comboBox_grupo.Text.ToUpper());
                                switch (_idPersona)
                                {
                                    case -1:
                                        //Guardado con éxito
                                        MessageBox.Show("Agregado con éxito");
                                        break;
                                    case -2:
                                        //Ocurre un problema
                                        MessageBox.Show("Ocurió un problema. Inténtelo nuevamente");
                                        break;
                                    default:
                                        //Nombre ya existente
                                        MessageBox.Show("El nombre de la persona ya existe");
                                        break;
                                }
                            }
                            this.Show();
                            break;
                        case -2:
                            //Ocurre un problema
                            MessageBox.Show("Ocurrió un problema. Inténtelo nuevamente");
                            break;
                        default:
                            //Nombre ya ocupado
                            MessageBox.Show("Nombre ya existente");
                            break;
                    }
                }
            }

            //Modificar datos de la persona
            else
            {
                if (this.textBox_nombre.Text.Length == 0)
                {
                    MessageBox.Show("Faltan ingresar nombre de persona");
                }
                else
                {
                    if (this.NombreAntiguo != this.textBox_nombre.Text.ToUpper())
                    {
                        switch (ControladorFachada.VerificarNombre(this.textBox_nombre.Text.ToUpper()))
                        {
                            case -1:
                                //Nombre disponible
                                string _contraseña = "";
                                V_ingresarPassword v_pass = new V_ingresarPassword()
                                {
                                    Text = "Cambiar Contraseña",
                                    Nombre = this.textBox_nombre.Text,
                                };
                                v_pass.linkLabel1.Visible = false;
                                v_pass.ShowDialog(this);
                                _contraseña = v_pass.Contraseña;
                                if (v_pass.Guardar)
                                {
                                    this.button_Agregar.Text = "Agregar";
                                    if (ControladorFachada.ModificarPersona(this.NombreAntiguo, this.textBox_nombre.Text.ToUpper(), _contraseña))
                                    {
                                        //Modificó bien
                                        MessageBox.Show("Modificado con éxito");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un problema que impidó la modificación");
                                    }
                                    Activar();
                                }
                                this.Show();
                                break;
                            case -2:
                                //Ocurre un problema
                                MessageBox.Show("Ocurrió un problema. Inténtelo nuevamente");
                                break;
                            default:
                                //Nombre ya ocupado
                                MessageBox.Show("Nombre ya existente");
                                break;
                        }
                    }

                    else
                    {
                        string _contraseña = "";
                        V_ingresarPassword v_pass = new V_ingresarPassword()
                        {
                            Text = "Cambiar Contraseña",
                            Nombre = this.textBox_nombre.Text,
                        };
                        v_pass.linkLabel1.Visible = false;
                        v_pass.ShowDialog(this);
                        _contraseña = v_pass.Contraseña;
                        if (v_pass.Guardar)
                        {
                            this.button_Agregar.Text = "Agregar";
                            if (ControladorFachada.ModificarPersona(this.NombreAntiguo, _contraseña))
                            {
                                Activar();
                                MessageBox.Show("Modificado con éxito");
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un problema. Inténtelo nuevamente");
                            }
                        }
                    }
                }
            }
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox_grupo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listarPersonas = ControladorFachada.MostrarPersonas(string.Empty, ComboBox_grupo2.Text);
            RefrescarDataGrid();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listarPersonas.Count))
            {
                Button_Modificar.Enabled = true;
                Button_Eliminar.Enabled = true;
                _idPersona = e.RowIndex;
            }
            else
            {
                Button_Modificar.Enabled = false;
                Button_Eliminar.Enabled = false;
            }
        }

        private void Button_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea dar de baja a " + _listarPersonas[_idPersona].Nombre + " de la lista?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ControladorFachada.EliminarPersona(_listarPersonas[_idPersona].Nombre);
                _listarPersonas.RemoveAt(_idPersona);
                RefrescarDataGrid();
                Button_Modificar.Enabled = false;
                Button_Eliminar.Enabled = false;
            }
        }

        private void Button_Modificar_Click(object sender, EventArgs e)
        {
            this.button_Agregar.Text = "Aceptar";
            this.textBox_nombre.Text = _listarPersonas[_idPersona].Nombre;
            this.NombreAntiguo = _listarPersonas[_idPersona].Nombre;
            Desactivar();
        }
    }
}
