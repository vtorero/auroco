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
            this.Label4 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.comboMedio = new System.Windows.Forms.ComboBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_ORDEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_MEDIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_EJECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EJECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ffin = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).BeginInit();
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
            this.finicio,
            this.ffin,
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
            this.dgOrdenes.Location = new System.Drawing.Point(30, 135);
            this.dgOrdenes.MultiSelect = false;
            this.dgOrdenes.Name = "dgOrdenes";
            this.dgOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdenes.Size = new System.Drawing.Size(1174, 220);
            this.dgOrdenes.TabIndex = 0;
            this.dgOrdenes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgOrdenes_CellFormatting);
            this.dgOrdenes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgOrdenes_MouseDoubleClick);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(27, 61);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 16);
            this.Label4.TabIndex = 90;
            this.Label4.Text = "Medio:";
            // 
            // dtHasta
            // 
            this.dtHasta.Checked = false;
            this.dtHasta.CustomFormat = "dd/MM/yyyy";
            this.dtHasta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHasta.Location = new System.Drawing.Point(230, 93);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(112, 22);
            this.dtHasta.TabIndex = 85;
            this.dtHasta.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(206, 93);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(24, 16);
            this.Label3.TabIndex = 84;
            this.Label3.Text = "Al :";
            // 
            // dtDesde
            // 
            this.dtDesde.Checked = false;
            this.dtDesde.CustomFormat = "dd/MM/yyyy";
            this.dtDesde.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesde.Location = new System.Drawing.Point(89, 93);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(98, 22);
            this.dtDesde.TabIndex = 83;
            this.dtDesde.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(31, 93);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 16);
            this.Label1.TabIndex = 82;
            this.Label1.Text = "Del :";
            // 
            // btnGenerar
            // 
            this.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGenerar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(361, 93);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(97, 25);
            this.btnGenerar.TabIndex = 80;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 81;
            this.Label2.Text = "Cliente :";
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(89, 19);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(299, 25);
            this.comboCliente.TabIndex = 91;
            // 
            // comboMedio
            // 
            this.comboMedio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMedio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMedio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMedio.FormattingEnabled = true;
            this.comboMedio.Location = new System.Drawing.Point(89, 54);
            this.comboMedio.Name = "comboMedio";
            this.comboMedio.Size = new System.Drawing.Size(299, 25);
            this.comboMedio.TabIndex = 92;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(1019, 381);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(81, 24);
            this.Button2.TabIndex = 95;
            this.Button2.Text = "A&nular Orden";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(1106, 381);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(96, 24);
            this.btnEditar.TabIndex = 94;
            this.btnEditar.Text = "&Modificar Orden";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(931, 381);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 24);
            this.btnNuevo.TabIndex = 93;
            this.btnNuevo.Text = "N&ueva Orden";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            // finicio
            // 
            this.finicio.HeaderText = "Fecha inicio";
            this.finicio.Name = "finicio";
            // 
            // ffin
            // 
            this.ffin.HeaderText = "Fecha Fin";
            this.ffin.Name = "ffin";
            // 
            // C_CONTRATO
            // 
            this.C_CONTRATO.HeaderText = "C_CONTRATO";
            this.C_CONTRATO.Name = "C_CONTRATO";
            this.C_CONTRATO.Visible = false;
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
            // FrmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 440);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.comboMedio);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dgOrdenes);
            this.Name = "FrmOrdenes";
            this.Text = "Listado de Ordenes";
            this.Load += new System.EventHandler(this.FrmOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).EndInit();
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
        internal System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.ComboBox comboMedio;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnEditar;
        internal System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ORDEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_MEDIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medio;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_EJECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EJECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn finicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ffin;
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
    }
}