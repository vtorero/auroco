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
            this.label20 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.LblNumero = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textObservaciones = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cMoneda = new System.Windows.Forms.TextBox();
            this.inicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // txtAgencia
            // 
            resources.ApplyResources(this.txtAgencia, "txtAgencia");
            this.txtAgencia.FormattingEnabled = true;
            this.txtAgencia.Name = "txtAgencia";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.Cyan;
            resources.ApplyResources(this.txtNumero, "txtNumero");
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            // 
            // LblNumero
            // 
            resources.ApplyResources(this.LblNumero, "LblNumero");
            this.LblNumero.Name = "LblNumero";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
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
            this.groupBox1.Controls.Add(this.txtIgv);
            this.groupBox1.Controls.Add(this.totalBruto);
            this.groupBox1.Controls.Add(this.txtRuc);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtAgencia);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.totalOrden);
            this.groupBox1.Controls.Add(this.LblNumero);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textObservaciones);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cMoneda);
            this.groupBox1.Controls.Add(this.inicioVigencia);
            this.groupBox1.Controls.Add(this.comboCliente);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtRuc
            // 
            resources.ApplyResources(this.txtRuc, "txtRuc");
            this.txtRuc.Name = "txtRuc";
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
            // inicioVigencia
            // 
            resources.ApplyResources(this.inicioVigencia, "inicioVigencia");
            this.inicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inicioVigencia.Name = "inicioVigencia";
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
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // FrmFacturar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Name = "FrmFacturar";
            this.Load += new System.EventHandler(this.FrmFacturar_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox txtAgencia;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label LblNumero;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox textObservaciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cMoneda;
        private System.Windows.Forms.DateTimePicker inicioVigencia;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtRuc;
    }
}