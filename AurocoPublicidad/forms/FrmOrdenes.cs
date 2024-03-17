using AurocoPublicidad.models.request;
using Google.Protobuf.WellKnownTypes;
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
    public partial class FrmOrdenes : Form
    {
        public FrmOrdenes()
        {
            InitializeComponent();
        }

        private async void FrmOrdenes_Load(object sender, EventArgs e)
        {
            string respuesta = await GetService("https://aprendeadistancia.online/api-auroco/ordenes");
            List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(respuesta);
            //dgOrdenes.DataSource = lst;

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
                dgOrdenes.Rows[rowIndex].Cells["finicio"].Value = ord.INICIO_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["ffin"].Value = ord.FIN_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;


            }
        }


        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void dgOrdenes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int pos;
            pos = dgOrdenes.CurrentRow.Index;
            //MessageBox.Show(dgOrdenes[1, pos].Value.ToString());

            var idOrden = dgOrdenes[1, pos].Value.ToString();
            var idMedio = dgOrdenes[4, pos].Value.ToString();
            var idCliente = dgOrdenes[2, pos].Value.ToString();
            var idEjecutivo = dgOrdenes[6, pos].Value.ToString();
            var idContrato = dgOrdenes[10, pos].Value.ToString();



            FrmOrden frmOrden = new FrmOrden(idOrden,idMedio, idCliente, idContrato,idEjecutivo /*, otros datos si es necesario */);
            frmOrden.ShowDialog();

        }
    }
}
