namespace AurocoPublicidad.forms
{
    partial class FrmFacturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturar));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.totalBruto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtIgv = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.totalOrden = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.LblNumero = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textObservaciones = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUbigeo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtCambioSunat = new System.Windows.Forms.TextBox();
            this.porcentajeDet = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.chkDetrac = new System.Windows.Forms.CheckBox();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataCuentas = new System.Windows.Forms.DataGridView();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdContado = new System.Windows.Forms.RadioButton();
            this.rdCredito = new System.Windows.Forms.RadioButton();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDistrito = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cMoneda = new System.Windows.Forms.TextBox();
            this.fechaEmision = new System.Windows.Forms.DateTimePicker();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCuentas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Chartreuse;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // totalBruto
            // 
            resources.ApplyResources(this.totalBruto, "totalBruto");
            this.totalBruto.Name = "totalBruto";
            this.totalBruto.ReadOnly = true;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // txtIgv
            // 
            resources.ApplyResources(this.txtIgv, "txtIgv");
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.ReadOnly = true;
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // totalOrden
            // 
            resources.ApplyResources(this.totalOrden, "totalOrden");
            this.totalOrden.Name = "totalOrden";
            this.totalOrden.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label19);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnGuardar
            // 
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.txtNumero, "txtNumero");
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // LblNumero
            // 
            resources.ApplyResources(this.LblNumero, "LblNumero");
            this.LblNumero.Name = "LblNumero";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // textObservaciones
            // 
            resources.ApplyResources(this.textObservaciones, "textObservaciones");
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.TextChanged += new System.EventHandler(this.textObservaciones_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCambio);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtUbigeo);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnVistaPrevia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataCuentas);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDistrito);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtProvincia);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDpto);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIgv);
            this.groupBox1.Controls.Add(this.totalBruto);
            this.groupBox1.Controls.Add(this.txtRuc);
            this.groupBox1.Controls.Add(this.txtAgencia);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.totalOrden);
            this.groupBox1.Controls.Add(this.LblNumero);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textObservaciones);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cMoneda);
            this.groupBox1.Controls.Add(this.fechaEmision);
            this.groupBox1.Controls.Add(this.comboCliente);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.txtCambio, "txtCambio");
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txtUbigeo
            // 
            resources.ApplyResources(this.txtUbigeo, "txtUbigeo");
            this.txtUbigeo.Name = "txtUbigeo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.txtCambioSunat);
            this.groupBox4.Controls.Add(this.porcentajeDet);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.chkDetrac);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtCambioSunat
            // 
            resources.ApplyResources(this.txtCambioSunat, "txtCambioSunat");
            this.txtCambioSunat.Name = "txtCambioSunat";
            // 
            // porcentajeDet
            // 
            resources.ApplyResources(this.porcentajeDet, "porcentajeDet");
            this.porcentajeDet.Name = "porcentajeDet";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // chkDetrac
            // 
            resources.ApplyResources(this.chkDetrac, "chkDetrac");
            this.chkDetrac.Name = "chkDetrac";
            this.chkDetrac.UseVisualStyleBackColor = true;
            this.chkDetrac.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnVistaPrevia
            // 
            resources.ApplyResources(this.btnVistaPrevia, "btnVistaPrevia");
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.UseVisualStyleBackColor = true;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dataCuentas
            // 
            this.dataCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monto});
            resources.ApplyResources(this.dataCuentas, "dataCuentas");
            this.dataCuentas.Name = "dataCuentas";
            this.dataCuentas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCuentas_CellValueChanged);
            this.dataCuentas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataCuentas_RowsAdded);
            // 
            // monto
            // 
            resources.ApplyResources(this.monto, "monto");
            this.monto.Name = "monto";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdContado);
            this.groupBox3.Controls.Add(this.rdCredito);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rdContado
            // 
            resources.ApplyResources(this.rdContado, "rdContado");
            this.rdContado.Checked = true;
            this.rdContado.Name = "rdContado";
            this.rdContado.TabStop = true;
            this.rdContado.UseVisualStyleBackColor = true;
            this.rdContado.CheckedChanged += new System.EventHandler(this.rdContado_CheckedChanged);
            // 
            // rdCredito
            // 
            resources.ApplyResources(this.rdCredito, "rdCredito");
            this.rdCredito.Name = "rdCredito";
            this.rdCredito.UseVisualStyleBackColor = true;
            this.rdCredito.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtMotivo
            // 
            resources.ApplyResources(this.txtMotivo, "txtMotivo");
            this.txtMotivo.Name = "txtMotivo";
            // 
            // btnEnviar
            // 
            resources.ApplyResources(this.btnEnviar, "btnEnviar");
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtProducto
            // 
            resources.ApplyResources(this.txtProducto, "txtProducto");
            this.txtProducto.Name = "txtProducto";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtDistrito
            // 
            resources.ApplyResources(this.txtDistrito, "txtDistrito");
            this.txtDistrito.Name = "txtDistrito";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtProvincia
            // 
            resources.ApplyResources(this.txtProvincia, "txtProvincia");
            this.txtProvincia.Name = "txtProvincia";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtDpto
            // 
            resources.ApplyResources(this.txtDpto, "txtDpto");
            this.txtDpto.Name = "txtDpto";
            // 
            // txtDireccion
            // 
            resources.ApplyResources(this.txtDireccion, "txtDireccion");
            this.txtDireccion.Name = "txtDireccion";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtRuc
            // 
            resources.ApplyResources(this.txtRuc, "txtRuc");
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.ReadOnly = true;
            // 
            // txtAgencia
            // 
            this.txtAgencia.FormattingEnabled = true;
            resources.ApplyResources(this.txtAgencia, "txtAgencia");
            this.txtAgencia.Name = "txtAgencia";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cMoneda
            // 
            this.cMoneda.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.cMoneda, "cMoneda");
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            // 
            // fechaEmision
            // 
            resources.ApplyResources(this.fechaEmision, "fechaEmision");
            this.fechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaEmision.Name = "fechaEmision";
            this.fechaEmision.ValueChanged += new System.EventHandler(this.fechaEmision_ValueChanged);
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.comboCliente, "comboCliente");
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Name = "comboCliente";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // FrmFacturar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFacturar";
            this.Load += new System.EventHandler(this.FrmFacturar_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCuentas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox totalBruto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtIgv;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox totalOrden;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label LblNumero;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox textObservaciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cMoneda;
        private System.Windows.Forms.DateTimePicker fechaEmision;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDistrito;
        private System.Windows.Forms.ComboBox txtAgencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.RadioButton rdCredito;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdContado;
        private System.Windows.Forms.DataGridView dataCuentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown porcentajeDet;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkDetrac;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtUbigeo;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtCambioSunat;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}