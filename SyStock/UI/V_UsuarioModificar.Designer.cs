namespace SyStock.UI
{
    partial class V_UsuarioModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_UsuarioModificar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Button_Cancelar = new System.Windows.Forms.Button();
            this.Button_Aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_repetir = new System.Windows.Forms.TextBox();
            this.textBox_contraseña_nueva = new System.Windows.Forms.TextBox();
            this.textBox_contraseña_antigua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Button_Cancelar);
            this.groupBox1.Controls.Add(this.Button_Aceptar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_repetir);
            this.groupBox1.Controls.Add(this.textBox_contraseña_nueva);
            this.groupBox1.Controls.Add(this.textBox_contraseña_antigua);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // Button_Cancelar
            // 
            this.Button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Cancelar.Image")));
            this.Button_Cancelar.Location = new System.Drawing.Point(255, 114);
            this.Button_Cancelar.Name = "Button_Cancelar";
            this.Button_Cancelar.Size = new System.Drawing.Size(89, 45);
            this.Button_Cancelar.TabIndex = 8;
            this.Button_Cancelar.Text = "Cancelar";
            this.Button_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Cancelar.UseVisualStyleBackColor = true;
            this.Button_Cancelar.Click += new System.EventHandler(this.Button_Cancelar_Click);
            // 
            // Button_Aceptar
            // 
            this.Button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Button_Aceptar.Image")));
            this.Button_Aceptar.Location = new System.Drawing.Point(163, 114);
            this.Button_Aceptar.Name = "Button_Aceptar";
            this.Button_Aceptar.Size = new System.Drawing.Size(86, 45);
            this.Button_Aceptar.TabIndex = 7;
            this.Button_Aceptar.Text = "Aceptar";
            this.Button_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Aceptar.UseVisualStyleBackColor = true;
            this.Button_Aceptar.Click += new System.EventHandler(this.Button_Aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Repetir Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña nueva:";
            // 
            // textBox_repetir
            // 
            this.textBox_repetir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_repetir.Location = new System.Drawing.Point(124, 80);
            this.textBox_repetir.Name = "textBox_repetir";
            this.textBox_repetir.PasswordChar = '♦';
            this.textBox_repetir.Size = new System.Drawing.Size(220, 20);
            this.textBox_repetir.TabIndex = 4;
            // 
            // textBox_contraseña_nueva
            // 
            this.textBox_contraseña_nueva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_contraseña_nueva.Location = new System.Drawing.Point(124, 53);
            this.textBox_contraseña_nueva.Name = "textBox_contraseña_nueva";
            this.textBox_contraseña_nueva.PasswordChar = '♦';
            this.textBox_contraseña_nueva.Size = new System.Drawing.Size(220, 20);
            this.textBox_contraseña_nueva.TabIndex = 3;
            // 
            // textBox_contraseña_antigua
            // 
            this.textBox_contraseña_antigua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_contraseña_antigua.Location = new System.Drawing.Point(124, 26);
            this.textBox_contraseña_antigua.Name = "textBox_contraseña_antigua";
            this.textBox_contraseña_antigua.PasswordChar = '♦';
            this.textBox_contraseña_antigua.Size = new System.Drawing.Size(220, 20);
            this.textBox_contraseña_antigua.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña antigua:";
            // 
            // V_UsuarioModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 194);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 233);
            this.MinimumSize = new System.Drawing.Size(300, 233);
            this.Name = "V_UsuarioModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.V_UsuarioModificar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button_Cancelar;
        private System.Windows.Forms.Button Button_Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_repetir;
        private System.Windows.Forms.TextBox textBox_contraseña_nueva;
        private System.Windows.Forms.TextBox textBox_contraseña_antigua;
        private System.Windows.Forms.Label label2;
    }
}