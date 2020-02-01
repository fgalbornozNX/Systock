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

namespace SyStock.UI
{
    public partial class V_Area : Form
    {
        public V_Area()
        {
            InitializeComponent();
        }

        private readonly Fachada Controlador = Fachada.Instancia;

        private readonly Listar _listar = new Listar();

        private bool _grupo = false;

        private string _nombre = "";

        private void V_Area_Load(object sender, EventArgs e)
        {
            RefrescarAreas();
            RefrescarGrupos();
        }

        private void RefrescarAreas()
        {
            _listar.Areas(this.comboBox_area);
            this.comboBox_area.DropDownStyle = ComboBoxStyle.DropDown;
            _listar.Areas(this.comboBox_filtrarArea);
            _listar.Areas(this.listBox_area);
            _listar.Areas(this.comboBox_areaPersona);
        }

        private void RefrescarGrupos()
        {
            _listar.Grupo(this.comboBox_grupoPersona);
            if (this.comboBox_filtrarArea.Text == string.Empty)
            {
                _listar.Grupo(this.listBox_grupos);
            }
            else
            {
                _listar.Grupo(this.listBox_grupos, this.comboBox_filtrarArea); 
            }
            this.checkBox1.Checked = false;
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            if (this.Button_Agregar.Text == "Agregar")
            {
                if (this.comboBox_area.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar nombre de Área");
                }
                else
                {
                    if (!this.checkBox1.Checked)
                    {
                        AgregarArea();
                        RefrescarAreas();
                    }
                    else
                    {
                        AgregarAreaGrupo();
                        RefrescarAreas();
                        RefrescarGrupos();
                    }
                }
            }
            //Aceptar una modificación
            else
            {
                if (_grupo)
                {
                    if (this.textBox_grupo.Text == string.Empty)
                    {
                        MessageBox.Show("Falta ingresar nombre de grupo");
                    }
                    else
                    {
                        if (Controlador.ModificarGrupo(_nombre, this.textBox_grupo.Text.ToUpper()))
                        {
                            this.Button_Agregar.Text = "Agregar";
                            ActivarTodo();
                            MessageBox.Show("Modificado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un problema, inténtelo nuevamente");
                        }
                    }
                }
                else
                {
                    if (this.comboBox_area.Text == string.Empty)
                    {
                        MessageBox.Show("Falta ingresar nombre de área");
                    }
                    else
                    {
                        if (Controlador.ModificarArea(_nombre, this.comboBox_area.Text.ToUpper()))
                        {
                            this.Button_Agregar.Text = "Agregar";
                            ActivarTodo();
                            MessageBox.Show("Modificado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un problema, inténtelo nuevamente");
                        }
                    }
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_grupo.Text = string.Empty;
            if (this.checkBox1.Checked == true)
            {
                this.textBox_grupo.Enabled = true;
            }
            else
                this.textBox_grupo.Enabled = false;
        }

        private void AgregarArea()
        {
            int idArea = Controlador.AgregarArea(this.comboBox_area.Text.ToUpper());
            switch (idArea)
                {
                case -1:
                    AgregarGrupo(this.comboBox_area.Text.ToUpper(), this.comboBox_area.Text.ToUpper(), false);
                    break;
                case -2:
                    MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
                    break;
                default:
                    MessageBox.Show("Nombre de área ya existente");
                    break;
            }
        }

        private void AgregarAreaGrupo()
        {
            int idArea = Controlador.AgregarArea(this.comboBox_area.Text.ToUpper());
            switch (idArea)
            {
                case -1:
                    AgregarGrupo(this.comboBox_area.Text.ToUpper(), this.comboBox_area.Text.ToUpper(), true);
                    AgregarGrupo(this.textBox_grupo.Text.ToUpper(), this.comboBox_area.Text.ToUpper(), false);
                    break;
                case -2:
                    MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
                    break;
                default:
                    AgregarGrupo(this.textBox_grupo.Text.ToUpper(), this.comboBox_area.Text.ToUpper(), false);
                    break;
            }
        }

        private void AgregarGrupo(string grupo, string area, bool AgregarAmbos)
        {
            int idGrupo = Controlador.AgregarGrupo(grupo, area);
            switch (idGrupo)
            {
                case -1:
                    if (!AgregarAmbos)
                    {
                        MessageBox.Show("Agregado con éxito");
                    }
                    break;
                case -2:
                    MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
                    break;
                default:
                    MessageBox.Show("Nombre de grupo ya existente");
                    break;
            }
        }

        private void ComboBox_filtrarArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrupos();
        }

        private void Button_AgregarPersona_Click(object sender, EventArgs e)
        {
            if ((this.textBox_nombrePersona.Text == string.Empty) || (this.comboBox_grupoPersona.Text == string.Empty))
            {
                MessageBox.Show("Falta ingresar datos obligatorios");
            }
            else
            {
                string _contraseña = "";
                V_ingresarPassword v_pass = new V_ingresarPassword()
                {
                    _nombre = this.textBox_nombrePersona.Text,
                };
                v_pass.ShowDialog(this);
                _contraseña = v_pass._contraseña;
                if (v_pass._guardar)
                {
                    Controlador.AgregarPersona(this.textBox_nombrePersona.Text.ToUpper(), _contraseña, this.comboBox_grupoPersona.Text.ToUpper());
                }
                this.Show();
                this.comboBox_areaPersona.Text = "";
                this.comboBox_grupoPersona.Text = "";
                this.textBox_nombrePersona.Text = "";
            }
        }

        private void ComboBox_areaPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Grupo(comboBox_grupoPersona, comboBox_areaPersona);
            if (comboBox_grupoPersona.Items.Count == 1)
            {
                this.comboBox_grupoPersona.Text = this.comboBox_areaPersona.Text;
                this.comboBox_grupoPersona.Enabled = false;
            }
            else
            {
                this.comboBox_grupoPersona.Enabled = true;
            }
        }

