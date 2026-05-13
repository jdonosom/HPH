namespace HPH
{
    partial class frmBuscarBoleta
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
            dgvBoletas = new DataGridView();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            lblFiltro = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBoletas).BeginInit();
            SuspendLayout();
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(12, 15);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(154, 15);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Buscar (Nombre o N° Boleta):";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(172, 12);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(600, 23);
            txtFiltro.TabIndex = 1;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // dgvBoletas
            // 
            dgvBoletas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBoletas.Location = new Point(12, 45);
            dgvBoletas.Name = "dgvBoletas";
            dgvBoletas.RowTemplate.Height = 25;
            dgvBoletas.Size = new Size(760, 400);
            dgvBoletas.TabIndex = 2;
            dgvBoletas.CellDoubleClick += dgvBoletas_CellDoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 452);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(90, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: 0 boleta(s)";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(616, 475);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 4;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(697, 475);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmBuscarBoleta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 510);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblTotal);
            Controls.Add(dgvBoletas);
            Controls.Add(txtFiltro);
            Controls.Add(lblFiltro);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarBoleta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscar Boleta";
            ((System.ComponentModel.ISupportInitialize)dgvBoletas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFiltro;
        private DataGridView dgvBoletas;
        private Button btnSeleccionar;
        private Button btnCancelar;
        private Label lblFiltro;
        private Label lblTotal;
    }
}
