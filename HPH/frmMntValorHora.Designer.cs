namespace HPH
{
    partial class frmMntValorHora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntValorHora));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnHelp = new Button();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtDescripcion = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtIdValorHora = new TextBox();
            chkActivo = new CheckBox();
            txtPeriodo = new TextBox();
            label2 = new Label();
            txtValorHora = new TextBox();
            label5 = new Label();
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
            panel1.Size = new Size(584, 57);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 15);
            label1.Name = "label1";
            label1.Size = new Size(231, 26);
            label1.TabIndex = 2;
            label1.Text = "Mantenedor de Valor Hora";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(120, 94);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(30, 26);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(454, 187);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 37);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(337, 187);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(108, 37);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(156, 95);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(406, 23);
            txtDescripcion.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 77);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 7;
            label4.Text = "ID Valor Hora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(156, 77);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Descripción";
            // 
            // txtIdValorHora
            // 
            txtIdValorHora.Location = new Point(18, 95);
            txtIdValorHora.MaxLength = 11;
            txtIdValorHora.Name = "txtIdValorHora";
            txtIdValorHora.Size = new Size(100, 23);
            txtIdValorHora.TabIndex = 2;
            txtIdValorHora.Leave += txtIdValorHora_Leave;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Enabled = false;
            chkActivo.Location = new Point(18, 174);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 19);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activado";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtPeriodo
            // 
            txtPeriodo.Enabled = false;
            txtPeriodo.Location = new Point(18, 146);
            txtPeriodo.MaxLength = 7;
            txtPeriodo.Name = "txtPeriodo";
            txtPeriodo.Size = new Size(100, 23);
            txtPeriodo.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 126);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 19;
            label2.Text = "Periodo";
            // 
            // txtValorHora
            // 
            txtValorHora.Enabled = false;
            txtValorHora.Location = new Point(156, 146);
            txtValorHora.MaxLength = 20;
            txtValorHora.Name = "txtValorHora";
            txtValorHora.Size = new Size(150, 23);
            txtValorHora.TabIndex = 6;
            txtValorHora.TextAlign = HorizontalAlignment.Right;
            txtValorHora.KeyPress += txtValorHora_KeyPress;
            txtValorHora.Leave += txtValorHora_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(156, 126);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 21;
            label5.Text = "Valor Hora";
            // 
            // frmMntValorHora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 232);
            Controls.Add(txtValorHora);
            Controls.Add(label5);
            Controls.Add(txtPeriodo);
            Controls.Add(label2);
            Controls.Add(chkActivo);
            Controls.Add(btnHelp);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtIdValorHora);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMntValorHora";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mantenedor de Valor Hora";
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
        private TextBox txtIdValorHora;
        private CheckBox chkActivo;
        private TextBox txtPeriodo;
        private Label label2;
        private TextBox txtValorHora;
        private Label label5;
    }
}
