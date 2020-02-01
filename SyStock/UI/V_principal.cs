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
    public partial class V_principal : Form
    {
        public V_principal()
        {
            InitializeComponent();
        }
        
        #region Definir Variables
        private readonly Fachada _controlador = Fachada.Instancia;

        private readonly Listar _listar = new Listar();

        private readonly List<Insumo> _listarInsumos = new List<Insumo>();

        public Insumo _insAlmacenado = new Insumo("", "", 0, 0, true, 0);

        public Insumo _ins = new Insumo("", "", 0, 0, true, 0);

        private int _idInsumo = 0;

        private bool _cerrarSesion = false;

        public bool _modificar = false;
        #endregion

        private void V_principal_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;
            int _height = screen.Bounds.Height - 50;
            int _width = screen.Bounds.Width;

            this.Size = new Size(_width, _height);

            if (_controlador.EsAdmin())
            {
                EsAdmin();
            }
            else
            {
                EsUsuario();
            }
            _listar.Areas(this.comboBox_area);
            _listar.Persona(this.comboBox_persona);
            _listar.Categorias(this.comboBox_categoria);
            _listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var _insumo in _listarInsumos)
            {
                if (_insumo != null)
                {
                    String[] row;
                    row = new String[] { Convert.ToString(_insumo.Cantidad), _insumo.Nombre };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        #region Menú
        private void ModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_UsuarioModificar v_modificarUsuario = new V_UsuarioModificar()
            {
                usuarioLogeado = true,
            };
            v_modificarUsuario.ShowDialog(this);
            this.Show();
        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea Cerrar Sesión?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this._cerrarSesion = true;
                this.Close();
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea Salir?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this._cerrarSesion = false;
                this.Close();
            }
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Usuario v_usuario = new V_Usuario();
            v_usuario.Show();
        }

        private void ActualizarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_ActualizarStock v_ActualizarStock = new V_ActualizarStock();
            v_ActualizarStock.Show();
        }

        private void ListaInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Insumos v_Insumos = new V_Insumos();
            v_Insumos.Show();
        }

        private void AgregarÁreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Area v_Area = new V_Area();
            v_Area.Show();
        }

        private void PersonasAutorizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_PersonasAutorizadas v_personasAutorizadas = new V_PersonasAutorizadas();
            v_personasAutorizadas.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Consulta v_consulta = new V_Consulta();
            v_consulta.Show();
        }
        #endregion

        private void V_principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._cerrarSesion)
            {
                (new V_login()).Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void EsAdmin()
        {
            this.usuariosToolStripMenuItem.Visible = true;
        }

        private void EsUsuario()
        {
            this.usuariosToolStripMenuItem.Visible = false;
        }

        #region Persona Retira
        private void ComboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Grupo(this.comboBox_grupo, this.comboBox_area);

            if (this.comboBox_grupo.Items.Count == 1)
            {
                comboBox_persona.Enabled = true;
                this.comboBox_grupo.Enabled = false;
                _listar.Persona(comboBox_persona, comboBox_area.Text);
            }
            else
            {
                this.comboBox_persona.Enabled = false;
                this.comboBox_grupo.Enabled = true;
                
            }
        }

        private void Button_AgregarArea_Click(object sender, EventArgs e)
        {
            V_Area v_Area = new V_Area();
            v_Area.Show();
            _listar.Areas(this.comboBox_area);
            _listar.Grupo(this.comboBox_grupo);
            _listar.Persona(this.comboBox_persona);
        }

        private void ComboBox_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_persona.Enabled = true;
            _listar.Persona(this.comboBox_persona, this.comboBox_grupo.Text);
        }

        private void Button_AgregarPersonaRetira_Click(object sender, EventArgs e)
        {
            V_PersonasAutorizadas v_PersonaRetira = new V_PersonasAutorizadas();
            v_PersonaRetira.ShowDialog(this);
            if (comboBox_area.Text != String.Empty)
            {
                v_PersonaRetira._area = comboBox_area.Text;
            }

            if (comboBox_grupo.Text != String.Empty)
            {
                v_PersonaRetira._grupo = comboBox_grupo.Text;
            }
            this.Show();
            _listar.Persona(this.comboBox_persona);
        }

        private void Autorizar()
        {
            string _contraseña = "";
            V_ingresarPassword v_pass = new V_ingresarPassword()
            {
                _nombre = comboBox_persona.Text,
                _verificar = true,
            };
            v_pass.linkLabel1.Visible = true;
            v_pass.ShowDialog(this);
            _contraseña = v_pass._contraseña;
            if (v_pass._guardar)
            {
                AgregarEntrega();
            }
        }
        #endregion

        #region Opciones Insumos
        private void ComboBox_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
        }

        private void ComboBox_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listar.Cantidad(this.comboBox_cantidad, this.comboBox_nombre);
            if (this.comboBox_cantidad.Items.Count == 0)
            {
                MessageBox.Show("Usted no tiene stock disponible de este Insumo");
            }
            _insAlmacenado = _controlador.ObtenerInsumo(this.comboBox_nombre.Text);
        }

        private void AgregarInsumo(string pNombre, int pCantidad)
        {
            Insumo _ins2 = new Insumo("", "", 0, 0, true, 0);
            _ins2 = _controlador.ObtenerInsumo(pNombre);
            _ins2.Cantidad = pCantidad;
            int posicion = 0;
            int _i = 0;
            while ((posicion==0) && (_listarInsumos.Count() >= _i+1))
            {
                _insAlmacenado = _controlador.ObtenerInsumo(_listarInsumos[_i].Nombre);
                if (_listarInsumos[_i].Nombre == _ins2.Nombre)
                {
                    posicion = 1;
                    int cantidadRetirar = _listarInsumos[_i].Cantidad + _ins2.Cantidad;
                    if (_insAlmacenado.Cantidad < cantidadRetirar)
                    {
                        MessageBox.Show("Usted solo dispone de " + _insAlmacenado.Cantidad + " unidades de " + _insAlmacenado.Nombre);
                    }
                    else
                    {
                        _listarInsumos[_i].Cantidad = cantidadRetirar;
                        int cantidadMinima = _insAlmacenado.Cantidad - cantidadRetirar;
                        if (_insAlmacenado.CantidadMinima >=  cantidadMinima)
                        {
                            MessageBox.Show("En stock solo dispone "+ cantidadMinima + " unidades de " + _insAlmacenado.Nombre, "Stock Mínimo");
                        }
                        RefrescarDataGrid(); 
                    }
                    _i = _listarInsumos.Count();
                }
                _i= _i+1;
            }
            if (posicion == 0)
            {
                int cantidadMinima = _ins2.Cantidad;
                if (_insAlmacenado.CantidadMinima >= cantidadMinima)
                {
                    int cant = _controlador.ObtenerInsumo(pNombre).Cantidad - cantidadMinima;
                    MessageBox.Show("En stock solo dispone " + cant + " unidades de " + _insAlmacenado.Nombre, "Stock Mínimo");
                }
                _listarInsumos.Add(_ins2);
            }
            RefrescarDataGrid();
            comboBox_nombre.Items.Clear();
            _listar.Categorias(this.comboBox_categoria);
            _listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            comboBox_cantidad.Items.Clear();
            comboBox_cantidad.Text = "";
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            if ((this.comboBox_nombre.Text == "") || (this.comboBox_cantidad.Text == "") || (this.comboBox_cantidad.Text == "0"))
            {
                MessageBox.Show("Faltan agregar campos obligatorios");
            }
            else
            {
                if (_insAlmacenado.Cantidad < Convert.ToInt32(this.comboBox_cantidad.Text))
                {
                    MessageBox.Show("Usted solo dispone de " + _insAlmacenado.Cantidad + " unidades de " + _insAlmacenado.Nombre);
                }
                else
                {
                    AgregarInsumo(comboBox_nombre.Text, Convert.ToInt32(comboBox_cantidad.Text));
                }
            }
        }

        private void Button_EliminarInsumo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a " + _listarInsumos[_idInsumo].Nombre + " de la lista?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _listarInsumos.RemoveAt(_idInsumo);
                RefrescarDataGrid();
                LimpiarModificar();
            }
        }

        private void ButtonAgregarInsumo_Click(object sender, EventArgs e)
        {
            LimpiarModificar();
        }
        #endregion

        private void LimpiarTodo()
        {
            _listar.Areas(this.comboBox_area);
            this.comboBox_grupo.Items.Clear();
            this.comboBox_grupo.Enabled = false;
            this.comboBox_persona.Items.Clear();
            this.comboBox_persona.Text = "";
            this.comboBox_categoria.Text = "";
            _listar.Categorias(this.comboBox_categoria);
            this.comboBox_nombre.Text = "";
            _listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            this.comboBox_cantidad.Text = "";
            this.comboBox_cantidad.Items.Clear();
            _listar.Persona(this.comboBox_persona);
            this.textBoxPersonaRetira.Text = "";
            _listarInsumos.Clear();
            this.dataGridView1.Rows.Clear();
        }
        
        private void LimpiarModificar()
        {
            comboBox_categoria.Enabled = true;
            _listar.Categorias(this.comboBox_categoria);
            comboBox_nombre.Enabled = true;
            _listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            comboBox_cantidad.Items.Clear();
            comboBox_cantidad.Text = "";
        }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            if (this.comboBox_persona.Text == string.Empty)
            {
                MessageBox.Show("Falta seleccionar la persona que retira");
            }
            else
            {
                if(_listarInsumos.Count() == 0)
                {
                    MessageBox.Show("Falta agregar insumos");
                }
                else
                {
                    Autorizar();
                }
            }
        }

        private void AgregarEntrega()
        {
            int idEntrega = _controlador.AgregarEntrega(this.comboBox_persona.Text);
            switch (idEntrega)
            {
                case -2:
                    MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
                    break;
                default:
                    AgregarRenglon(idEntrega);
                    break;
            }
        }

        private void Button_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }    

        private void Modificar(int pIdInsumo)
        {
            _ins.Nombre = _listarInsumos[pIdInsumo].Nombre;
            _idInsumo = pIdInsumo;
            _ins.Cantidad = Convert.ToInt32(_listarInsumos[pIdInsumo].Cantidad);
            _insAlmacenado = _controlador.ObtenerInsumo(_ins.Nombre);
            comboBox_categoria.Enabled = false;
            comboBox_nombre.Text = _ins.Nombre;
            comboBox_nombre.Enabled = false;
            comboBox_cantidad.Text = Convert.ToString(_ins.Cantidad);
            _listar.Cantidad(this.comboBox_cantidad, this.comboBox_nombre);
        }

        private bool AgregarRenglon(int idEntrega)
        {
            int idRenglon = _controlador.AgregarRenglon(idEntrega, _listarInsumos);
            if (idRenglon == -2)
            {
                MessageBox.Show("Ocurrió un error, inténtelo nuevamente");
                return false;
            }
            else
            {
                LimpiarTodo();
                return true;
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listarInsumos.Count()))
            {
                Button_EliminarInsumo.Enabled = true;
                Modificar(e.RowIndex);
            }
            else
            {
                LimpiarModificar();
                Button_EliminarInsumo.Enabled = false;
            }
        }

        private void ComboBox_persona_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxPersonaRetira.Text = this.comboBox_persona.Text;
        }

        private void Button_EliminarInsumo_Click_1(object sender, EventArgs e)
        {

        }
    }
}
