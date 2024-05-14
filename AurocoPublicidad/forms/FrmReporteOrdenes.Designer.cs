namespace AurocoPublicidad.forms
{
    partial class FrmReporteOrdenes
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
            this.rdDolares = new System.Windows.Forms.RadioButton();
            this.rdNuevosSoles = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtMedio = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtDescMedio = new System.Windows.Forms.TextBox();
            this.txtEjecutivo = new System.Windows.Forms.TextBox();
            this.cEjecutivo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cCliente = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdDolares
            // 
            this.rdDolares.AutoSize = true;
            this.rdDolares.Location = new System.Drawing.Point(224, 151);
            this.rdDolares.Name = "rdDolares";
            this.rdDolares.Size = new System.Drawing.Size(61, 17);
            this.rdDolares.TabIndex = 93;
            this.rdDolares.TabStop = true;
            this.rdDolares.Text = "Dólares";
            this.rdDolares.UseVisualStyleBackColor = true;
            // 
            // rdNuevosSoles
            // 
            this.rdNuevosSoles.AutoSize = true;
            this.rdNuevosSoles.Checked = true;
            this.rdNuevosSoles.Location = new System.Drawing.Point(100, 149);
            this.rdNuevosSoles.Name = "rdNuevosSoles";
            this.rdNuevosSoles.Size = new System.Drawing.Size(91, 17);
            this.rdNuevosSoles.TabIndex = 92;
            this.rdNuevosSoles.TabStop = true;
            this.rdNuevosSoles.Text = "Nuevos Soles";
            this.rdNuevosSoles.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(13, 151);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(49, 13);
            this.Label3.TabIndex = 91;
            this.Label3.Text = "Moneda:";
            // 
            // TxtMedio
            // 
            this.TxtMedio.Location = new System.Drawing.Point(96, 83);
            this.TxtMedio.Name = "TxtMedio";
            this.TxtMedio.Size = new System.Drawing.Size(72, 20);
            this.TxtMedio.TabIndex = 89;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(24, 86);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 13);
            this.Label4.TabIndex = 88;
            this.Label4.Text = "Medio:";
            // 
            // TxtDescMedio
            // 
            this.TxtDescMedio.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TxtDescMedio.Location = new System.Drawing.Point(174, 83);
            this.TxtDescMedio.Name = "TxtDescMedio";
            this.TxtDescMedio.ReadOnly = true;
            this.TxtDescMedio.Size = new System.Drawing.Size(288, 20);
            this.TxtDescMedio.TabIndex = 90;
            // 
            // txtEjecutivo
            // 
            this.txtEjecutivo.Location = new System.Drawing.Point(174, 54);
            this.txtEjecutivo.Name = "txtEjecutivo";
            this.txtEjecutivo.ReadOnly = true;
            this.txtEjecutivo.Size = new System.Drawing.Size(288, 20);
            this.txtEjecutivo.TabIndex = 84;
            // 
            // cEjecutivo
            // 
            this.cEjecutivo.Location = new System.Drawing.Point(96, 54);
            this.cEjecutivo.Name = "cEjecutivo";
            this.cEjecutivo.Size = new System.Drawing.Size(72, 20);
            this.cEjecutivo.TabIndex = 83;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 54);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 13);
            this.Label1.TabIndex = 82;
            this.Label1.Text = "Ejecutivo:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rdDolares);
            this.GroupBox1.Controls.Add(this.rdNuevosSoles);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.TxtMedio);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.TxtDescMedio);
            this.GroupBox1.Controls.Add(this.txtEjecutivo);
            this.GroupBox1.Controls.Add(this.cEjecutivo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btn_cerrar);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.dtFechaFinal);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.dtFechaInicio);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtCliente);
            this.GroupBox1.Controls.Add(this.cCliente);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(496, 248);
            this.GroupBox1.TabIndex = 70;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos Reportes";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(401, 179);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(80, 24);
            this.btn_cerrar.TabIndex = 81;
            this.btn_cerrar.Text = "&Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(316, 179);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(80, 24);
            this.Button1.TabIndex = 80;
            this.Button1.Text = "&Imprimir";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinal.Location = new System.Drawing.Point(292, 113);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(104, 20);
            this.dtFechaFinal.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(206, 113);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 16);
            this.Label2.TabIndex = 76;
            this.Label2.Text = "Fecha Hasta :";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(96, 113);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(104, 20);
            this.dtFechaInicio.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(14, 113);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 16);
            this.Label6.TabIndex = 74;
            this.Label6.Text = "Fecha Desde :";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(174, 24);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(288, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // cCliente
            // 
            this.cCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cCliente.Location = new System.Drawing.Point(96, 24);
            this.cCliente.MaxLength = 10;
            this.cCliente.Name = "cCliente";
            this.cCliente.Size = new System.Drawing.Size(72, 20);
            this.cCliente.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(16, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 16);
            this.Label5.TabIndex = 71;
            this.Label5.Text = "Cliente:";
            // 
            // FrmReporteOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 274);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmReporteOrdenes";
            this.ShowIcon = false;
            this.Text = "FrmReporteOrdenes";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton rdDolares;
        internal System.Windows.Forms.RadioButton rdNuevosSoles;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtMedio;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TxtDescMedio;
        internal System.Windows.Forms.TextBox txtEjecutivo;
        internal System.Windows.Forms.TextBox cEjecutivo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btn_cerrar;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DateTimePicker dtFechaFinal;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker dtFechaInicio;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtCliente;
        internal System.Windows.Forms.TextBox cCliente;
        internal System.Windows.Forms.Label Label5;
    }
}