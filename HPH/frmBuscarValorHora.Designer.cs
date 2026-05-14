namespace HPH
{
    partial class frmBuscarValorHora
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFiltro;
        private DataGridView dgvValoresHora;
        private Button btnSeleccionar;
        private Button btnCancelar;
        private Label lblFiltro;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFiltro = new TextBox();
            dgvValoresHora = new DataGridView();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            lblFiltro = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvValoresHora).BeginInit();
            SuspendLayout();
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
            // txtFiltro
            // 
            txtFiltro.Location = new Point(148, 12);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(504, 23);
            txtFiltro.TabIndex = 1;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // dgvValoresHora
            // 
            dgvValoresHora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvValoresHora.Location = new Point(12, 45);
            dgvValoresHora.Name = "dgvValoresHora";
            dgvValoresHora.RowTemplate.Height = 25;
            dgvValoresHora.Size = new Size(640, 320);
            dgvValoresHora.TabIndex = 2;
            dgvValoresHora.CellDoubleClick += dgvValoresHora_CellDoubleClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 372);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(116, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: 0 valor(es) hora";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(496, 395);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 4;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(577, 395);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmBuscarValorHora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 430);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(lblTotal);
            Controls.Add(dgvValoresHora);
            Controls.Add(txtFiltro);
            Controls.Add(lblFiltro);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuscarValorHora";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscar Valor Hora";
            ((System.ComponentModel.ISupportInitialize)dgvValoresHora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
