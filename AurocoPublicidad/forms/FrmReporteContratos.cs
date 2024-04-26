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
using System.Windows.Forms;
using AurocoPublicidad.models;
using System.Security.Policy;
using System.Web.Script.Serialization;


namespace AurocoPublicidad.forms
{
    public partial class FrmReporteContratos : Form
    {
        public FrmReporteContratos()
        {
            InitializeComponent();
        }

        private  void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string apiUrl = Global.servicio + "/api-auroco/reporte-contrato-cliente";
            
            Cliente cliente = new Cliente();

            string resultado = Send<Cliente>(apiUrl, cliente, "POST");


            ReportDocument reportDocument = new ReportDocument();
           

            reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\crLContratos.rpt");
            var datos = JsonConvert.DeserializeObject<List<Contrato>>(resultado);
            reportDocument.SetDataSource(datos);
            reportDocument.SetParameterValue("usuario", Global.sessionUsuario);
            FrmPreliminar childForm = new FrmPreliminar();
            childForm.Text = "Reporte de Contratos";
            childForm.crystalReportViewer1.ReportSource = reportDocument;

            childForm.crystalReportViewer1.Refresh();
            Cursor.Current = Cursors.Default;
            childForm.ShowDialog();
            


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
