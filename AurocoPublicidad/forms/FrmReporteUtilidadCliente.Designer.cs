﻿namespace AurocoPublicidad.forms
{
    partial class FrmReporteUtilidadCliente
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
            this.label3 = new System.Windows.Forms.Label();
            this.finVigencia = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnDolares = new System.Windows.Forms.RadioButton();
            this.rbnSoles = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.inicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "al:";
            // 
            // finVigencia
            // 
            this.finVigencia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.finVigencia.Location = new System.Drawing.Point(326, 66);
            this.finVigencia.Name = "finVigencia";
            this.finVigencia.Size = new System.Drawing.Size(118, 22);
            this.finVigencia.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "Moneda:";
            // 
            // rbnDolares
            // 
            this.rbnDolares.Checked = true;
            this.rbnDolares.Location = new System.Drawing.Point(109, 109);
            this.rbnDolares.Name = "rbnDolares";
            this.rbnDolares.Size = new System.Drawing.Size(69, 27);
            this.rbnDolares.TabIndex = 56;
            this.rbnDolares.TabStop = true;
            this.rbnDolares.Text = "Dolares";
            // 
            // rbnSoles
            // 
            this.rbnSoles.Location = new System.Drawing.Point(188, 106);
            this.rbnSoles.Name = "rbnSoles";
            this.rbnSoles.Size = new System.Drawing.Size(63, 32);
            this.rbnSoles.TabIndex = 57;
            this.rbnSoles.Text = "Soles";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 62;
            this.label9.Text = "Rango de fechas:";
            // 
            // inicioVigencia
            // 
            this.inicioVigencia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inicioVigencia.Location = new System.Drawing.Point(152, 66);
            this.inicioVigencia.Name = "inicioVigencia";
            this.inicioVigencia.Size = new System.Drawing.Size(118, 22);
            this.inicioVigencia.TabIndex = 61;
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(95, 21);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(352, 24);
            this.comboCliente.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Cliente:";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(315, 133);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 32);
            this.btnPrint.TabIndex = 58;
            this.btnPrint.Text = "&Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmReporteUtilidadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 190);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.finVigencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbnDolares);
            this.Controls.Add(this.rbnSoles);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.inicioVigencia);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmReporteUtilidadCliente";
            this.Text = "FrmReporteUtilidadCliente";
            this.Load += new System.EventHandler(this.FrmReporteUtilidadCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker finVigencia;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rbnDolares;
        internal System.Windows.Forms.RadioButton rbnSoles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker inicioVigencia;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
    }
}