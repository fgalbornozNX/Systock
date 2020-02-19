namespace SyStock.UI
{
    partial class V_ingresarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_ingresarPassword));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Cancelar = new System.Windows.Forms.Button();
            this.Button_Aceptar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.textBoxNombre);
            this.groupBox2.Controls.Add(this.textBoxContraseña);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Button_Cancelar);
            this.groupBox2.Controls.Add(this.Button_Aceptar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 135);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuario Retira";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(154, 72);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(130, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Olvidaste la contraseña?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNombre.Location = new System.Drawing.Point(73, 23);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(211, 20);
            this.textBoxNombre.TabIndex = 14;
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContraseña.Location = new System.Drawing.Point(73, 49);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.PasswordChar = '♦';
            this.textBoxContraseña.Size = new System.Drawing.Size(211, 20);
            this.textBoxContraseña.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre:";
            // 
            // Button_Cancelar
            // 
            this.Button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Cancelar.Image")));
            this.Button_Cancelar.Location = new System.Drawing.Point(192, 90);
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
            this.Button_Aceptar.Location = new System.Drawing.Point(94, 90);
            this.Button_Aceptar.Name = "Button_Aceptar";
            this.Button_Aceptar.Size = new System.Drawing.Size(92, 39);
            this.Button_Aceptar.TabIndex = 2;
            this.Button_Aceptar.Text = "Aceptar";
            this.Button_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Aceptar.UseVisualStyleBackColor = true;
            this.Button_Aceptar.Click += new System.EventHandler(this.Button_Aceptar_Click);
            // 
            // V_ingresarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 159);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "V_ingresarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "V_ingresarPassword";
            this.Load += new System.EventHandler(this.V_ingresarPassword_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Cancelar;
        private System.Windows.Forms.Button Button_Aceptar;
        public System.Windows.Forms.LinkLabel linkLabel1;
    }
}