namespace SyStock.UI
{
    partial class V_Area
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Area));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox_area = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox_grupos = new System.Windows.Forms.ListBox();
            this.comboBox_filtrarArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Button_Cancelar = new System.Windows.Forms.Button();
            this.Button_modificar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.Button_Agregar = new System.Windows.Forms.Button();
            this.textBox_grupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_grupoPersona = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_areaPersona = new System.Windows.Forms.ComboBox();
            this.button_AgregarPersona = new System.Windows.Forms.Button();
            this.textBox_nombrePersona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(428, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 126);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.Button_Cancelar);
            this.groupBox2.Controls.Add(this.Button_modificar);
            this.groupBox2.Location = new System.Drawing.Point(13, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 256);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista Áreas";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 184);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_area);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 158);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Áreas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox_area
            // 
            this.listBox_area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_area.FormattingEnabled = true;
            this.listBox_area.Location = new System.Drawing.Point(6, 3);
            this.listBox_area.Name = "listBox_area";
            this.listBox_area.Size = new System.Drawing.Size(377, 147);
            this.listBox_area.TabIndex = 0;
            this.listBox_area.SelectedIndexChanged += new System.EventHandler(this.ListBox_area_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_grupos);
            this.tabPage2.Controls.Add(this.comboBox_filtrarArea);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 158);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grupos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox_grupos
            // 
            this.listBox_grupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_grupos.FormattingEnabled = true;
            this.listBox_grupos.Location = new System.Drawing.Point(6, 33);
            this.listBox_grupos.Name = "listBox_grupos";
            this.listBox_grupos.Size = new System.Drawing.Size(374, 121);
            this.listBox_grupos.TabIndex = 14;
            this.listBox_grupos.SelectedIndexChanged += new System.EventHandler(this.ListBox_grupos_SelectedIndexChanged);
            // 
            // comboBox_filtrarArea
            // 
            this.comboBox_filtrarArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_filtrarArea.FormattingEnabled = true;
            this.comboBox_filtrarArea.Location = new System.Drawing.Point(47, 6);
            this.comboBox_filtrarArea.Name = "comboBox_filtrarArea";
            this.comboBox_filtrarArea.Size = new System.Drawing.Size(333, 21);
            this.comboBox_filtrarArea.TabIndex = 7;
            this.comboBox_filtrarArea.SelectedIndexChanged += new System.EventHandler(this.ComboBox_filtrarArea_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Área:";
            // 
            // Button_Cancelar
            // 
            this.Button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Cancelar.Image")));
            this.Button_Cancelar.Location = new System.Drawing.Point(464, 207);
            this.Button_Cancelar.Name = "Button_Cancelar";
            this.Button_Cancelar.Size = new System.Drawing.Size(92, 39);
            this.Button_Cancelar.TabIndex = 4;
            this.Button_Cancelar.Text = "Cerrar";
            this.Button_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Cancelar.UseVisualStyleBackColor = true;
            this.Button_Cancelar.Click += new System.EventHandler(this.Button_Cancelar_Click);
            // 
            // Button_modificar
            // 
            this.Button_modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_modificar.Enabled = false;
            this.Button_modificar.Image = ((System.Drawing.Image)(resources.GetObject("Button_modificar.Image")));
            this.Button_modificar.Location = new System.Drawing.Point(512, 17);
            this.Button_modificar.Name = "Button_modificar";
            this.Button_modificar.Size = new System.Drawing.Size(44, 42);
            this.Button_modificar.TabIndex = 3;
            this.Button_modificar.UseVisualStyleBackColor = true;
            this.Button_modificar.Click += new System.EventHandler(this.Button_modificar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox_area);
            this.groupBox1.Controls.Add(this.Button_Agregar);
            this.groupBox1.Controls.Add(this.textBox_grupo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Departamento";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(10, 46);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Grupo:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // comboBox_area
            // 
            this.comboBox_area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(86, 17);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(377, 21);
            this.comboBox_area.TabIndex = 5;
            // 
            // Button_Agregar
            // 
            this.Button_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Agregar.Image")));
            this.Button_Agregar.Location = new System.Drawing.Point(474, 19);
            this.Button_Agregar.Name = "Button_Agregar";
            this.Button_Agregar.Size = new System.Drawing.Size(85, 42);
            this.Button_Agregar.TabIndex = 4;
            this.Button_Agregar.Text = "Agregar";
            this.Button_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Agregar.UseVisualStyleBackColor = true;
            this.Button_Agregar.Click += new System.EventHandler(this.Button_Agregar_Click);
            // 
            // textBox_grupo
            // 
            this.textBox_grupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_grupo.Enabled = false;
            this.textBox_grupo.Location = new System.Drawing.Point(86, 44);
            this.textBox_grupo.Name = "textBox_grupo";
            this.textBox_grupo.Size = new System.Drawing.Size(377, 20);
            this.textBox_grupo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Área:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBox_grupoPersona);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBox_areaPersona);
            this.groupBox3.Controls.Add(this.button_AgregarPersona);
            this.groupBox3.Controls.Add(this.textBox_nombrePersona);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 106);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Personas autorizadas a retirar";
            // 
            // comboBox_grupoPersona
            // 
            this.comboBox_grupoPersona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_grupoPersona.FormattingEnabled = true;
            this.comboBox_grupoPersona.Location = new System.Drawing.Point(86, 44);
            this.comboBox_grupoPersona.Name = "comboBox_grupoPersona";
            this.comboBox_grupoPersona.Size = new System.Drawing.Size(377, 21);
            this.comboBox_grupoPersona.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Grupo:";
            // 
            // comboBox_areaPersona
            // 
            this.comboBox_areaPersona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_areaPersona.FormattingEnabled = true;
            this.comboBox_areaPersona.Location = new System.Drawing.Point(86, 17);
            this.comboBox_areaPersona.Name = "comboBox_areaPersona";
            this.comboBox_areaPersona.Size = new System.Drawing.Size(377, 21);
            this.comboBox_areaPersona.TabIndex = 5;
            this.comboBox_areaPersona.SelectedIndexChanged += new System.EventHandler(this.ComboBox_areaPersona_SelectedIndexChanged);
            // 
            // button_AgregarPersona
            // 
            this.button_AgregarPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AgregarPersona.Image = ((System.Drawing.Image)(resources.GetObject("button_AgregarPersona.Image")));
            this.button_AgregarPersona.Location = new System.Drawing.Point(474, 32);
            this.button_AgregarPersona.Name = "button_AgregarPersona";
            this.button_AgregarPersona.Size = new System.Drawing.Size(85, 42);
            this.button_AgregarPersona.TabIndex = 4;
            this.button_AgregarPersona.Text = "Agregar";
            this.button_AgregarPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_AgregarPersona.UseVisualStyleBackColor = true;
            this.button_AgregarPersona.Click += new System.EventHandler(this.Button_AgregarPersona_Click);
            // 
            // textBox_nombrePersona
            // 
            this.textBox_nombrePersona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_nombrePersona.Location = new System.Drawing.Point(86, 71);
            this.textBox_nombrePersona.Name = "textBox_nombrePersona";
            this.textBox_nombrePersona.Size = new System.Drawing.Size(377, 20);
            this.textBox_nombrePersona.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Área:";
            // 
            // V_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 458);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(609, 497);
            this.Name = "V_Area";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área";
            this.Load += new System.EventHandler(this.V_Area_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Button_Cancelar;
        private System.Windows.Forms.Button Button_modificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.Button Button_Agregar;
        private System.Windows.Forms.TextBox textBox_grupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_areaPersona;
        private System.Windows.Forms.Button button_AgregarPersona;
        private System.Windows.Forms.TextBox textBox_nombrePersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox_filtrarArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox_grupoPersona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_area;
        private System.Windows.Forms.ListBox listBox_grupos;
    }
}