namespace HPH
{
    partial class frmBuscarCargo
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
            dgvCargos = new DataGridView();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            lblFiltro = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCargos).BeginInit();
            SuspendLayout();
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(148, 12);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(404, 23);
            txtFiltro.TabIndex = 1;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // dgvCargos
            // 
            dgvCargos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCargos.Location = new Point(12, 45);
            dgvCargos.Name = "dgvCargos";
            dgvCargos.RowHeadersVisible = false;
            dgvCargos.Size = new Size(540, 300);
            dgvCargos.TabIndex = 2;
            dgvCargos.CellDoubleClick += dgvCargos_CellDoubleClick;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(396, 375);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 4;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(477, 375);
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
            lblFiltro.Size = new Size(130, 15);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Buscar por descripción:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 352);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(91, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: 0 cargo(s)";
            // 
            // frmBuscarCargo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 410);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblTotal);
            Controls.Add(dgvCargos);
            Controls.Add(txtFiltro);
            Controls.Add(lblFiltro);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarCargo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscar Cargo";
            ((System.ComponentModel.ISupportInitialize)dgvCargos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFiltro;
        private DataGridView dgvCargos;
        private Button btnSeleccionar;
        private Button btnCancelar;
        private Label lblFiltro;
        private Label lblTotal;
    }
}
