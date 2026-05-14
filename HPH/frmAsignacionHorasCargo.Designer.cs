namespace HPH
{
    partial class frmAsignacionHorasCargo
    {
        private System.ComponentModel.IContainer components = null;

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
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            cmbCargo = new ComboBox();
            lblDisponibles = new Label();
            lstValoresDisponibles = new ListBox();
            lstValoresAsignados = new ListBox();
            lblAsignados = new Label();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnAgregarTodos = new Button();
            btnQuitarTodos = new Button();
            btnCerrar = new Button();
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
            panel1.Size = new Size(784, 57);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 15);
            label1.Name = "label1";
            label1.Size = new Size(326, 26);
            label1.TabIndex = 1;
            label1.Text = "Asignación de Valores Hora por Cargo";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 74);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Cargo:";
            // 
            // cmbCargo
            // 
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(66, 71);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(400, 23);
            cmbCargo.TabIndex = 2;
            cmbCargo.SelectedIndexChanged += cmbCargo_SelectedIndexChanged;
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDisponibles.Location = new Point(18, 110);
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.Size = new Size(88, 15);
            lblDisponibles.TabIndex = 3;
            lblDisponibles.Text = "Disponibles (0)";
            // 
            // lstValoresDisponibles
            // 
            lstValoresDisponibles.FormattingEnabled = true;
            lstValoresDisponibles.ItemHeight = 15;
            lstValoresDisponibles.Location = new Point(18, 130);
            lstValoresDisponibles.Name = "lstValoresDisponibles";
            lstValoresDisponibles.Size = new Size(320, 334);
            lstValoresDisponibles.TabIndex = 4;
            // 
            // lstValoresAsignados
            // 
            lstValoresAsignados.FormattingEnabled = true;
            lstValoresAsignados.ItemHeight = 15;
            lstValoresAsignados.Location = new Point(446, 130);
            lstValoresAsignados.Name = "lstValoresAsignados";
            lstValoresAsignados.Size = new Size(320, 334);
            lstValoresAsignados.TabIndex = 5;
            // 
            // lblAsignados
            // 
            lblAsignados.AutoSize = true;
            lblAsignados.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAsignados.Location = new Point(446, 110);
            lblAsignados.Name = "lblAsignados";
            lblAsignados.Size = new Size(80, 15);
            lblAsignados.TabIndex = 6;
            lblAsignados.Text = "Asignados (0)";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(355, 200);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 30);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = ">";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(355, 250);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 30);
            btnQuitar.TabIndex = 8;
            btnQuitar.Text = "<";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregarTodos
            // 
            btnAgregarTodos.Location = new Point(355, 300);
            btnAgregarTodos.Name = "btnAgregarTodos";
            btnAgregarTodos.Size = new Size(75, 30);
            btnAgregarTodos.TabIndex = 9;
            btnAgregarTodos.Text = ">>";
            btnAgregarTodos.UseVisualStyleBackColor = true;
            btnAgregarTodos.Click += btnAgregarTodos_Click;
            // 
            // btnQuitarTodos
            // 
            btnQuitarTodos.Location = new Point(355, 350);
            btnQuitarTodos.Name = "btnQuitarTodos";
            btnQuitarTodos.Size = new Size(75, 30);
            btnQuitarTodos.TabIndex = 10;
            btnQuitarTodos.Text = "<<";
            btnQuitarTodos.UseVisualStyleBackColor = true;
            btnQuitarTodos.Click += btnQuitarTodos_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(666, 480);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "&Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmAsignacionHorasCargo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 531);
            Controls.Add(btnCerrar);
            Controls.Add(btnQuitarTodos);
            Controls.Add(btnAgregarTodos);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(lblAsignados);
            Controls.Add(lstValoresAsignados);
            Controls.Add(lstValoresDisponibles);
            Controls.Add(lblDisponibles);
            Controls.Add(cmbCargo);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAsignacionHorasCargo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Asignación de Valores Hora por Cargo";
            Load += frmAsignacionHorasCargo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private ComboBox cmbCargo;
        private Label lblDisponibles;
        private ListBox lstValoresDisponibles;
        private ListBox lstValoresAsignados;
        private Label lblAsignados;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnAgregarTodos;
        private Button btnQuitarTodos;
        private Button btnCerrar;
    }
}
