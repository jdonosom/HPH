namespace HPH
{
    partial class frmUnloadEmpleados
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            textBox1 = new TextBox();
            btnOpenFile = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 47);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 0;
            label1.Text = "Archivos de empleados ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 65);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(414, 23);
            textBox1.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(448, 65);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(60, 23);
            btnOpenFile.TabIndex = 2;
            btnOpenFile.Text = "...";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(289, 111);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(104, 26);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(399, 111);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(104, 26);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(167, 47);
            label2.Name = "label2";
            label2.Size = new Size(226, 15);
            label2.TabIndex = 4;
            label2.Text = "(Por defecto se lee desde Documentos)";
            // 
            // frmUnloadEmpleados
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 149);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(btnOpenFile);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUnloadEmpleados";
            ShowIcon = false;
            Text = "Carga Empleados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Label label1;
        private TextBox textBox1;
        private Button btnOpenFile;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label2;
    }
}
