namespace HPH
{
    partial class frmMntEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntEmpleado));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            txtRut = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            cmbCargo = new ComboBox();
            label4 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnUploadEmpleado = new Button();
            btnHelp = new Button();
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
            panel1.Size = new Size(506, 57);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 16);
            label1.Name = "label1";
            label1.Size = new Size(236, 26);
            label1.TabIndex = 1;
            label1.Text = "Mantenedor de empleados";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 146);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Cargo";
            // 
            // txtRut
            // 
            txtRut.Location = new Point(20, 98);
            txtRut.MaxLength = 11;
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(100, 23);
            txtRut.TabIndex = 1;
            txtRut.KeyPress += txtRut_KeyPress;
            txtRut.KeyUp += txtRut_KeyUp;
            txtRut.Leave += txtRut_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 80);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(158, 98);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(326, 23);
            txtNombre.TabIndex = 3;
            // 
            // cmbCargo
            // 
            cmbCargo.Enabled = false;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(20, 164);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(464, 23);
            cmbCargo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 80);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 1;
            label4.Text = "Rut";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(259, 212);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(108, 37);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(376, 212);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 37);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnUploadEmpleado
            // 
            btnUploadEmpleado.Location = new Point(20, 213);
            btnUploadEmpleado.Name = "btnUploadEmpleado";
            btnUploadEmpleado.Size = new Size(108, 37);
            btnUploadEmpleado.TabIndex = 5;
            btnUploadEmpleado.Text = "&Carga Masiva";
            btnUploadEmpleado.UseVisualStyleBackColor = true;
            btnUploadEmpleado.Click += btnUploadEmpleado_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(122, 97);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(30, 26);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // frmMntEmpleado
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(506, 262);
            Controls.Add(btnHelp);
            Controls.Add(btnCancelar);
            Controls.Add(btnUploadEmpleado);
            Controls.Add(btnAceptar);
            Controls.Add(cmbCargo);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtRut);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMntEmpleado";
            ShowIcon = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox txtRut;
        private Label label3;
        private TextBox txtNombre;
        private ComboBox cmbCargo;
        private Label label4;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnUploadEmpleado;
        private Button btnHelp;
    }
}