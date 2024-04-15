namespace AurocoPublicidad.forms
{
    partial class FrmMedios
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.Datos = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(87, 19);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(104, 22);
            this.txtCodigo.TabIndex = 39;
            // 
            // txtTipo
            // 
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(87, 47);
            this.txtTipo.MaxLength = 180;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(332, 22);
            this.txtTipo.TabIndex = 41;
            // 
            // txtRazon
            // 
            this.txtRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazon.Location = new System.Drawing.Point(87, 75);
            this.txtRazon.MaxLength = 100;
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(582, 22);
            this.txtRazon.TabIndex = 40;
            // 
            // Datos
            // 
            this.Datos.Controls.Add(this.label3);
            this.Datos.Controls.Add(this.label1);
            this.Datos.Controls.Add(this.label8);
            this.Datos.Controls.Add(this.label2);
            this.Datos.Controls.Add(this.button2);
            this.Datos.Controls.Add(this.btnGuardar);
            this.Datos.Controls.Add(this.comboBox1);
            this.Datos.Controls.Add(this.txtCodigo);
            this.Datos.Controls.Add(this.txtRazon);
            this.Datos.Controls.Add(this.txtTipo);
            this.Datos.Location = new System.Drawing.Point(12, 12);
            this.Datos.Name = "Datos";
            this.Datos.Size = new System.Drawing.Size(713, 198);
            this.Datos.TabIndex = 42;
            this.Datos.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Televisión",
            "Radio"});
            this.comboBox1.Location = new System.Drawing.Point(87, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 42;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(713, 170);
            this.dataGridView1.TabIndex = 43;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(446, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 40);
            this.button2.TabIndex = 44;
            this.button2.Text = "Resetear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Location = new System.Drawing.Point(553, 152);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 40);
            this.btnGuardar.TabIndex = 43;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Descripción:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Tipo:";
            // 
            // FrmMedios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 424);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Datos);
            this.Name = "FrmMedios";
            this.Text = "FrmMedios";
            this.Datos.ResumeLayout(false);
            this.Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.TextBox txtTipo;
        internal System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.GroupBox Datos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}