        private void ActivarModificarArea(string pNombre)
        {
            this.comboBox_area.Enabled = true;
            this.comboBox_area.Items.Clear();
            this.comboBox_area.Text = pNombre;
            this.textBox_grupo.Enabled = false;
            this.checkBox1.Visible = false;
            _grupo = false;
        }

        private void ActivarModificarGrupo(string pNombre)
        {
            this.comboBox_area.Enabled = false;
            this.textBox_grupo.Text = pNombre;
            this.textBox_grupo.Enabled = true;
            this.checkBox1.Visible = false;
            _grupo = true;
        }

        private void DesactivarPersona()
        {
            comboBox_areaPersona.Enabled = false;
            comboBox_grupoPersona.Enabled = false;
            textBox_nombrePersona.Enabled = false;
        }

        private void ActivarTodo()
        {
            this.comboBox_area.Text = "";
            this.textBox_grupo.Text = "";
            comboBox_areaPersona.Enabled = true;
            comboBox_grupoPersona.Enabled = true;
            textBox_nombrePersona.Enabled = true;
            this.button_AgregarPersona.Enabled = true;
            this.comboBox_area.Enabled = true;
            RefrescarAreas();
            RefrescarGrupos();
            this.textBox_grupo.Enabled = true;
            this.comboBox_filtrarArea.Enabled = true;
            this.checkBox1.Visible = true;
            tabControl1.Enabled = true;
        }

        private void Button_modificar_Click(object sender, EventArgs e)
        {
            this.button_AgregarPersona.Enabled = false;
            this.Button_Agregar.Text = "Aceptar";
            this.comboBox_filtrarArea.Enabled = false;

            if (this.tabPage1.Focus())
            {
                _nombre = listBox_area.SelectedItem.ToString();
                ActivarModificarArea(_nombre);
                listBox_area.ClearSelected();
                tabControl1.Enabled = false;
                DesactivarPersona();
            }
            if (this.tabPage2.Focus())
            {
                _nombre = listBox_grupos.SelectedItem.ToString();
                ActivarModificarGrupo(_nombre);
                listBox_grupos.ClearSelected();
                tabControl1.Enabled = false;
                DesactivarPersona();
            }
            this.Button_modificar.Enabled = false;
        }

        private void ListBox_areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button_modificar.Enabled = true;

        }

        private void ListBox_grupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button_modificar.Enabled = true;
        }

        private void ListBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button_modificar.Enabled = true;
        }
    }
}