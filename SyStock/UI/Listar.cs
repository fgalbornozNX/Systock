using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SyStock.Entidades;
using SyStock.LogicaNegocio;

namespace SyStock.UI
{
    public static class Listar
    {
        public static void Insumos(ComboBox pComboBoxInsumos, ComboBox pComboBoxCategoria)
        {
            if (pComboBoxInsumos == null || pComboBoxCategoria == null)
                throw new ArgumentNullException(pComboBoxInsumos == null ? nameof(pComboBoxInsumos) : nameof(pComboBoxCategoria));

            pComboBoxInsumos.Items.Clear();
            pComboBoxInsumos.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Insumo> listaInsumos = new List<Insumo>();
            if (pComboBoxCategoria.Text.Length == 0)
            {
                listaInsumos = ControladorFachada.ListarInsumos();
                listaInsumos.Sort(delegate (Insumo a1, Insumo a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            }
            else
            {
                listaInsumos = ControladorFachada.ListarInsumos(pComboBoxCategoria.Text);
                listaInsumos.Sort(delegate (Insumo a1, Insumo a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            }

            for (int i = 0; i < listaInsumos.Count; i++)
                pComboBoxInsumos.Items.Add(listaInsumos[i].Nombre);
        }

        public static Insumo Cantidad(ComboBox comboBoxCantidad, ComboBox comboBoxNombre)
        {
            if (comboBoxCantidad == null || comboBoxNombre == null)
                throw new ArgumentNullException(comboBoxCantidad == null ? nameof(comboBoxCantidad) : nameof(comboBoxNombre));

            comboBoxCantidad.Items.Clear();

            Insumo ins = null;
            int cantidad = 0;
            if (comboBoxNombre.Text.Length == 0)
            {
                cantidad = 0;
            }
            else
            {
                ins = ControladorFachada.ObtenerInsumo(comboBoxNombre.Text);

                if (ins == null)
                    MessageBox.Show("No se encontró el insumo");
                else
                    cantidad = ins.Cantidad;
            }

            for (int i = 0; i < cantidad; i++)
                comboBoxCantidad.Items.Add(Convert.ToString(i + 1));
            return ins;
        }

        public static void Categorias(ComboBox comboBoxCategoria)
        {
            if (comboBoxCategoria == null)
                throw new ArgumentNullException(nameof(comboBoxCategoria));

            comboBoxCategoria.Items.Clear();
            if (comboBoxCategoria.Name == "comboBox_filtrar")
            {
                comboBoxCategoria.Items.Add("TODOS");
            }
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Categoria> listaCategorias = new List<Categoria>();
            listaCategorias = ControladorFachada.ListarCategorias();
            listaCategorias.Sort(delegate (Categoria a1, Categoria a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < listaCategorias.Count; i++)
                comboBoxCategoria.Items.Add(listaCategorias[i].Nombre);
        }

        public static void Categorias(DataGridView dataGridCategoria, List<Categoria> listaCategorias)
        {
            if (dataGridCategoria == null || listaCategorias == null)
                throw new ArgumentNullException(dataGridCategoria == null ? nameof(dataGridCategoria) : nameof(listaCategorias));

            dataGridCategoria.Rows.Clear();
            dataGridCategoria.ColumnHeadersVisible = true;

            foreach (var cat in listaCategorias)
            {
                if (cat != null)
                {
                    String[] row;
                    row = new String[] { cat.Nombre };
                    dataGridCategoria.Rows.Add(row);
                }
            }
            dataGridCategoria.Refresh();
        }

        public static void Areas(ComboBox pComboBox)
        {
            if (pComboBox == null)
                throw new ArgumentNullException(nameof(pComboBox));

            pComboBox.Items.Clear();
            pComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Area> listaAreas = new List<Area>();
            listaAreas = ControladorFachada.ListarArea();
            listaAreas.Sort(delegate (Area a1, Area a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < listaAreas.Count; i++)
                pComboBox.Items.Add(listaAreas[i].Nombre);
        }

        public static void Areas(ListBox pListBox)
        {
            if (pListBox == null)
                throw new ArgumentNullException(nameof(pListBox));

            pListBox.Items.Clear();

            List<Area> listaAreas = new List<Area>();
            listaAreas = ControladorFachada.ListarArea();
            listaAreas.Sort(delegate (Area a1, Area a2) { return a1.Nombre.CompareTo(a2.Nombre); });
            for (int i = 0; i < listaAreas.Count; i++)
                pListBox.Items.Add(listaAreas[i].Nombre);
        }

        public static void Grupo(ComboBox pComboBoxGrupo)
        {
            if (pComboBoxGrupo == null)
                throw new ArgumentNullException(nameof(pComboBoxGrupo));

            pComboBoxGrupo.Items.Clear();
            pComboBoxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Grupo> listaGrupo = new List<Grupo>();
            listaGrupo = ControladorFachada.ListarGrupos();
            listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < listaGrupo.Count; i++)
                pComboBoxGrupo.Items.Add(listaGrupo[i].Nombre);
        }

        public static void Grupo(ListBox pListBoxGrupo)
        {
            if (pListBoxGrupo == null)
                throw new ArgumentNullException(nameof(pListBoxGrupo));

            pListBoxGrupo.Items.Clear();

            List<Grupo> listaGrupo = new List<Grupo>();
            listaGrupo = ControladorFachada.ListarGrupos();
            listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < listaGrupo.Count; i++)
                pListBoxGrupo.Items.Add(listaGrupo[i].Nombre);
        }

        public static void Grupo(ComboBox pComboBoxGrupo, ComboBox pComboBoxArea)
        {
            if (pComboBoxGrupo == null || pComboBoxArea == null)
                throw new ArgumentNullException(pComboBoxGrupo == null ? nameof(pComboBoxGrupo) : nameof(pComboBoxArea));

            pComboBoxGrupo.Items.Clear();
            pComboBoxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Grupo> listaGrupo = new List<Grupo>();
            listaGrupo = ControladorFachada.ListarGrupos(pComboBoxArea.Text);
            listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < listaGrupo.Count; i++)
                pComboBoxGrupo.Items.Add(listaGrupo[i].Nombre);
        }

        public static void Grupo(ListBox pListBoxGrupo, ComboBox pComboBoxArea)
        {
            if (pListBoxGrupo == null || pComboBoxArea == null)
                throw new ArgumentNullException(pListBoxGrupo == null ? nameof(pListBoxGrupo) : nameof(pComboBoxArea));

            pListBoxGrupo.Items.Clear();

            List<Grupo> listaGrupo = new List<Grupo>();
            listaGrupo = ControladorFachada.ListarGrupos(pComboBoxArea.Text);
            listaGrupo.Sort(delegate (Grupo a1, Grupo a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < listaGrupo.Count; i++)
                pListBoxGrupo.Items.Add(listaGrupo[i].Nombre);
        }

        public static void Persona(ComboBox comboBoxPersona)
        {
            if (comboBoxPersona == null)
                throw new ArgumentNullException(nameof(comboBoxPersona));

            comboBoxPersona.Items.Clear();

            List<PersonaAutorizada> listaPersonas = new List<PersonaAutorizada>();
            listaPersonas = ControladorFachada.ListarPersonas();
            listaPersonas.Sort(delegate (PersonaAutorizada a1, PersonaAutorizada a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < listaPersonas.Count; i++)
                comboBoxPersona.Items.Add(listaPersonas[i].Nombre);
        }

        public static void Persona(ComboBox comboBoxPersona, string pGrupo)
        {
            if (comboBoxPersona == null || pGrupo == null)
                throw new ArgumentNullException(comboBoxPersona == null ? nameof(comboBoxPersona) : nameof(pGrupo));

            comboBoxPersona.Items.Clear();

            List<PersonaAutorizada> _listaPersonas = new List<PersonaAutorizada>();
            _listaPersonas = ControladorFachada.ListarPersonas(pGrupo);
            _listaPersonas.Sort(delegate (PersonaAutorizada a1, PersonaAutorizada a2) { return a1.Nombre.CompareTo(a2.Nombre); });

            for (int i = 0; i < _listaPersonas.Count; i++)
                comboBoxPersona.Items.Add(_listaPersonas[i].Nombre);
        }
    }
}