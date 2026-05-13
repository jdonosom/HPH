namespace HPH
{
    partial class frmMntCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntCargo));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnHelp = new Button();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtDescripcion = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtIdCargo = new TextBox();
            chkActivo = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(499, 57);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 15);
            label1.Name = "label1";
            label1.Size = new Size(202, 26);
            label1.TabIndex = 2;
            label1.Text = "Mantenedor de cargos";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(120, 91);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(30, 26);
            btnHelp.TabIndex = 11;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(374, 160);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 37);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(257, 160);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(108, 37);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(156, 92);
            txtDescripcion.MaxLength = 150;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(326, 23);
            txtDescripcion.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 74);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 7;
            label4.Text = "Cargo Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(156, 74);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Descripción";
            // 
            // txtIdCargo
            // 
            txtIdCargo.Location = new Point(18, 92);
            txtIdCargo.MaxLength = 11;
            txtIdCargo.Name = "txtIdCargo";
            txtIdCargo.Size = new Size(100, 23);
            txtIdCargo.TabIndex = 9;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(18, 133);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 19);
            chkActivo.TabIndex = 17;
            chkActivo.Text = "Activado";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // frmMntCargo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 210);
            Controls.Add(chkActivo);
            Controls.Add(btnHelp);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtIdCargo);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMntCargo";
            ShowIcon = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnHelp;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtDescripcion;
        private Label label4;
        private Label label3;
        private TextBox txtIdCargo;
        private CheckBox chkActivo;
    }
}