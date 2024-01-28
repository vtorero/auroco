namespace AurocoPublicidad.forms
{
    partial class FrmOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrden));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.finVigencia = new System.Windows.Forms.DateTimePicker();
            this.inicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMoneda = new System.Windows.Forms.ComboBox();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridOrden = new System.Windows.Forms.DataGridView();
            this.horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.L1 = new System.Windows.Forms.Label();
            this.L2 = new System.Windows.Forms.Label();
            this.L3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.finVigencia);
            this.groupBox1.Controls.Add(this.inicioVigencia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboMoneda);
            this.groupBox1.Controls.Add(this.comboCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1153, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Principales";
            // 
            // finVigencia
            // 
            this.finVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.finVigencia.Location = new System.Drawing.Point(233, 104);
            this.finVigencia.Name = "finVigencia";
            this.finVigencia.Size = new System.Drawing.Size(93, 20);
            this.finVigencia.TabIndex = 26;
            // 
            // inicioVigencia
            // 
            this.inicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inicioVigencia.Location = new System.Drawing.Point(77, 104);
            this.inicioVigencia.Name = "inicioVigencia";
            this.inicioVigencia.Size = new System.Drawing.Size(93, 20);
            this.inicioVigencia.TabIndex = 25;
            this.inicioVigencia.Validated += new System.EventHandler(this.inicioVigencia_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Contrato:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboMoneda
            // 
            this.comboMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMoneda.FormattingEnabled = true;
            this.comboMoneda.Location = new System.Drawing.Point(599, 30);
            this.comboMoneda.Name = "comboMoneda";
            this.comboMoneda.Size = new System.Drawing.Size(196, 21);
            this.comboMoneda.TabIndex = 23;
            this.comboMoneda.SelectedIndexChanged += new System.EventHandler(this.comboMoneda_SelectedIndexChanged);
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(77, 28);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(460, 24);
            this.comboCliente.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cliente:";
            // 
            // dataGridOrden
            // 
            this.dataGridOrden.AllowUserToOrderColumns = true;
            this.dataGridOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.horario,
            this.costo,
            this.d1,
            this.d2,
            this.d3,
            this.d4,
            this.d5,
            this.d6,
            this.d7,
            this.d8,
            this.d9,
            this.d10,
            this.d11,
            this.d12,
            this.d13,
            this.d14,
            this.d15,
            this.d16,
            this.d17,
            this.d18,
            this.d19,
            this.d20,
            this.d21,
            this.d22,
            this.d23,
            this.d24,
            this.d25,
            this.d26,
            this.d27,
            this.d28,
            this.d29,
            this.d30,
            this.d31,
            this.total});
            this.dataGridOrden.Location = new System.Drawing.Point(38, 355);
            this.dataGridOrden.Name = "dataGridOrden";
            this.dataGridOrden.Size = new System.Drawing.Size(1153, 209);
            this.dataGridOrden.TabIndex = 1;
            this.dataGridOrden.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrden_CellLeave);
            // 
            // horario
            // 
            this.horario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.horario.HeaderText = "Horario";
            this.horario.Name = "horario";
            this.horario.Width = 110;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.Width = 110;
            // 
            // d1
            // 
            this.d1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.d1.HeaderText = "1";
            this.d1.Name = "d1";
            this.d1.Width = 20;
            // 
            // d2
            // 
            this.d2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.d2.HeaderText = "2";
            this.d2.Name = "d2";
            this.d2.Width = 20;
            // 
            // d3
            // 
            this.d3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.d3.HeaderText = "3";
            this.d3.Name = "d3";
            this.d3.Width = 20;
            // 
            // d4
            // 
            this.d4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.d4.HeaderText = "4";
            this.d4.Name = "d4";
            this.d4.Width = 20;
            // 
            // d5
            // 
            this.d5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.d5.HeaderText = "5";
            this.d5.Name = "d5";
            this.d5.Width = 20;
            // 
            // d6
            // 
            this.d6.HeaderText = "6";
            this.d6.Name = "d6";
            this.d6.Width = 20;
            // 
            // d7
            // 
            this.d7.HeaderText = "7";
            this.d7.Name = "d7";
            this.d7.Width = 20;
            // 
            // d8
            // 
            this.d8.HeaderText = "8";
            this.d8.Name = "d8";
            this.d8.Width = 20;
            // 
            // d9
            // 
            this.d9.HeaderText = "9";
            this.d9.Name = "d9";
            this.d9.Width = 20;
            // 
            // d10
            // 
            this.d10.HeaderText = "10";
            this.d10.Name = "d10";
            this.d10.Width = 20;
            // 
            // d11
            // 
            this.d11.HeaderText = "11";
            this.d11.Name = "d11";
            this.d11.Width = 20;
            // 
            // d12
            // 
            this.d12.HeaderText = "12";
            this.d12.Name = "d12";
            this.d12.Width = 20;
            // 
            // d13
            // 
            this.d13.HeaderText = "13";
            this.d13.Name = "d13";
            this.d13.Width = 20;
            // 
            // d14
            // 
            this.d14.HeaderText = "14";
            this.d14.Name = "d14";
            this.d14.Width = 20;
            // 
            // d15
            // 
            this.d15.HeaderText = "15";
            this.d15.Name = "d15";
            this.d15.Width = 20;
            // 
            // d16
            // 
            this.d16.HeaderText = "16";
            this.d16.Name = "d16";
            this.d16.Width = 20;
            // 
            // d17
            // 
            this.d17.HeaderText = "17";
            this.d17.Name = "d17";
            this.d17.Width = 20;
            // 
            // d18
            // 
            this.d18.HeaderText = "18";
            this.d18.Name = "d18";
            this.d18.Width = 20;
            // 
            // d19
            // 
            this.d19.HeaderText = "19";
            this.d19.Name = "d19";
            this.d19.Width = 20;
            // 
            // d20
            // 
            this.d20.HeaderText = "20";
            this.d20.Name = "d20";
            this.d20.Width = 20;
            // 
            // d21
            // 
            this.d21.HeaderText = "21";
            this.d21.Name = "d21";
            this.d21.Width = 20;
            // 
            // d22
            // 
            this.d22.HeaderText = "22";
            this.d22.Name = "d22";
            this.d22.Width = 20;
            // 
            // d23
            // 
            this.d23.HeaderText = "23";
            this.d23.Name = "d23";
            this.d23.Width = 20;
            // 
            // d24
            // 
            this.d24.HeaderText = "24";
            this.d24.Name = "d24";
            this.d24.Width = 20;
            // 
            // d25
            // 
            this.d25.HeaderText = "25";
            this.d25.Name = "d25";
            this.d25.Width = 20;
            // 
            // d26
            // 
            this.d26.HeaderText = "26";
            this.d26.Name = "d26";
            this.d26.Width = 20;
            // 
            // d27
            // 
            this.d27.HeaderText = "27";
            this.d27.Name = "d27";
            this.d27.Width = 20;
            // 
            // d28
            // 
            this.d28.HeaderText = "28";
            this.d28.Name = "d28";
            this.d28.Width = 20;
            // 
            // d29
            // 
            this.d29.HeaderText = "29";
            this.d29.Name = "d29";
            this.d29.Width = 20;
            // 
            // d30
            // 
            this.d30.HeaderText = "30";
            this.d30.Name = "d30";
            this.d30.Width = 20;
            // 
            // d31
            // 
            this.d31.HeaderText = "31";
            this.d31.Name = "d31";
            this.d31.Width = 20;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1086, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar Linea";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // L1
            // 
            this.L1.AutoSize = true;
            this.L1.Location = new System.Drawing.Point(488, 330);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(13, 13);
            this.L1.TabIndex = 3;
            this.L1.Text = "..";
            // 
            // L2
            // 
            this.L2.AutoSize = true;
            this.L2.Location = new System.Drawing.Point(509, 330);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(13, 13);
            this.L2.TabIndex = 4;
            this.L2.Text = "..";
            // 
            // L3
            // 
            this.L3.AutoSize = true;
            this.L3.Location = new System.Drawing.Point(530, 330);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(13, 13);
            this.L3.TabIndex = 5;
            this.L3.Text = "..";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1086, 586);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 643);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.L3);
            this.Controls.Add(this.L2);
            this.Controls.Add(this.L1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridOrden);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOrden";
            this.Text = "Ingresar Orden";
            this.Load += new System.EventHandler(this.FrmOrden_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMoneda;
        private System.Windows.Forms.DataGridView dataGridOrden;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker inicioVigencia;
        private System.Windows.Forms.Label L1;
        private System.Windows.Forms.Label L2;
        private System.Windows.Forms.Label L3;
        private System.Windows.Forms.DateTimePicker finVigencia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn d1;
        private System.Windows.Forms.DataGridViewTextBoxColumn d2;
        private System.Windows.Forms.DataGridViewTextBoxColumn d3;
        private System.Windows.Forms.DataGridViewTextBoxColumn d4;
        private System.Windows.Forms.DataGridViewTextBoxColumn d5;
        private System.Windows.Forms.DataGridViewTextBoxColumn d6;
        private System.Windows.Forms.DataGridViewTextBoxColumn d7;
        private System.Windows.Forms.DataGridViewTextBoxColumn d8;
        private System.Windows.Forms.DataGridViewTextBoxColumn d9;
        private System.Windows.Forms.DataGridViewTextBoxColumn d10;
        private System.Windows.Forms.DataGridViewTextBoxColumn d11;
        private System.Windows.Forms.DataGridViewTextBoxColumn d12;
        private System.Windows.Forms.DataGridViewTextBoxColumn d13;
        private System.Windows.Forms.DataGridViewTextBoxColumn d14;
        private System.Windows.Forms.DataGridViewTextBoxColumn d15;
        private System.Windows.Forms.DataGridViewTextBoxColumn d16;
        private System.Windows.Forms.DataGridViewTextBoxColumn d17;
        private System.Windows.Forms.DataGridViewTextBoxColumn d18;
        private System.Windows.Forms.DataGridViewTextBoxColumn d19;
        private System.Windows.Forms.DataGridViewTextBoxColumn d20;
        private System.Windows.Forms.DataGridViewTextBoxColumn d21;
        private System.Windows.Forms.DataGridViewTextBoxColumn d22;
        private System.Windows.Forms.DataGridViewTextBoxColumn d23;
        private System.Windows.Forms.DataGridViewTextBoxColumn d24;
        private System.Windows.Forms.DataGridViewTextBoxColumn d25;
        private System.Windows.Forms.DataGridViewTextBoxColumn d26;
        private System.Windows.Forms.DataGridViewTextBoxColumn d27;
        private System.Windows.Forms.DataGridViewTextBoxColumn d28;
        private System.Windows.Forms.DataGridViewTextBoxColumn d29;
        private System.Windows.Forms.DataGridViewTextBoxColumn d30;
        private System.Windows.Forms.DataGridViewTextBoxColumn d31;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}