﻿using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FormFacturarOrdenes : Form
    {
        public FormFacturarOrdenes()
        {
            InitializeComponent();
        }

        private async void FormFacturarOrdenes_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedValue = "0";

            string medios = await GetService(Global.servicio + "/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "C_MEDIO";
            comboMedio.SelectedValue = "0";

            cargaOrdenes();
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void cargaOrdenes()
        {

            string respuesta = await GetService(Global.servicio + "/api-auroco/ordenes");
            List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(respuesta);
            //dgOrdenes.DataSource = lst;

            dgOrdenes.Rows.Clear();
            foreach (Ordenes ord in lst)
            {
                int rowIndex = dgOrdenes.Rows.Add();
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_ORDEN"].Value = ord.C_ORDEN;
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                dgOrdenes.Rows[rowIndex].Cells["Cliente"].Value = ord.RAZON_SOCIAL;
                dgOrdenes.Rows[rowIndex].Cells["C_MEDIO"].Value = ord.C_MEDIO;
                dgOrdenes.Rows[rowIndex].Cells["Medio"].Value = ord.NOMBRE;
                dgOrdenes.Rows[rowIndex].Cells["C_EJECUTIVO"].Value = ord.C_EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["EJECUTIVO"].Value = ord.EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["f_creacion"].Value = ord.F_CREACION;
                dgOrdenes.Rows[rowIndex].Cells["f_inicio"].Value = ord.INICIO_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["f_fin"].Value = ord.FIN_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                dgOrdenes.Rows[rowIndex].Cells["producto"].Value = ord.PRODUCTO;
                dgOrdenes.Rows[rowIndex].Cells["motivo"].Value = ord.MOTIVO;
                dgOrdenes.Rows[rowIndex].Cells["duracion"].Value = ord.DURACION;
                dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                dgOrdenes.Rows[rowIndex].Cells["revision"].Value = ord.REVISION;
                dgOrdenes.Rows[rowIndex].Cells["activa"].Value = ord.ACTIVA;
                dgOrdenes.Rows[rowIndex].Cells["agencia"].Value = ord.AGENCIA;


            }
            Cursor.Current = Cursors.Default;
        }
    }
}
