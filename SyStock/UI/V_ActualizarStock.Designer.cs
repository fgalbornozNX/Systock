namespace SyStock.UI
{
    partial class V_ActualizarStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_ActualizarStock));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_nombre = new System.Windows.Forms.ComboBox();
            this.comboBox_categoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Cancelar = new System.Windows.Forms.Button();
            this.Button_Aceptar = new System.Windows.Forms.Button();
            this.Button_AgregarInsumo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox_cantidad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_nombre);
            this.groupBox2.Controls.Add(this.comboBox_categoria);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Button_Cancelar);
            this.groupBox2.Controls.Add(this.Button_Aceptar);
            this.groupBox2.Controls.Add(this.Button_AgregarInsumo);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 202);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insumos";
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cantidad.Location = new System.Drawing.Point(73, 120);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(299, 20);
            this.textBox_cantidad.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cantidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Insumo:";
            // 
            // comboBox_nombre
            // 
            this.comboBox_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_nombre.FormattingEnabled = true;
            this.comboBox_nombre.Location = new System.Drawing.Point(73, 93);
            this.comboBox_nombre.Name = "comboBox_nombre";
            this.comboBox_nombre.Size = new System.Drawing.Size(299, 21);
            this.comboBox_nombre.TabIndex = 11;
            // 
            // comboBox_categoria
            // 
            this.comboBox_categoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_categoria.FormattingEnabled = true;
            this.comboBox_categoria.Location = new System.Drawing.Point(73, 65);
            this.comboBox_categoria.Name = "comboBox_categoria";
            this.comboBox_categoria.Size = new System.Drawing.Size(299, 21);
            this.comboBox_categoria.TabIndex = 9;
            this.comboBox_categoria.SelectedIndexChanged += new System.EventHandler(this.ComboBox_categoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Categoría:";
            // 
            // Button_Cancelar
            // 
            this.Button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Cancelar.Image")));
            this.Button_Cancelar.Location = new System.Drawing.Point(280, 148);
            this.Button_Cancelar.Name = "Button_Cancelar";
            this.Button_Cancelar.Size = new System.Drawing.Size(92, 39);
            this.Button_Cancelar.TabIndex = 4;
            this.Button_Cancelar.Text = "Cerrar";
            this.Button_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Cancelar.UseVisualStyleBackColor = true;
            this.Button_Cancelar.Click += new System.EventHandler(this.Button_Cancelar_Click);
            // 
            // Button_Aceptar
            // 
            this.Button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Aceptar.Image")));
            this.Button_Aceptar.Location = new System.Drawing.Point(182, 148);
            this.Button_Aceptar.Name = "Button_Aceptar";
            this.Button_Aceptar.Size = new System.Drawing.Size(92, 39);
            this.Button_Aceptar.TabIndex = 2;
            this.Button_Aceptar.Text = "Siguiente";
            this.Button_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Aceptar.UseVisualStyleBackColor = true;
            this.Button_Aceptar.Click += new System.EventHandler(this.Button_Aceptar_Click);
            // 
            // Button_AgregarInsumo
            // 
            this.Button_AgregarInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AgregarInsumo.Image = ((System.Drawing.Image)(resources.GetObject("Button_AgregarInsumo.Image")));
            this.Button_AgregarInsumo.Location = new System.Drawing.Point(328, 15);
            this.Button_AgregarInsumo.Name = "Button_AgregarInsumo";
            this.Button_AgregarInsumo.Size = new System.Drawing.Size(44, 42);
            this.Button_AgregarInsumo.TabIndex = 1;
            this.Button_AgregarInsumo.UseVisualStyleBackColor = true;
            this.Button_AgregarInsumo.Click += new System.EventHandler(this.Button_AgregarInsumo_Click);
            // 
            // V_ActualizarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 226);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "V_ActualizarStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Stock";
            this.Load += new System.EventHandler(this.V_ActualizarStock_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_nombre;
        private System.Windows.Forms.ComboBox comboBox_categoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Cancelar;
        private System.Windows.Forms.Button Button_Aceptar;
        private System.Windows.Forms.Button Button_AgregarInsumo;
        private System.Windows.Forms.TextBox textBox_cantidad;
    }
}