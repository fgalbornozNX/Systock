using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly List<Insumo> _listarInsumos = new List<Insumo>();

        public Insumo InsumoAlmacenado { get; set; }

        public Insumo Insumo { get; set; }

        public bool Modificado { get; set; }

        private int idInsumo = 0;

        private bool cerrarSesion = false;
        #endregion

        private void V_principal_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;
            int _height = screen.Bounds.Height - 50;
            int _width = screen.Bounds.Width;

            this.Size = new Size(_width, _height);

            if (ControladorFachada.EsAdmin())
            {
                EsAdmin();
            }
            else
            {
                EsUsuario();
            }
            Listar.Areas(this.comboBox_area);
            Listar.Persona(this.comboBox_persona);
            Listar.Categorias(this.comboBox_categoria);
            Listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
        }

        private void RefrescarDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.ColumnHeadersVisible = true;

            foreach (var insumo in _listarInsumos)
            {
                if (insumo != null)
                {
                    String[] row;
                    row = new String[] { Convert.ToString(insumo.Cantidad), insumo.Nombre };
                    this.dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
        }

        #region Menú
        private void ModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_UsuarioModificar vmodificarUsuario = new V_UsuarioModificar()
            {
                UsuarioLogeado = true,
            };
            vmodificarUsuario.ShowDialog(this);
            this.Show();
        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea Cerrar Sesión?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.cerrarSesion = true;
                this.Close();
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea Salir?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.cerrarSesion = false;
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
            if (this.cerrarSesion)
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
            Listar.Grupo(this.comboBox_grupo, this.comboBox_area);

            if (this.comboBox_grupo.Items.Count == 1)
            {
                comboBox_persona.Enabled = true;
                this.comboBox_grupo.Enabled = false;
                Listar.Persona(comboBox_persona, comboBox_area.Text);
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
            Listar.Areas(this.comboBox_area);
            Listar.Grupo(this.comboBox_grupo);
            Listar.Persona(this.comboBox_persona);
        }

        private void ComboBox_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_persona.Enabled = true;
            Listar.Persona(this.comboBox_persona, this.comboBox_grupo.Text);
        }

        private void Button_AgregarPersonaRetira_Click(object sender, EventArgs e)
        {
            V_PersonasAutorizadas v_PersonaRetira = new V_PersonasAutorizadas();
            v_PersonaRetira.ShowDialog(this);
            if (comboBox_area.Text.Length != 0)
            {
                v_PersonaRetira.Area = comboBox_area.Text;
            }

            if (comboBox_grupo.Text.Length != 0)
            {
                v_PersonaRetira.Grupo = comboBox_grupo.Text;
            }
            this.Show();
            Listar.Persona(this.comboBox_persona);
        }

        private void Autorizar()
        {
            string _contraseña = "";
            V_ingresarPassword v_pass = new V_ingresarPassword()
            {
                Nombre = comboBox_persona.Text,
                Verificar = true,
            };
            v_pass.linkLabel1.Visible = true;
            v_pass.ShowDialog(this);
            _contraseña = v_pass.Contraseña;
            if (v_pass.Guardar)
            {
                AgregarEntrega();
            }
        }
        #endregion

        #region Opciones Insumos
        private void ComboBox_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
        }

        private void ComboBox_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar.Cantidad(this.comboBox_cantidad, this.comboBox_nombre);
            if (this.comboBox_cantidad.Items.Count == 0)
            {
                MessageBox.Show("Usted no tiene stock disponible de este Insumo");
            }
            this.InsumoAlmacenado = ControladorFachada.ObtenerInsumo(this.comboBox_nombre.Text);
        }

        private void AgregarInsumo(string pNombre, int pCantidad)
        {
            Insumo ins2 = new Insumo("", "", 0, 0, true, 0);
            ins2 = ControladorFachada.ObtenerInsumo(pNombre);
            ins2.Cantidad = pCantidad;
            int posicion = 0;
            int _i = 0;
            while ((posicion==0) && (_listarInsumos.Count >= _i+1))
            {
                this.InsumoAlmacenado = ControladorFachada.ObtenerInsumo(_listarInsumos[_i].Nombre);
                if (_listarInsumos[_i].Nombre == ins2.Nombre)
                {
                    posicion = 1;
                    int cantidadRetirar = _listarInsumos[_i].Cantidad + ins2.Cantidad;
                    if (this.InsumoAlmacenado.Cantidad < cantidadRetirar)
                    {
                        MessageBox.Show("Usted solo dispone de " + this.InsumoAlmacenado.Cantidad + " unidades de " + this.InsumoAlmacenado.Nombre);
                    }
                    else
                    {
                        _listarInsumos[_i].Cantidad = cantidadRetirar;
                        int cantidadMinima = this.InsumoAlmacenado.Cantidad - cantidadRetirar;
                        if (this.InsumoAlmacenado.CantidadMinima >=  cantidadMinima)
                        {
                            MessageBox.Show("En stock solo dispone "+ cantidadMinima + " unidades de " + this.InsumoAlmacenado.Nombre, "Stock Mínimo");
                        }
                        RefrescarDataGrid(); 
                    }
                    _i = _listarInsumos.Count;
                }
                _i= _i+1;
            }
            if (posicion == 0)
            {
                int cantidadMinima = ins2.Cantidad;
                if (this.InsumoAlmacenado.CantidadMinima >= cantidadMinima)
                {
                    int cant = ControladorFachada.ObtenerInsumo(pNombre).Cantidad - cantidadMinima;
                    MessageBox.Show("En stock solo dispone " + cant + " unidades de " + this.InsumoAlmacenado.Nombre, "Stock Mínimo");
                }
                _listarInsumos.Add(ins2);
            }
            RefrescarDataGrid();
            comboBox_nombre.Items.Clear();
            Listar.Categorias(this.comboBox_categoria);
            Listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            comboBox_cantidad.Items.Clear();
            comboBox_cantidad.Text = "";
        }

        private void Button_Agregar_Click(object sender, EventArgs e)
        {
            if ((this.comboBox_nombre.Text.Length == 0) || (this.comboBox_cantidad.Text.Length == 0) || (this.comboBox_cantidad.Text == "0"))
            {
                MessageBox.Show("Faltan agregar campos obligatorios");
            }
            else
            {
                if (this.InsumoAlmacenado.Cantidad < Convert.ToInt32(this.comboBox_cantidad.Text))
                {
                    MessageBox.Show("Usted solo dispone de " + this.InsumoAlmacenado.Cantidad + " unidades de " + this.InsumoAlmacenado.Nombre);
                }
                else
                {
                    AgregarInsumo(comboBox_nombre.Text, Convert.ToInt32(comboBox_cantidad.Text));
                }
            }
        }

        private void Button_EliminarInsumo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a " + _listarInsumos[idInsumo].Nombre + " de la lista?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _listarInsumos.RemoveAt(idInsumo);
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
            Listar.Areas(this.comboBox_area);
            this.comboBox_grupo.Items.Clear();
            this.comboBox_grupo.Enabled = false;
            this.comboBox_persona.Items.Clear();
            this.comboBox_persona.Text = "";
            this.comboBox_categoria.Text = "";
            Listar.Categorias(this.comboBox_categoria);
            this.comboBox_nombre.Text = "";
            Listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            this.comboBox_cantidad.Text = "";
            this.comboBox_cantidad.Items.Clear();
            Listar.Persona(this.comboBox_persona);
            this.textBoxPersonaRetira.Text = "";
            _listarInsumos.Clear();
            this.dataGridView1.Rows.Clear();
        }
        
        private void LimpiarModificar()
        {
            comboBox_categoria.Enabled = true;
            Listar.Categorias(this.comboBox_categoria);
            comboBox_nombre.Enabled = true;
            Listar.Insumos(this.comboBox_nombre, this.comboBox_categoria);
            comboBox_cantidad.Items.Clear();
            comboBox_cantidad.Text = "";
        }

        private void Button_Aceptar_Click(object sender, EventArgs e)
        {
            if (this.comboBox_persona.Text.Length == 0)
            {
                MessageBox.Show("Falta seleccionar la persona que retira");
            }
            else
            {
                if(_listarInsumos.Count == 0)
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
            int idEntrega = ControladorFachada.AgregarEntrega(this.comboBox_persona.Text);
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
            this.Insumo.Nombre = _listarInsumos[pIdInsumo].Nombre;
            idInsumo = pIdInsumo;
            this.Insumo.Cantidad = Convert.ToInt32(_listarInsumos[pIdInsumo].Cantidad);
            this.InsumoAlmacenado = ControladorFachada.ObtenerInsumo(this.Insumo.Nombre);
            comboBox_categoria.Enabled = false;
            comboBox_nombre.Text = this.Insumo.Nombre;
            comboBox_nombre.Enabled = false;
            comboBox_cantidad.Text = Convert.ToString(this.Insumo.Cantidad);
            Listar.Cantidad(this.comboBox_cantidad, this.comboBox_nombre);
        }

        private bool AgregarRenglon(int idEntrega)
        {
            int idRenglon = ControladorFachada.AgregarRenglon(idEntrega, _listarInsumos);
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
            if ((dataGridView1.SelectedRows.Count == 1) && (e.RowIndex < _listarInsumos.Count))
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
