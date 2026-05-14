namespace HPH
{
    partial class frmMntDependencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntDependencia));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            txtIdDependencia = new TextBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            btnHelp = new Button();
            chkActivo = new CheckBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
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
            panel1.Size = new Size(439, 57);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 16);
            label1.Name = "label1";
            label1.Size = new Size(264, 26);
            label1.TabIndex = 1;
            label1.Text = "Mantenedor de Dependencias";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 75);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 2;
            label4.Text = "Id";
            // 
            // txtIdDependencia
            // 
            txtIdDependencia.Location = new Point(12, 93);
            txtIdDependencia.MaxLength = 5;
            txtIdDependencia.Name = "txtIdDependencia";
            txtIdDependencia.Size = new Size(59, 23);
            txtIdDependencia.TabIndex = 0;
            txtIdDependencia.Leave += txtIdDependencia_Leave;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(12, 141);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(415, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 123);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Descripción";
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(74, 93);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(38, 23);
            btnHelp.TabIndex = 1;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Enabled = false;
            chkActivo.Location = new Point(12, 180);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 3;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(227, 209);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(97, 34);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(330, 209);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 34);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmMntDependencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 255);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(chkActivo);
            Controls.Add(btnHelp);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtDescripcion);
            Controls.Add(txtIdDependencia);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMntDependencia";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenedor de Dependencias";
            Load += frmMntDependencia_Load;
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
        private Label label4;
        private TextBox txtIdDependencia;
        private TextBox txtDescripcion;
        private Label label2;
        private Button btnHelp;
        private CheckBox chkActivo;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}