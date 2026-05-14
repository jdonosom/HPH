namespace HPH
{
    partial class frmMntPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntPeriodo));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            lblTotal = new Label();
            dgvPeriodos = new DataGridView();
            groupBox2 = new GroupBox();
            cmbEstado = new ComboBox();
            label9 = new Label();
            chkCerrado = new CheckBox();
            chkCierre = new CheckBox();
            dtpCierre = new DateTimePicker();
            label7 = new Label();
            dtpApertura = new DateTimePicker();
            label6 = new Label();
            txtDescripcion = new TextBox();
            label5 = new Label();
            txtAño = new TextBox();
            label4 = new Label();
            txtPeriodo = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            btnSalir = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            btnCerrarPeriodo = new Button();
            btnEstablecerActual = new Button();
            btnNuevo = new Button();
            lblPeriodoActual = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeriodos).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Size = new Size(1000, 57);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 16);
            label1.Name = "label1";
            label1.Size = new Size(293, 26);
            label1.TabIndex = 1;
            label1.Text = "Mantenedor de Períodos de Proceso";
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
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(dgvPeriodos);
            groupBox1.Location = new Point(12, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(620, 470);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Períodos Registrados";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(15, 443);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(95, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: 0 período(s)";
            // 
            // dgvPeriodos
            // 
            dgvPeriodos.AllowUserToAddRows = false;
            dgvPeriodos.AllowUserToDeleteRows = false;
            dgvPeriodos.AllowUserToResizeRows = false;
            dgvPeriodos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeriodos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeriodos.Location = new Point(15, 22);
            dgvPeriodos.MultiSelect = false;
            dgvPeriodos.Name = "dgvPeriodos";
            dgvPeriodos.ReadOnly = true;
            dgvPeriodos.RowHeadersVisible = false;
            dgvPeriodos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeriodos.Size = new Size(590, 410);
            dgvPeriodos.TabIndex = 0;
            dgvPeriodos.SelectionChanged += dgvPeriodos_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(chkCerrado);
            groupBox2.Controls.Add(chkCierre);
            groupBox2.Controls.Add(dtpCierre);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dtpApertura);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtAño);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtPeriodo);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(638, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 390);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Período";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(20, 346);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 328);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 12;
            label9.Text = "Estado";
            // 
            // chkCerrado
            // 
            chkCerrado.AutoSize = true;
            chkCerrado.Location = new Point(20, 295);
            chkCerrado.Name = "chkCerrado";
            chkCerrado.Size = new Size(117, 19);
            chkCerrado.TabIndex = 11;
            chkCerrado.Text = "Período Cerrado";
            chkCerrado.UseVisualStyleBackColor = true;
            // 
            // chkCierre
            // 
            chkCierre.AutoSize = true;
            chkCierre.Location = new Point(20, 223);
            chkCierre.Name = "chkCierre";
            chkCierre.Size = new Size(105, 19);
            chkCierre.TabIndex = 8;
            chkCierre.Text = "Fecha de Cierre";
            chkCierre.UseVisualStyleBackColor = true;
            chkCierre.CheckedChanged += chkCierre_CheckedChanged;
            // 
            // dtpCierre
            // 
            dtpCierre.Enabled = false;
            dtpCierre.Location = new Point(20, 248);
            dtpCierre.Name = "dtpCierre";
            dtpCierre.Size = new Size(250, 23);
            dtpCierre.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 223);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 10;
            // 
            // dtpApertura
            // 
            dtpApertura.Location = new Point(20, 187);
            dtpApertura.Name = "dtpApertura";
            dtpApertura.Size = new Size(250, 23);
            dtpApertura.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 169);
            label6.Name = "label6";
            label6.Size = new Size(109, 15);
            label6.TabIndex = 6;
            label6.Text = "Fecha de Apertura";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(20, 131);
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(310, 23);
            txtDescripcion.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 113);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 4;
            label5.Text = "Descripción";
            // 
            // txtAño
            // 
            txtAño.Location = new Point(150, 40);
            txtAño.MaxLength = 4;
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(80, 23);
            txtAño.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(150, 22);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 2;
            label4.Text = "Año";
            // 
            // txtPeriodo
            // 
            txtPeriodo.Location = new Point(20, 40);
            txtPeriodo.MaxLength = 6;
            txtPeriodo.Name = "txtPeriodo";
            txtPeriodo.Size = new Size(100, 23);
            txtPeriodo.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 22);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 0;
            label3.Text = "Período (AAAAMM)";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSalir);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(btnCerrarPeriodo);
            panel2.Controls.Add(btnEstablecerActual);
            panel2.Controls.Add(btnNuevo);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 569);
            panel2.Name = "panel2";
            panel2.Size = new Size(1000, 50);
            panel2.TabIndex = 5;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(913, 13);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(802, 13);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(691, 13);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrarPeriodo
            // 
            btnCerrarPeriodo.Location = new Point(270, 13);
            btnCerrarPeriodo.Name = "btnCerrarPeriodo";
            btnCerrarPeriodo.Size = new Size(120, 23);
            btnCerrarPeriodo.TabIndex = 2;
            btnCerrarPeriodo.Text = "Cerrar Período";
            btnCerrarPeriodo.UseVisualStyleBackColor = true;
            btnCerrarPeriodo.Click += btnCerrarPeriodo_Click;
            // 
            // btnEstablecerActual
            // 
            btnEstablecerActual.Location = new Point(108, 13);
            btnEstablecerActual.Name = "btnEstablecerActual";
            btnEstablecerActual.Size = new Size(140, 23);
            btnEstablecerActual.TabIndex = 1;
            btnEstablecerActual.Text = "Establecer como Actual";
            btnEstablecerActual.UseVisualStyleBackColor = true;
            btnEstablecerActual.Click += btnEstablecerActual_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 13);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblPeriodoActual
            // 
            lblPeriodoActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPeriodoActual.Location = new Point(12, 63);
            lblPeriodoActual.Name = "lblPeriodoActual";
            lblPeriodoActual.Size = new Size(976, 20);
            lblPeriodoActual.TabIndex = 6;
            lblPeriodoActual.Text = "Período Actual: No definido";
            lblPeriodoActual.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmMntPeriodo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 619);
            Controls.Add(lblPeriodoActual);
            Controls.Add(panel2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMntPeriodo";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenedor de Períodos de Proceso";
            Load += frmMntPeriodo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeriodos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private DataGridView dgvPeriodos;
        private GroupBox groupBox2;
        private TextBox txtPeriodo;
        private Label label3;
        private TextBox txtAño;
        private Label label4;
        private TextBox txtDescripcion;
        private Label label5;
        private DateTimePicker dtpApertura;
        private Label label6;
        private CheckBox chkCierre;
        private DateTimePicker dtpCierre;
        private Label label7;
        private CheckBox chkCerrado;
        private ComboBox cmbEstado;
        private Label label9;
        private Panel panel2;
        private Button btnNuevo;
        private Button btnEstablecerActual;
        private Button btnCerrarPeriodo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnSalir;
        private Label lblPeriodoActual;
        private Label lblTotal;
    }
}
