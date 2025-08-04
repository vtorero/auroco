namespace AurocoPublicidad.forms
{
    partial class frmFacturado
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
            this.C_RUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.comboMedio = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
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
            this.C_RUC,
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
            this.tipoCambio,
            this.agencia});
            this.dgOrdenes.Location = new System.Drawing.Point(-3, 74);
            this.dgOrdenes.MultiSelect = false;
            this.dgOrdenes.Name = "dgOrdenes";
            this.dgOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdenes.Size = new System.Drawing.Size(1241, 327);
            this.dgOrdenes.TabIndex = 101;
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
            // C_RUC
            // 
            this.C_RUC.HeaderText = "RUC";
            this.C_RUC.Name = "C_RUC";
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
            // tipoCambio
            // 
            this.tipoCambio.HeaderText = "Tipo Cambio";
            this.tipoCambio.Name = "tipoCambio";
            // 
            // agencia
            // 
            this.agencia.HeaderText = "Agencia";
            this.agencia.Name = "agencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(799, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 111;
            this.label6.Text = "Nro. Orden:";
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(96, 12);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(662, 25);
            this.comboCliente.TabIndex = 108;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(39, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 103;
            this.Label2.Text = "Cliente :";
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(876, 46);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(190, 20);
            this.txtOrden.TabIndex = 110;
            // 
            // comboMedio
            // 
            this.comboMedio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMedio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMedio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMedio.FormattingEnabled = true;
            this.comboMedio.Location = new System.Drawing.Point(96, 43);
            this.comboMedio.Name = "comboMedio";
            this.comboMedio.Size = new System.Drawing.Size(662, 25);
            this.comboMedio.TabIndex = 109;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(44, 46);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 16);
            this.Label4.TabIndex = 107;
            this.Label4.Text = "Medio:";
            // 
            // dtDesde
            // 
            this.dtDesde.Checked = false;
            this.dtDesde.CustomFormat = "dd/MM/yyyy";
            this.dtDesde.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesde.Location = new System.Drawing.Point(845, 13);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(91, 22);
            this.dtDesde.TabIndex = 105;
            this.dtDesde.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            // 
            // btnConsultar
            // 
            this.btnConsultar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConsultar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Image = global::AurocoPublicidad.Properties.Resources.buscar;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(1089, 10);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(101, 49);
            this.btnConsultar.TabIndex = 102;
            this.btnConsultar.Text = "Consultar";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(799, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 16);
            this.Label1.TabIndex = 104;
            this.Label1.Text = "Del :";
            // 
            // dtHasta
            // 
            this.dtHasta.Checked = false;
            this.dtHasta.CustomFormat = "dd/MM/yyyy";
            this.dtHasta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHasta.Location = new System.Drawing.Point(975, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(91, 22);
            this.dtHasta.TabIndex = 106;
            this.dtHasta.Value = new System.DateTime(2006, 9, 12, 17, 4, 13, 265);
            // 
            // frmFacturado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.comboMedio);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dgOrdenes);
            this.Name = "frmFacturado";
            this.Text = "frmFacturado";
            this.Load += new System.EventHandler(this.frmFacturado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrdenes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ORDEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_RUC;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCliente;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.ComboBox comboMedio;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtDesde;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtHasta;
    }
}