using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using CrystalDecisions.CrystalReports.Engine;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FrmReporteUtilidadCliente : Form
    {
        public FrmReporteUtilidadCliente()
        {
            InitializeComponent();
        }

        private async void FrmReporteUtilidadCliente_Load(object sender, EventArgs e)
        {
            string clientes = await GetService(Global.servicio + "/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedValue = "0";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string apiUrl = Global.servicio + "/api-auroco/reporte-medios-cliente";

            Reporte reporte = new Reporte();
            reporte.C_CLIENTE = comboCliente.SelectedValue.ToString();
            reporte.FECHA_INICIO = inicioVigencia.Text.ToString();
            reporte.FECHA_FIN = finVigencia.Text.ToString();
            if (rbnDolares.Checked)
            {
                reporte.MONEDA = "Dolares";
            }
            if (rbnSoles.Checked)
            {
                reporte.MONEDA = "Soles";
            }


            // reporte.MONEDA = 

            string resultado = Send<Reporte>(apiUrl, reporte, "POST");


            ReportDocument reportDocument = new ReportDocument();


            reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\rpClientemedio.rpt");
            var datos = JsonConvert.DeserializeObject<List<ClienteMedio>>(resultado);
            reportDocument.SetDataSource(datos);
            /* reportDocument.SetParameterValue("usuario", Global.sessionUsuario);
             reportDocument.SetParameterValue("desde", inicioVigencia.Text.ToString());
             reportDocument.SetParameterValue("hasta", finVigencia.Text.ToString());*/
            FrmPreliminar childForm = new FrmPreliminar();
            childForm.Text = "Reporte de Medios";
            childForm.crystalReportViewer1.ReportSource = reportDocument;

            childForm.crystalReportViewer1.Refresh();
            Cursor.Current = Cursors.Default;
            childForm.ShowDialog();

        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();

        }
        public string Send<T>(string url, T ObjectRequest, string method = "POST")
        {
            string result = "";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializar el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(ObjectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //header
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8";
                request.Timeout = 30000;

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }


    }
}

