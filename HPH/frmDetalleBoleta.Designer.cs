namespace HPH
{
    partial class frmDetalleBoleta
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
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label7 = new Label();
            colItem = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colMinutos = new DataGridViewTextBoxColumn();
            colFracinado = new DataGridViewTextBoxColumn();
            colCodHora = new DataGridViewTextBoxColumn();
            colValorHora = new DataGridViewComboBoxColumn();
            colResultado = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Boleta N°";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colItem, colHora, colMinutos, colFracinado, colCodHora, colValorHora, colResultado });
            dataGridView1.Location = new Point(12, 106);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(737, 150);
            dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(543, 269);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 0;
            label2.Text = "Monto Bruto";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.MenuHighlight;
            textBox2.Enabled = false;
            textBox2.Location = new Point(543, 291);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(649, 332);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Diferencia";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(649, 350);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(649, 269);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 0;
            label4.Text = "Total Resultado";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(649, 291);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(535, 412);
            button1.Name = "button1";
            button1.Size = new Size(104, 30);
            button1.TabIndex = 3;
            button1.Text = "&Aceptar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(645, 412);
            button2.Name = "button2";
            button2.Size = new Size(104, 30);
            button2.TabIndex = 3;
            button2.Text = "&Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(20, 416);
            button3.Name = "button3";
            button3.Size = new Size(104, 30);
            button3.TabIndex = 3;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(137, 18);
            label5.Name = "label5";
            label5.Size = new Size(25, 15);
            label5.TabIndex = 0;
            label5.Text = "Rut";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(233, 18);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 0;
            label6.Text = "Nombre";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(137, 40);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(87, 23);
            textBox5.TabIndex = 1;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(233, 40);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(516, 23);
            textBox6.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 79);
            label7.Name = "label7";
            label7.Size = new Size(118, 15);
            label7.TabIndex = 0;
            label7.Text = "DETALLE DE BOLETA";
            // 
            // colItem
            // 
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.ReadOnly = true;
            colItem.Width = 50;
            // 
            // colHora
            // 
            colHora.HeaderText = "Horas";
            colHora.Name = "colHora";
            // 
            // colMinutos
            // 
            colMinutos.HeaderText = "Minutos";
            colMinutos.Name = "colMinutos";
            // 
            // colFracinado
            // 
            colFracinado.HeaderText = "Fraccionado";
            colFracinado.Name = "colFracinado";
            colFracinado.ReadOnly = true;
            // 
            // colCodHora
            // 
            colCodHora.HeaderText = "Cód.Hora";
            colCodHora.Name = "colCodHora";
            colCodHora.Width = 65;
            // 
            // colValorHora
            // 
            colValorHora.HeaderText = "Valor Hora";
            colValorHora.Name = "colValorHora";
            colValorHora.Resizable = DataGridViewTriState.True;
            colValorHora.SortMode = DataGridViewColumnSortMode.Automatic;
            colValorHora.Width = 200;
            // 
            // colResultado
            // 
            colResultado.HeaderText = "Resultado";
            colResultado.Name = "colResultado";
            // 
            // frmDetalleBoleta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 458);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDetalleBoleta";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colMinutos;
        private DataGridViewTextBoxColumn colFracinado;
        private DataGridViewComboBoxColumn colValorHora;
        private DataGridViewTextBoxColumn colResultado;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label5;
        private Label label6;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label7;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colCodHora;
    }
}