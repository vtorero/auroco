namespace AurocoPublicidad.forms
{
    partial class FrmPrograma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.DateTimePicker();
            this.txtDia = new System.Windows.Forms.ComboBox();
            this.comboMedio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Código = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.DgProgramas = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fcreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.textoNombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProgramas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCosto);
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHorario);
            this.groupBox1.Controls.Add(this.txtDia);
            this.groupBox1.Controls.Add(this.comboMedio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.Código);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtPrograma);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 209);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 75;
            this.label4.Text = "Costo:";
            // 
            // txtCosto
            // 
            this.txtCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCosto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(108, 141);
            this.txtCosto.MaxLength = 100;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(69, 21);
            this.txtCosto.TabIndex = 7;
            this.txtCosto.Text = "0.00";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(394, 111);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 6;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 72;
            this.label1.Text = "Horario:";
            // 
            // txtHorario
            // 
            this.txtHorario.CustomFormat = "HH:mm:ss";
            this.txtHorario.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtHorario.Location = new System.Drawing.Point(278, 111);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.ShowUpDown = true;
            this.txtHorario.Size = new System.Drawing.Size(99, 20);
            this.txtHorario.TabIndex = 5;
            this.txtHorario.Value = new System.DateTime(2006, 8, 17, 0, 0, 0, 0);
            // 
            // txtDia
            // 
            this.txtDia.BackColor = System.Drawing.Color.White;
            this.txtDia.Items.AddRange(new object[] {
            "L-V",
            "S-D",
            "S",
            "D"});
            this.txtDia.Location = new System.Drawing.Point(107, 110);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(100, 21);
            this.txtDia.TabIndex = 4;
            // 
            // comboMedio
            // 
            this.comboMedio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMedio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMedio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMedio.FormattingEnabled = true;
            this.comboMedio.Location = new System.Drawing.Point(108, 46);
            this.comboMedio.Name = "comboMedio";
            this.comboMedio.Size = new System.Drawing.Size(285, 24);
            this.comboMedio.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Medio:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 64;
            this.label3.Text = "Dias:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(442, 159);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(101, 40);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "&Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Location = new System.Drawing.Point(549, 159);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 40);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Código
            // 
            this.Código.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Código.Location = new System.Drawing.Point(50, 22);
            this.Código.Name = "Código";
            this.Código.Size = new System.Drawing.Size(58, 16);
            this.Código.TabIndex = 55;
            this.Código.Text = "Código:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(35, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(61, 21);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(108, 19);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(104, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtPrograma
            // 
            this.txtPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrograma.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrograma.Location = new System.Drawing.Point(107, 79);
            this.txtPrograma.MaxLength = 100;
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(558, 21);
            this.txtPrograma.TabIndex = 3;
            // 
            // DgProgramas
            // 
            this.DgProgramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProgramas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre,
            this.canal,
            this.dias,
            this.horario,
            this.costo,
            this.fcreacion,
            this.usuario,
            this.estado});
            this.DgProgramas.Location = new System.Drawing.Point(22, 287);
            this.DgProgramas.Name = "DgProgramas";
            this.DgProgramas.ReadOnly = true;
            this.DgProgramas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProgramas.Size = new System.Drawing.Size(810, 156);
            this.DgProgramas.TabIndex = 10;
            this.DgProgramas.DoubleClick += new System.EventHandler(this.DgProgramas_DoubleClick);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 180;
            // 
            // canal
            // 
            this.canal.HeaderText = "Canal";
            this.canal.Name = "canal";
            this.canal.ReadOnly = true;
            // 
            // dias
            // 
            this.dias.HeaderText = "Dias";
            this.dias.Name = "dias";
            this.dias.ReadOnly = true;
            // 
            // horario
            // 
            this.horario.HeaderText = "Horario";
            this.horario.Name = "horario";
            this.horario.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // fcreacion
            // 
            this.fcreacion.HeaderText = "Fecha Creación";
            this.fcreacion.Name = "fcreacion";
            this.fcreacion.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Image = global::AurocoPublicidad.Properties.Resources.buscar;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(452, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 26);
            this.button3.TabIndex = 58;
            this.button3.Text = "Buscar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textoNombre
            // 
            this.textoNombre.Location = new System.Drawing.Point(78, 240);
            this.textoNombre.Name = "textoNombre";
            this.textoNombre.Size = new System.Drawing.Size(368, 20);
            this.textoNombre.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Nombre:";
            // 
            // FrmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 455);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textoNombre);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgProgramas);
            this.Name = "FrmPrograma";
            this.Text = "FrmPrograma";
            this.Load += new System.EventHandler(this.FrmPrograma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProgramas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Label Código;
        internal System.Windows.Forms.Label Label2;
        protected System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.DataGridView DgProgramas;
        internal System.Windows.Forms.ComboBox txtDia;
        private System.Windows.Forms.ComboBox comboMedio;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker txtHorario;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn canal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fcreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textoNombre;
        private System.Windows.Forms.Label label9;
    }
}