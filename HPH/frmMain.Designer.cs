namespace HPH
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panel1 = new Panel();
            lblPeriodo = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            administraciónToolStripMenuItem = new ToolStripMenuItem();
            funcionariosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            cargosToolStripMenuItem = new ToolStripMenuItem();
            asignaciónHorasPorCargoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            dependenciaToolStripMenuItem = new ToolStripMenuItem();
            valorHoraToolStripMenuItem = new ToolStripMenuItem();
            tipoDeContratoToolStripMenuItem = new ToolStripMenuItem();
            cargarDatosToolStripMenuItem = new ToolStripMenuItem();
            nominaDeHonorariosToolStripMenuItem = new ToolStripMenuItem();
            procesoHonorariosToolStripMenuItem = new ToolStripMenuItem();
            periodoDeProcesoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ingresToolStripMenuItem = new ToolStripMenuItem();
            ingresoDeHorasToolStripMenuItem = new ToolStripMenuItem();
            sstPeriodo = new StatusStrip();
            tsPeriodo = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            sstPeriodo.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblPeriodo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 86);
            panel1.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            lblPeriodo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPeriodo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPeriodo.Location = new Point(688, 37);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(95, 15);
            lblPeriodo.TabIndex = 5;
            lblPeriodo.Text = "0";
            lblPeriodo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(688, 16);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 4;
            label2.Text = "Periodo en curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 16);
            label1.Name = "label1";
            label1.Size = new Size(358, 26);
            label1.TabIndex = 3;
            label1.Text = "Control de Horas Pagadas con Honorarios";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(6, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { administraciónToolStripMenuItem, cargarDatosToolStripMenuItem, procesoHonorariosToolStripMenuItem });
            menuStrip1.Location = new Point(6, 55);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(779, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // administraciónToolStripMenuItem
            // 
            administraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { funcionariosToolStripMenuItem, toolStripMenuItem4, cargosToolStripMenuItem, asignaciónHorasPorCargoToolStripMenuItem, toolStripMenuItem5, dependenciaToolStripMenuItem, valorHoraToolStripMenuItem, tipoDeContratoToolStripMenuItem });
            administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            administraciónToolStripMenuItem.Size = new Size(100, 20);
            administraciónToolStripMenuItem.Text = "Administración";
            administraciónToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // funcionariosToolStripMenuItem
            // 
            funcionariosToolStripMenuItem.Name = "funcionariosToolStripMenuItem";
            funcionariosToolStripMenuItem.Size = new Size(219, 22);
            funcionariosToolStripMenuItem.Text = "Funcionarios";
            funcionariosToolStripMenuItem.Click += funcionariosToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(216, 6);
            // 
            // cargosToolStripMenuItem
            // 
            cargosToolStripMenuItem.Name = "cargosToolStripMenuItem";
            cargosToolStripMenuItem.Size = new Size(219, 22);
            cargosToolStripMenuItem.Text = "Cargos";
            cargosToolStripMenuItem.Click += cargosToolStripMenuItem_Click;
            // 
            // asignaciónHorasPorCargoToolStripMenuItem
            // 
            asignaciónHorasPorCargoToolStripMenuItem.Name = "asignaciónHorasPorCargoToolStripMenuItem";
            asignaciónHorasPorCargoToolStripMenuItem.Size = new Size(219, 22);
            asignaciónHorasPorCargoToolStripMenuItem.Text = "Asignación horas por cargo";
            asignaciónHorasPorCargoToolStripMenuItem.Click += asignaciónHorasPorCargoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(216, 6);
            // 
            // dependenciaToolStripMenuItem
            // 
            dependenciaToolStripMenuItem.Name = "dependenciaToolStripMenuItem";
            dependenciaToolStripMenuItem.Size = new Size(219, 22);
            dependenciaToolStripMenuItem.Text = "Dependencia";
            dependenciaToolStripMenuItem.Click += dependenciaToolStripMenuItem_Click;
            // 
            // valorHoraToolStripMenuItem
            // 
            valorHoraToolStripMenuItem.Name = "valorHoraToolStripMenuItem";
            valorHoraToolStripMenuItem.Size = new Size(219, 22);
            valorHoraToolStripMenuItem.Text = "Valor Hora";
            valorHoraToolStripMenuItem.Click += valorHoraToolStripMenuItem_Click;
            // 
            // tipoDeContratoToolStripMenuItem
            // 
            tipoDeContratoToolStripMenuItem.Name = "tipoDeContratoToolStripMenuItem";
            tipoDeContratoToolStripMenuItem.Size = new Size(219, 22);
            tipoDeContratoToolStripMenuItem.Text = "Tipo de Contrato";
            // 
            // cargarDatosToolStripMenuItem
            // 
            cargarDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nominaDeHonorariosToolStripMenuItem });
            cargarDatosToolStripMenuItem.Name = "cargarDatosToolStripMenuItem";
            cargarDatosToolStripMenuItem.Size = new Size(86, 20);
            cargarDatosToolStripMenuItem.Text = "Cargar datos";
            cargarDatosToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nominaDeHonorariosToolStripMenuItem
            // 
            nominaDeHonorariosToolStripMenuItem.Name = "nominaDeHonorariosToolStripMenuItem";
            nominaDeHonorariosToolStripMenuItem.Size = new Size(193, 22);
            nominaDeHonorariosToolStripMenuItem.Text = "Nomina de honorarios";
            nominaDeHonorariosToolStripMenuItem.Click += nominaDeHonorariosToolStripMenuItem_Click;
            // 
            // procesoHonorariosToolStripMenuItem
            // 
            procesoHonorariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { periodoDeProcesoToolStripMenuItem, toolStripMenuItem1, ingresToolStripMenuItem, ingresoDeHorasToolStripMenuItem });
            procesoHonorariosToolStripMenuItem.Name = "procesoHonorariosToolStripMenuItem";
            procesoHonorariosToolStripMenuItem.Size = new Size(106, 20);
            procesoHonorariosToolStripMenuItem.Text = "Ingreso de datos";
            // 
            // periodoDeProcesoToolStripMenuItem
            // 
            periodoDeProcesoToolStripMenuItem.Name = "periodoDeProcesoToolStripMenuItem";
            periodoDeProcesoToolStripMenuItem.Size = new Size(180, 22);
            periodoDeProcesoToolStripMenuItem.Text = "Periodo de proceso";
            periodoDeProcesoToolStripMenuItem.Click += periodoDeProcesoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // ingresToolStripMenuItem
            // 
            ingresToolStripMenuItem.Name = "ingresToolStripMenuItem";
            ingresToolStripMenuItem.Size = new Size(180, 22);
            ingresToolStripMenuItem.Text = "Ingreso de boletas";
            ingresToolStripMenuItem.Click += ingresToolStripMenuItem_Click;
            // 
            // ingresoDeHorasToolStripMenuItem
            // 
            ingresoDeHorasToolStripMenuItem.Name = "ingresoDeHorasToolStripMenuItem";
            ingresoDeHorasToolStripMenuItem.Size = new Size(180, 22);
            ingresoDeHorasToolStripMenuItem.Text = "Ingreso de horas";
            // 
            // sstPeriodo
            // 
            sstPeriodo.Items.AddRange(new ToolStripItem[] { tsPeriodo, toolStripStatusLabel2, toolStripStatusLabel1 });
            sstPeriodo.Location = new Point(0, 310);
            sstPeriodo.Name = "sstPeriodo";
            sstPeriodo.Size = new Size(794, 22);
            sstPeriodo.TabIndex = 4;
            sstPeriodo.Text = "statusStrip1";
            // 
            // tsPeriodo
            // 
            tsPeriodo.Name = "tsPeriodo";
            tsPeriodo.Size = new Size(57, 17);
            tsPeriodo.Text = "tsPeriodo";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(675, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(47, 17);
            toolStripStatusLabel1.Text = "tsFecha";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 332);
            Controls.Add(sstPeriodo);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CHPH";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            sstPeriodo.ResumeLayout(false);
            sstPeriodo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem administraciónToolStripMenuItem;
        private ToolStripMenuItem cargosToolStripMenuItem;
        private ToolStripMenuItem funcionariosToolStripMenuItem;
        private ToolStripMenuItem cargarDatosToolStripMenuItem;
        private ToolStripMenuItem nominaDeHonorariosToolStripMenuItem;
        private ToolStripMenuItem procesoHonorariosToolStripMenuItem;
        private ToolStripMenuItem periodoDeProcesoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ingresToolStripMenuItem;
        private ToolStripMenuItem ingresoDeHorasToolStripMenuItem;
        private StatusStrip sstPeriodo;
        private ToolStripStatusLabel tsPeriodo;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem dependenciaToolStripMenuItem;
        private ToolStripMenuItem valorHoraToolStripMenuItem;
        private ToolStripMenuItem tipoDeContratoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem asignaciónHorasPorCargoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private Label lblPeriodo;
        private Label label2;
    }
}