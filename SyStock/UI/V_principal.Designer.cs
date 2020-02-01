namespace SyStock.UI
{
    partial class V_principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarÁreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasAutorizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Button_AgregarArea = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_grupo = new System.Windows.Forms.ComboBox();
            this.Button_AgregarPersonaRetira = new System.Windows.Forms.Button();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_persona = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_cantidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_nombre = new System.Windows.Forms.ComboBox();
            this.comboBox_categoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_cancelarInsumo = new System.Windows.Forms.Button();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Cancelar = new System.Windows.Forms.Button();
            this.Button_Aceptar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Button_EliminarInsumo = new System.Windows.Forms.Button();
            this.textBoxPersonaRetira = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoría = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentaToolStripMenuItem,
            this.administrarToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.ModificarToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.CerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.insumosToolStripMenuItem,
            this.areasToolStripMenuItem});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // insumosToolStripMenuItem
            // 
            this.insumosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarStockToolStripMenuItem,
            this.listaInsumosToolStripMenuItem});
            this.insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            this.insumosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.insumosToolStripMenuItem.Text = "Insumos";
            // 
            // actualizarStockToolStripMenuItem
            // 
            this.actualizarStockToolStripMenuItem.Name = "actualizarStockToolStripMenuItem";
            this.actualizarStockToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.actualizarStockToolStripMenuItem.Text = "Actualizar Stock";
            this.actualizarStockToolStripMenuItem.Click += new System.EventHandler(this.ActualizarStockToolStripMenuItem_Click);
            // 
            // listaInsumosToolStripMenuItem
            // 
            this.listaInsumosToolStripMenuItem.Name = "listaInsumosToolStripMenuItem";
            this.listaInsumosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.listaInsumosToolStripMenuItem.Text = "Lista Insumos";
            this.listaInsumosToolStripMenuItem.Click += new System.EventHandler(this.ListaInsumosToolStripMenuItem_Click);
            // 
            // areasToolStripMenuItem
            // 
            this.areasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarÁreaToolStripMenuItem,
            this.personasAutorizadasToolStripMenuItem});
            this.areasToolStripMenuItem.Name = "areasToolStripMenuItem";
            this.areasToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.areasToolStripMenuItem.Text = "Áreas";
            // 
            // agregarÁreaToolStripMenuItem
            // 
            this.agregarÁreaToolStripMenuItem.Name = "agregarÁreaToolStripMenuItem";
            this.agregarÁreaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.agregarÁreaToolStripMenuItem.Text = "Agregar Área";
            this.agregarÁreaToolStripMenuItem.Click += new System.EventHandler(this.AgregarÁreaToolStripMenuItem_Click);
            // 
            // personasAutorizadasToolStripMenuItem
            // 
            this.personasAutorizadasToolStripMenuItem.Name = "personasAutorizadasToolStripMenuItem";
            this.personasAutorizadasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.personasAutorizadasToolStripMenuItem.Text = "Personas Autorizadas";
            this.personasAutorizadasToolStripMenuItem.Click += new System.EventHandler(this.PersonasAutorizadasToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultarToolStripMenuItem.Text = "Consulta";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.ConsultarToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Button_AgregarArea);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_grupo);
            this.groupBox1.Controls.Add(this.Button_AgregarPersonaRetira);
            this.groupBox1.Controls.Add(this.comboBox_area);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_persona);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Usuario Retira";
            // 
            // Button_AgregarArea
            // 
            this.Button_AgregarArea.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Button_AgregarArea.Image = ((System.Drawing.Image)(resources.GetObject("Button_AgregarArea.Image")));
            this.Button_AgregarArea.Location = new System.Drawing.Point(550, 19);
            this.Button_AgregarArea.Name = "Button_AgregarArea";
            this.Button_AgregarArea.Size = new System.Drawing.Size(23, 23);
            this.Button_AgregarArea.TabIndex = 8;
            this.toolTip1.SetToolTip(this.Button_AgregarArea, "Agregar nueva Área");
            this.Button_AgregarArea.UseVisualStyleBackColor = true;
            this.Button_AgregarArea.Click += new System.EventHandler(this.Button_AgregarArea_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grupo:";
            // 
            // comboBox_grupo
            // 
            this.comboBox_grupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_grupo.Enabled = false;
            this.comboBox_grupo.FormattingEnabled = true;
            this.comboBox_grupo.Location = new System.Drawing.Point(89, 47);
            this.comboBox_grupo.Name = "comboBox_grupo";
            this.comboBox_grupo.Size = new System.Drawing.Size(455, 21);
            this.comboBox_grupo.TabIndex = 7;
            this.comboBox_grupo.SelectedIndexChanged += new System.EventHandler(this.ComboBox_grupo_SelectedIndexChanged);
            // 
            // Button_AgregarPersonaRetira
            // 
            this.Button_AgregarPersonaRetira.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Button_AgregarPersonaRetira.Image = ((System.Drawing.Image)(resources.GetObject("Button_AgregarPersonaRetira.Image")));
            this.Button_AgregarPersonaRetira.Location = new System.Drawing.Point(550, 74);
            this.Button_AgregarPersonaRetira.Name = "Button_AgregarPersonaRetira";
            this.Button_AgregarPersonaRetira.Size = new System.Drawing.Size(23, 23);
            this.Button_AgregarPersonaRetira.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Button_AgregarPersonaRetira, "Agregar nueva persona que retira");
            this.Button_AgregarPersonaRetira.UseVisualStyleBackColor = true;
            this.Button_AgregarPersonaRetira.Click += new System.EventHandler(this.Button_AgregarPersonaRetira_Click);
            // 
            // comboBox_area
            // 
            this.comboBox_area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(89, 19);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(455, 21);
            this.comboBox_area.TabIndex = 2;
            this.comboBox_area.SelectedIndexChanged += new System.EventHandler(this.ComboBoxArea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Área:";
            // 
            // comboBox_persona
            // 
            this.comboBox_persona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_persona.FormattingEnabled = true;
            this.comboBox_persona.Location = new System.Drawing.Point(89, 74);
            this.comboBox_persona.Name = "comboBox_persona";
            this.comboBox_persona.Size = new System.Drawing.Size(455, 21);
            this.comboBox_persona.TabIndex = 3;
            this.comboBox_persona.SelectedIndexChanged += new System.EventHandler(this.ComboBox_persona_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBox_cantidad);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBox_nombre);
            this.groupBox3.Controls.Add(this.comboBox_categoria);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button_cancelarInsumo);
            this.groupBox3.Controls.Add(this.button_Agregar);
            this.groupBox3.Location = new System.Drawing.Point(12, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 141);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Insumos";
            // 
            // comboBox_cantidad
            // 
            this.comboBox_cantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_cantidad.FormattingEnabled = true;
            this.comboBox_cantidad.Location = new System.Drawing.Point(73, 74);
            this.comboBox_cantidad.Name = "comboBox_cantidad";
            this.comboBox_cantidad.Size = new System.Drawing.Size(471, 21);
            this.comboBox_cantidad.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre:";
            // 
            // comboBox_nombre
            // 
            this.comboBox_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_nombre.FormattingEnabled = true;
            this.comboBox_nombre.Location = new System.Drawing.Point(73, 47);
            this.comboBox_nombre.Name = "comboBox_nombre";
            this.comboBox_nombre.Size = new System.Drawing.Size(471, 21);
            this.comboBox_nombre.TabIndex = 11;
            this.comboBox_nombre.SelectedIndexChanged += new System.EventHandler(this.ComboBox_nombre_SelectedIndexChanged);
            // 
            // comboBox_categoria
            // 
            this.comboBox_categoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_categoria.FormattingEnabled = true;
            this.comboBox_categoria.Location = new System.Drawing.Point(73, 19);
            this.comboBox_categoria.Name = "comboBox_categoria";
            this.comboBox_categoria.Size = new System.Drawing.Size(471, 21);
            this.comboBox_categoria.TabIndex = 9;
            this.comboBox_categoria.SelectedIndexChanged += new System.EventHandler(this.ComboBox_categoria_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Categoría:";
            // 
            // button_cancelarInsumo
            // 
            this.button_cancelarInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelarInsumo.Image = ((System.Drawing.Image)(resources.GetObject("button_cancelarInsumo.Image")));
            this.button_cancelarInsumo.Location = new System.Drawing.Point(544, 100);
            this.button_cancelarInsumo.Name = "button_cancelarInsumo";
            this.button_cancelarInsumo.Size = new System.Drawing.Size(35, 35);
            this.button_cancelarInsumo.TabIndex = 4;
            this.button_cancelarInsumo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_cancelarInsumo.UseVisualStyleBackColor = true;
            this.button_cancelarInsumo.Click += new System.EventHandler(this.ButtonAgregarInsumo_Click);
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("button_Agregar.Image")));
            this.button_Agregar.Location = new System.Drawing.Point(499, 101);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(35, 35);
            this.button_Agregar.TabIndex = 2;
            this.button_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.Button_Agregar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(609, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 231);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Button_Cancelar
            // 
            this.Button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Cancelar.Image")));
            this.Button_Cancelar.Location = new System.Drawing.Point(707, 458);
            this.Button_Cancelar.Name = "Button_Cancelar";
            this.Button_Cancelar.Size = new System.Drawing.Size(92, 39);
            this.Button_Cancelar.TabIndex = 9;
            this.Button_Cancelar.Text = "Cancelar";
            this.Button_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Button_Cancelar, "Cancelar Retiro de Insumo");
            this.Button_Cancelar.UseVisualStyleBackColor = true;
            this.Button_Cancelar.Click += new System.EventHandler(this.Button_Cancelar_Click);
            // 
            // Button_Aceptar
            // 
            this.Button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Aceptar.Image")));
            this.Button_Aceptar.Location = new System.Drawing.Point(609, 458);
            this.Button_Aceptar.Name = "Button_Aceptar";
            this.Button_Aceptar.Size = new System.Drawing.Size(92, 39);
            this.Button_Aceptar.TabIndex = 8;
            this.Button_Aceptar.Text = "Aceptar";
            this.Button_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Button_Aceptar, "Aceptar Retiro de Insumos");
            this.Button_Aceptar.UseVisualStyleBackColor = true;
            this.Button_Aceptar.Click += new System.EventHandler(this.Button_Aceptar_Click);
            // 
            // Button_EliminarInsumo
            // 
            this.Button_EliminarInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_EliminarInsumo.Enabled = false;
            this.Button_EliminarInsumo.Image = ((System.Drawing.Image)(resources.GetObject("Button_EliminarInsumo.Image")));
            this.Button_EliminarInsumo.Location = new System.Drawing.Point(736, 3);
            this.Button_EliminarInsumo.Name = "Button_EliminarInsumo";
            this.Button_EliminarInsumo.Size = new System.Drawing.Size(40, 42);
            this.Button_EliminarInsumo.TabIndex = 7;
            this.toolTip1.SetToolTip(this.Button_EliminarInsumo, "Eliminar Insumo");
            this.Button_EliminarInsumo.UseVisualStyleBackColor = true;
            this.Button_EliminarInsumo.Click += new System.EventHandler(this.Button_EliminarInsumo_Click_1);
            // 
            // textBoxPersonaRetira
            // 
            this.textBoxPersonaRetira.Location = new System.Drawing.Point(56, 18);
            this.textBoxPersonaRetira.Name = "textBoxPersonaRetira";
            this.textBoxPersonaRetira.ReadOnly = true;
            this.textBoxPersonaRetira.Size = new System.Drawing.Size(377, 20);
            this.textBoxPersonaRetira.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Categoría});
            this.dataGridView1.Location = new System.Drawing.Point(27, 325);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 111);
            this.dataGridView1.TabIndex = 17;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Categoría
            // 
            this.Categoría.HeaderText = "Insumo";
            this.Categoría.Name = "Categoría";
            this.Categoría.ReadOnly = true;
            this.Categoría.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxPersonaRetira);
            this.panel1.Controls.Add(this.Button_EliminarInsumo);
            this.panel1.Location = new System.Drawing.Point(12, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 178);
            this.panel1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(12, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Retira:";
            // 
            // V_principal
            // 
            this.AcceptButton = this.Button_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Cancelar;
            this.ClientSize = new System.Drawing.Size(808, 506);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Button_Cancelar);
            this.Controls.Add(this.Button_Aceptar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 360);
            this.Name = "V_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Retirar Insumos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.V_principal_FormClosing);
            this.Load += new System.EventHandler(this.V_principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insumosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button_AgregarPersonaRetira;
        private System.Windows.Forms.ComboBox comboBox_persona;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.Button Button_Cancelar;
        private System.Windows.Forms.Button Button_Aceptar;
        private System.Windows.Forms.ToolStripMenuItem agregarÁreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasAutorizadasToolStripMenuItem;
        private System.Windows.Forms.Button Button_AgregarArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_grupo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem actualizarStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaInsumosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_cantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_nombre;
        private System.Windows.Forms.ComboBox comboBox_categoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_cancelarInsumo;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.TextBox textBoxPersonaRetira;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoría;
        private System.Windows.Forms.Button Button_EliminarInsumo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}