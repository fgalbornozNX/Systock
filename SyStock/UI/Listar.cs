using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyStock.Entidades;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public class Listar
    {
        private readonly ControladorFachada Controlador = ControladorFachada.Instancia;

        public void Insumos(ComboBox pComboBox_insumos, ComboBox pComboBox_categoria)
        {
            pComboBox_insumos.Items.Clear();
            pComboBox_insumos.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Insumo> _listaInsumos = new List<Insumo>();
            if (pComboBox_categoria.Text == "")
            {
                _listaInsumos = Controlador.ListarInsumos();
                _listaInsumos.Sort(delegate (Insumo a1, Insumo a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            }
            else
            {
                _listaInsumos = Controlador.ListarInsumos(pComboBox_categoria.Text);
                _listaInsumos.Sort(delegate (Insumo a1, Insumo a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            }

            for (int i = 0; i < _listaInsumos.Count; i++)
                pComboBox_insumos.Items.Add(_listaInsumos[i].Nombre);
        }

        public Insumo Cantidad(ComboBox comboBox_cantidad, ComboBox comboBox_nombre)
        {
            comboBox_cantidad.Items.Clear();
            //this.comboBox_cantidad.DropDownStyle = ComboBoxStyle.DropDownList;

            Insumo _ins = null;

            int _cantidad = 0;
            if (comboBox_nombre.Text == "")
            {
                _cantidad = 0;
            }
            else
            {
                _ins = Controlador.ObtenerInsumo(comboBox_nombre.Text);

                if (_ins == null)
                {
                    MessageBox.Show("No se encontró el insumo");
                }
                else
                {
                    _cantidad = _ins.Cantidad;
                }
            }

            for (int i = 0; i < _cantidad; i++)
                comboBox_cantidad.Items.Add(Convert.ToString(i + 1));
            return _ins;
        }

        public void Categorias(ComboBox comboBox_categoria)
        {
            comboBox_categoria.Items.Clear();
            if (comboBox_categoria.Name == "comboBox_filtrar")
            {
                comboBox_categoria.Items.Add("TODOS");
            }
            comboBox_categoria.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Categoria> _listaCategorias = new List<Categoria>();
            _listaCategorias = Controlador.ListarCategorias();
            _listaCategorias.Sort(delegate (Categoria a1, Categoria a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < _listaCategorias.Count; i++)
                comboBox_categoria.Items.Add(_listaCategorias[i].Nombre);
        }

        public void Categorias(DataGridView dataGrid_categoria, List<Categoria> _listaCategorias)
        {
            dataGrid_categoria.Rows.Clear();
            dataGrid_categoria.ColumnHeadersVisible = true;

            foreach (var _cat in _listaCategorias)
            {
                if (_cat != null)
                {
                    String[] row;
                    row = new String[] { _cat.Nombre };
                    dataGrid_categoria.Rows.Add(row);
                }
            }
            dataGrid_categoria.Refresh();
        }

        public void Areas(ComboBox pComboBox)
        {
            pComboBox.Items.Clear();
            pComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Area> _listaAreas = new List<Area>();
            _listaAreas = Controlador.ListarArea();
            _listaAreas.Sort(delegate (Area a1, Area a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < _listaAreas.Count; i++)
                pComboBox.Items.Add(_listaAreas[i].Nombre);
        }

        public void Areas(ListBox pListBox)
        {
            pListBox.Items.Clear();

            List<Area> _listaAreas = new List<Area>();
            _listaAreas = Controlador.ListarArea();
            _listaAreas.Sort(delegate (Area a1, Area a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < _listaAreas.Count; i++)
                pListBox.Items.Add(_listaAreas[i].Nombre);
        }

        public void Grupo(ComboBox pComboBox_grupo)
        {
            pComboBox_grupo.Items.Clear();
            pComboBox_grupo.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Grupo> _listaGrupo = new List<Grupo>();
            _listaGrupo = Controlador.ListarGrupos();
            _listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaGrupo.Count; i++)
                pComboBox_grupo.Items.Add(_listaGrupo[i].Nombre);
        }

        public void Grupo(ListBox pListBox_grupo)
        {
            pListBox_grupo.Items.Clear();

            List<Grupo> _listaGrupo = new List<Grupo>();
            _listaGrupo = Controlador.ListarGrupos();
            _listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaGrupo.Count; i++)
                pListBox_grupo.Items.Add(_listaGrupo[i].Nombre);
        }

        public void Grupo(ComboBox pComboBox_grupo, ComboBox pComboBox_area)
        {
            pComboBox_grupo.Items.Clear();
            pComboBox_grupo.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Grupo> _listaGrupo = new List<Grupo>();
            _listaGrupo = Controlador.ListarGrupos(pComboBox_area.Text);
            _listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaGrupo.Count; i++)
                pComboBox_grupo.Items.Add(_listaGrupo[i].Nombre);
        }

        public void Grupo(ListBox pListBox_grupo, ComboBox pComboBox_area)
        {
            pListBox_grupo.Items.Clear();

            List<Grupo> _listaGrupo = new List<Grupo>();
            _listaGrupo = Controlador.ListarGrupos(pComboBox_area.Text);
            _listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaGrupo.Count; i++)
                pListBox_grupo.Items.Add(_listaGrupo[i].Nombre);
        }

        public void Persona(ComboBox comboBox_persona)
        {
            comboBox_persona.Items.Clear();

            List<PersonaAutorizada> _listaPersonas = new List<PersonaAutorizada>();
            _listaPersonas = Controlador.ListarPersonas();
            _listaPersonas.Sort(delegate (PersonaAutorizada a1, PersonaAutorizada a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaPersonas.Count; i++)
                comboBox_persona.Items.Add(_listaPersonas[i].Nombre);
        }

        public void Persona(ComboBox comboBox_persona, string pGrupo)
        {
            comboBox_persona.Items.Clear();

            List<PersonaAutorizada> _listaPersonas = new List<PersonaAutorizada>();
            _listaPersonas = Controlador.ListarPersonas(pGrupo);
            _listaPersonas.Sort(delegate (PersonaAutorizada a1, PersonaAutorizada a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaPersonas.Count; i++)
                comboBox_persona.Items.Add(_listaPersonas[i].Nombre);
        }
    }
}