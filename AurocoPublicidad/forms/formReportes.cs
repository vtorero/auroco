using AurocoPublicidad.models.request;
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class formReportes : Form
    {
        public formReportes()
        {
            InitializeComponent();
            LoadReportAsync();
        }

        private async void LoadReportAsync()
        {
            string apiUrl = "https://aprendeadistancia.online/api-auroco/ordenprint/AUROCO00105";
            var data = await GetService(apiUrl);

            // Asegúrate de que tu reporte y el modelo de datos (MyDataModel) coincidan
            ReportDocument reportDocument = new ReportDocument();
           Console.Write(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            //  reportDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "\\AurocoPublicidad\\reportes\\orden.rpt"));
            reportDocument.Load("orden.rpt");
            //reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\orden.rpt");

            // Asigna los datos al reporte
            ;
            reportDocument.SetDataSource(JsonConvert.DeserializeObject<List<Orden>>(data));

            // Muestra el reporte en el CrystalReportViewer
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }
        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }


}
