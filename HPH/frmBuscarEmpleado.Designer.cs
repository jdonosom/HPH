namespace HPH
{
    partial class frmBuscarEmpleado
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
            txtFiltro = new TextBox();
            dgvEmpleados = new DataGridView();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            lblFiltro = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(128, 12);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(444, 23);
            txtFiltro.TabIndex = 1;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(12, 45);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.Size = new Size(560, 320);
            dgvEmpleados.TabIndex = 2;
            dgvEmpleados.CellDoubleClick += dgvEmpleados_CellDoubleClick;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(416, 395);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 4;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(497, 395);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(12, 15);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(111, 15);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Buscar por nombre:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 372);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(114, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: 0 empleado(s)";
            // 
            // frmBuscarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 430);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblTotal);
            Controls.Add(dgvEmpleados);
            Controls.Add(txtFiltro);
            Controls.Add(lblFiltro);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarEmpleado";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscar Empleado";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFiltro;
        private DataGridView dgvEmpleados;
        private Button btnSeleccionar;
        private Button btnCancelar;
        private Label lblFiltro;
        private Label lblTotal;
    }
}
