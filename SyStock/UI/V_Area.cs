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

        /// <summary>
        /// Método para cargar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void V_Area_Load(object sender, EventArgs e)
        {
            RefrescarAreas();
            RefrescarGrupos();
        }

        /// <summary>
        /// Actualiza el listado de áreas
        /// </summary>
        private void RefrescarAreas()
        {
            _listar.Areas(this.comboBox_area);
            this.comboBox_area.DropDownStyle = ComboBoxStyle.DropDown;
            _listar.Areas(this.comboBox_filtrarArea);
            _listar.Areas(this.listBox_area);
            _listar.Areas(this.comboBox_areaPersona);
        }

        /// <summary>
        /// Actualiza el listado de grupos
        /// </summary>
        private void RefrescarGrupos()
        {
            _listar.Grupo(this.comboBox_grupoPersona);
            if (string.IsNullOrEmpty(this.comboBox_filtrarArea.Text))
            {
                _listar.Grupo(this.listBox_grupos);
            }
            else
            {
                _listar.Grupo(this.listBox_grupos, this.comboBox_filtrarArea); 
            }
            this.checkBox1.Checked = false;
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
        /// Método para el botón "agregar" área
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            if (this.Button_Agregar.Text == "Agregar")
            {
                if (string.IsNullOrEmpty(this.comboBox_area.Text))
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
                    if (string.IsNullOrEmpty(this.textBox_grupo.Text))
                    {
                        MessageBox.Show("Falta ingresar nombre de grupo");
                    }
                    else
                    {
                        if (Controlador.ModificarGrupo(_nombre, this.textBox_grupo.Text))
                        {
                            this.Button_Agregar.Text = "Agregar";
                            ActivarTodo();
                            MessageBox.Show("Modificado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Nombre de grupo ya existente");
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
                            MessageBox.Show("Nombre de área ya existente");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método para activar o desactivar agregar grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para agregar una nueva área
        /// </summary>
        private void AgregarArea()
        {
            try
            {
                int idArea = Controlador.AgregarArea(this.comboBox_area.Text);
                switch (idArea)
                {
                    case -1:
                        AgregarGrupo(this.comboBox_area.Text, this.comboBox_area.Text, false);
                        break;
                    default:
                        MessageBox.Show("Nombre de área ya existente");
                        break;
                }
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Método para agregar un área y un grupo
        /// </summary>
        private void AgregarAreaGrupo()
        {
            try
            {
                int idArea = Controlador.AgregarArea(this.comboBox_area.Text);
                switch (idArea)
                {
                    case -1:
                        AgregarGrupo(this.comboBox_area.Text, this.comboBox_area.Text, true);
                        AgregarGrupo(this.textBox_grupo.Text, this.comboBox_area.Text, false);
                        break;
                    default:
                        AgregarGrupo(this.textBox_grupo.Text, this.comboBox_area.Text, false);
                        break;
                }
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método para agregar un grupo
        /// </summary>
        /// <param name="grupo">Nombre del grupo a agregar</param>
        /// <param name="area">Nombre del área a agregar</param>
        /// <param name="AgregarAmbos">False para agregar solo un grupo</param>
        private void AgregarGrupo(string grupo, string area, bool AgregarAmbos)
        {
            try
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
                    default:
                        MessageBox.Show("Nombre de grupo ya existente");
                        break;
                }
            }
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza el listado de grupos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_filtrarArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrupos();
        }

        /// <summary>
        /// Método para agregar una nueva persona 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AgregarPersona_Click(object sender, EventArgs e)
        {
            try
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
            catch (LogicaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método para listar las personas dependiendo del área y grupo seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para modificar una determinada área
        /// </summary>
        /// <param name="pNombre">Nombre del área</param>
        private void ActivarModificarArea(string pNombre)
        {
            this.comboBox_area.Enabled = true;
            this.comboBox_area.Items.Clear();
            this.comboBox_area.Text = pNombre;
            this.textBox_grupo.Enabled = false;
            this.checkBox1.Visible = false;
            _grupo = false;
        }

        /// <summary>
        /// Método para modificar un determinado grupo
        /// </summary>
        /// <param name="pNombre">Nombre del grupo</param>
        private void ActivarModificarGrupo(string pNombre)
        {
            this.comboBox_area.Enabled = false;
            this.textBox_grupo.Text = pNombre;
            this.textBox_grupo.Enabled = true;
            this.checkBox1.Visible = false;
            _grupo = true;
        }

        /// <summary>
        /// Desactiva los campos para agregar una persona
        /// </summary>
        private void DesactivarPersona()
        {
            comboBox_areaPersona.Enabled = false;
            comboBox_grupoPersona.Enabled = false;
            textBox_nombrePersona.Enabled = false;
        }

        /// <summary>
        /// Método para lipiar la ventana
        /// </summary>
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

        /// <summary>
        /// Método para modificar una determinada área o grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para activar el bóton de modificar un determinado grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_grupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button_modificar.Enabled = true;
        }

        /// <summary>
        /// Método para activar el bóton de modificar una determinada área
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button_modificar.Enabled = true;
        }
    }
}