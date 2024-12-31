namespace AurocoPublicidad.forms
{
    partial class FrmOrdenes
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
            this.dgOrdenes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_ORDEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_MEDIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_EJECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EJECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.comboMedio = new System.Windows.Forms.ComboBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgOrdenes
            // 
            this.dgOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.C_ORDEN,
            this.C_CLIENTE,
            this.Cliente,
            this.C_MEDIO,
            this.Medio,
            this.C_EJECUTIVO,
            this.EJECUTIVO,
            this.f_creacion,
            this.f_inicio,
            this.f_fin,
            this.C_CONTRATO,
            this.moneda,
            this.total,
            this.producto,
            this.motivo,
            this.duracion,
            this.observaciones,
            this.revision,
            this.activa,
            this.agencia});
            this.dgOrdenes.Location = new System.Drawing.Point(12, 115);
            this.dgOrdenes.MultiSelect = false;
            this.dgOrdenes.Name = "dgOrdenes";
            this.dgOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdenes.Size = new System.Drawing.Size(1174, 327);
            this.dgOrdenes.TabIndex = 0;
            this.dgOrdenes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgOrdenes_CellFormatting);
            this.dgOrdenes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgOrdenes_MouseDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // C_ORDEN
            // 
            this.C_ORDEN.HeaderText = "Orden";
            this.C_ORDEN.Name = "C_ORDEN";
            // 
            // C_CLIENTE
            // 
            this.C_CLIENTE.HeaderText = "C_CLIENTE";
            this.C_CLIENTE.Name = "C_CLIENTE";
            this.C_CLIENTE.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // C_MEDIO
            // 
            this.C_MEDIO.HeaderText = "C_MEDIO";
            this.C_MEDIO.Name = "C_MEDIO";
            this.C_MEDIO.Visible = false;
            // 
            // Medio
            // 
            this.Medio.HeaderText = "Medio";
            this.Medio.Name = "Medio";
            // 
            // C_EJECUTIVO
            // 
            this.C_EJECUTIVO.HeaderText = "C_EJECUTIVO";
            this.C_EJECUTIVO.Name = "C_EJECUTIVO";
            this.C_EJECUTIVO.Visible = false;
            // 
            // EJECUTIVO
            // 
            this.EJECUTIVO.HeaderText = "Ejecutivo";
            this.EJECUTIVO.Name = "EJECUTIVO";
            // 
            // f_creacion
            // 
            this.f_creacion.HeaderText = "Fecha";
            this.f_creacion.Name = "f_creacion";
            // 
            // f_inicio
            // 
            this.f_inicio.HeaderText = "fechainicio";
            this.f_inicio.Name = "f_inicio";
            this.f_inicio.Visible = false;
            // 
            // f_fin
            // 
            this.f_fin.HeaderText = "fechafin";
            this.f_fin.Name = "f_fin";
            this.f_fin.Visible = false;
            // 
            // C_CONTRATO
            // 
            this.C_CONTRATO.HeaderText = "Contrato";
            this.C_CONTRATO.Name = "C_CONTRATO";
            // 
            // moneda
            // 
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            // 
            // motivo
            // 
            this.motivo.HeaderText = "Motivo";
            this.motivo.Name = "motivo";
            // 
            // duracion
            // 
            this.duracion.HeaderText = "Duración";
            this.duracion.Name = "duracion";
            // 
            // observaciones
            // 
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            // 
            // revision
            // 
            this.revision.HeaderText = "Revisión";
            this.revision.Name = "revision";
            // 
            // activa
            // 
            this.activa.HeaderText = "Activa";
            this.activa.Name = "activa";
            // 
            // agencia
            // 
            this.agencia.HeaderText = "AGENCIA";
            this.agencia.Name = "agencia";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(37, 55);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 16);
            this.Label4.TabIndex = 90;
            this.Label4.Text = "Medio:";
            this.Label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // dtHasta
            // 
            this.dtHasta.Checked = false;
            this.dtHasta.CustomFormat = "dd/MM/yyyy";
            this.dtHasta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHasta.Location = new System.Drawing.Point(621, 21);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(91, 22);
            this.dtHasta.TabIndex = 85;
            this.dtHasta.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(589, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(26, 16);
            this.Label3.TabIndex = 84;
            this.Label3.Text = "al:";
            // 
            // dtDesde
            // 
            this.dtDesde.Checked = false;
            this.dtDesde.CustomFormat = "dd/MM/yyyy";
            this.dtDesde.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesde.Location = new System.Drawing.Point(491, 22);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(91, 22);
            this.dtDesde.TabIndex = 83;
            this.dtDesde.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(445, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 16);
            this.Label1.TabIndex = 82;
            this.Label1.Text = "Del :";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConsultar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.Location = new System.Drawing.Point(785, 21);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(125, 49);
            this.btnConsultar.TabIndex = 80;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(32, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 81;
            this.Label2.Text = "Cliente :";
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(89, 21);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(294, 25);
            this.comboCliente.TabIndex = 91;
            this.comboCliente.SelectedIndexChanged += new System.EventHandler(this.comboCliente_SelectedIndexChanged);
            // 
            // comboMedio
            // 
            this.comboMedio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMedio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMedio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMedio.FormattingEnabled = true;
            this.comboMedio.Location = new System.Drawing.Point(89, 52);
            this.comboMedio.Name = "comboMedio";
            this.comboMedio.Size = new System.Drawing.Size(294, 25);
            this.comboMedio.TabIndex = 92;
            this.comboMedio.SelectedIndexChanged += new System.EventHandler(this.comboMedio_SelectedIndexChanged);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(1019, 460);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(81, 30);
            this.Button2.TabIndex = 95;
            this.Button2.Text = "A&nular Orden";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(1106, 460);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(96, 30);
            this.btnEditar.TabIndex = 94;
            this.btnEditar.Text = "&Modificar Orden";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(931, 460);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnNuevo.TabIndex = 93;
            this.btnNuevo.Text = "N&ueva Orden";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::AurocoPublicidad.Properties.Resources.refresh_arrow_1546;
            this.btnRefresh.Location = new System.Drawing.Point(1151, 74);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 35);
            this.btnRefresh.TabIndex = 96;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(522, 55);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(190, 20);
            this.txtOrden.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Nro. Orden:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboCliente);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.txtOrden);
            this.groupBox1.Controls.Add(this.comboMedio);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.dtDesde);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.dtHasta);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 107);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(445, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 98;
            this.label6.Text = "Nro. Orden:";
            // 
            // FrmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgOrdenes);
            this.Name = "FrmOrdenes";
            this.Text = "Listado de Ordenes";
            this.Load += new System.EventHandler(this.FrmOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrdenes;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtHasta;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtDesde;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.ComboBox comboMedio;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnEditar;
        internal System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ORDEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_MEDIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medio;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_EJECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EJECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn activa;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}