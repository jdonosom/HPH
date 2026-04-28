namespace HPH
{
    partial class frmMntBoleta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntBoleta));
            btnHelp = new Button();
            cmbCargo = new ComboBox();
            txtNombre = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtRut = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDependencia = new DataGridViewComboBoxColumn();
            colTipoContrato = new DataGridViewComboBoxColumn();
            colNroBoleta = new DataGridViewTextBoxColumn();
            colMntBruto = new DataGridViewTextBoxColumn();
            colMntRetencion = new DataGridViewTextBoxColumn();
            colMntDescuento = new DataGridViewTextBoxColumn();
            colMntLiquido = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colPeriodo = new DataGridViewTextBoxColumn();
            colDecreto = new DataGridViewTextBoxColumn();
            colJornada = new DataGridViewTextBoxColumn();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(122, 97);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(30, 26);
            btnHelp.TabIndex = 9;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // cmbCargo
            // 
            cmbCargo.Enabled = false;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(492, 98);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(291, 23);
            cmbCargo.TabIndex = 11;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(158, 98);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(326, 23);
            txtNombre.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 80);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 5;
            label4.Text = "Rut";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 80);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 6;
            label3.Text = "Nombre";
            // 
            // txtRut
            // 
            txtRut.Location = new Point(20, 98);
            txtRut.MaxLength = 11;
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(100, 23);
            txtRut.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(492, 80);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 8;
            label2.Text = "Cargo";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1309, 57);
            panel1.TabIndex = 12;
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
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colDependencia, colTipoContrato, colNroBoleta, colMntBruto, colMntRetencion, colMntDescuento, colMntLiquido, colTipo, colPeriodo, colDecreto, colJornada });
            dataGridView1.Location = new Point(18, 157);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1272, 315);
            dataGridView1.TabIndex = 14;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 50;
            // 
            // colDependencia
            // 
            colDependencia.HeaderText = "Dependencia";
            colDependencia.Name = "colDependencia";
            colDependencia.Resizable = DataGridViewTriState.True;
            colDependencia.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colTipoContrato
            // 
            colTipoContrato.HeaderText = "Tipo de contrato";
            colTipoContrato.Name = "colTipoContrato";
            colTipoContrato.Resizable = DataGridViewTriState.True;
            colTipoContrato.SortMode = DataGridViewColumnSortMode.Automatic;
            colTipoContrato.Width = 150;
            // 
            // colNroBoleta
            // 
            colNroBoleta.HeaderText = "N° Boleta";
            colNroBoleta.Name = "colNroBoleta";
            // 
            // colMntBruto
            // 
            colMntBruto.HeaderText = "Monto Bruto";
            colMntBruto.Name = "colMntBruto";
            // 
            // colMntRetencion
            // 
            colMntRetencion.HeaderText = "Rentención";
            colMntRetencion.Name = "colMntRetencion";
            // 
            // colMntDescuento
            // 
            colMntDescuento.HeaderText = "Descuentos";
            colMntDescuento.Name = "colMntDescuento";
            // 
            // colMntLiquido
            // 
            colMntLiquido.HeaderText = "Monto Liquido";
            colMntLiquido.Name = "colMntLiquido";
            colMntLiquido.ReadOnly = true;
            colMntLiquido.Width = 150;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            // 
            // colPeriodo
            // 
            colPeriodo.HeaderText = "Periodo";
            colPeriodo.Name = "colPeriodo";
            // 
            // colDecreto
            // 
            colDecreto.HeaderText = "Decreto";
            colDecreto.Name = "colDecreto";
            // 
            // colJornada
            // 
            colJornada.HeaderText = "Jornada";
            colJornada.Name = "colJornada";
            colJornada.ReadOnly = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 130);
            label5.Name = "label5";
            label5.Size = new Size(78, 19);
            label5.TabIndex = 15;
            label5.Text = "Honorarios";
            // 
            // frmMntBoleta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 497);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(btnHelp);
            Controls.Add(cmbCargo);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtRut);
            Controls.Add(label2);
            Name = "frmMntBoleta";
            ShowIcon = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHelp;
        private ComboBox cmbCargo;
        private TextBox txtNombre;
        private Label label4;
        private Label label3;
        private TextBox txtRut;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label5;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewComboBoxColumn colDependencia;
        private DataGridViewComboBoxColumn colTipoContrato;
        private DataGridViewTextBoxColumn colNroBoleta;
        private DataGridViewTextBoxColumn colMntBruto;
        private DataGridViewTextBoxColumn colMntRetencion;
        private DataGridViewTextBoxColumn colMntDescuento;
        private DataGridViewTextBoxColumn colMntLiquido;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colPeriodo;
        private DataGridViewTextBoxColumn colDecreto;
        private DataGridViewTextBoxColumn colJornada;
    }
}