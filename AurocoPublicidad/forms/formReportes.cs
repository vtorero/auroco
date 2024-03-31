using AurocoPublicidad.models.request;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string numeroOrden;
        private string fechaInicial;
        public formReportes(string idOrden,string fechainicio)
        {
            InitializeComponent();
            numeroOrden= idOrden;
            fechaInicial= fechainicio;  
            LoadReportAsync();
        }

        private async void LoadReportAsync()
        {
            string apiUrl = $"https://aprendeadistancia.online/api-auroco/ordenprint/{numeroOrden}";
            var data = await GetService(apiUrl);

            // Asegúrate de que tu reporte y el modelo de datos (MyDataModel) coincidan
            ReportDocument reportDocument = new ReportDocument();
           //Console.Write(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            //  reportDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "\\AurocoPublicidad\\reportes\\orden.rpt"));
          //  reportDocument.Load("orden.rpt");
            reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\NcrOrdenes.rpt");

            // Asigna los datos al reporte
          
            var datos = JsonConvert.DeserializeObject<List<Ordenprint>>(data);
            reportDocument.SetDataSource(datos);
            
            var fecha = Convert.ToDateTime(fechaInicial);


            reportDocument.SetParameterValue("d1", generico.traduceDia(fecha.DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d2",generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d3", generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d4", generico.traduceDia(fecha.AddDays(3).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d5", generico.traduceDia(fecha.AddDays(4).DayOfWeek.ToString()));
            Console.Write(fecha.Day.ToString());
            reportDocument.SetParameterValue("n1", fecha.Day.ToString());
            reportDocument.SetParameterValue("n2", fecha.AddDays(1).Day.ToString());
            reportDocument.SetParameterValue("n3", fecha.AddDays(2).Day.ToString());
            reportDocument.SetParameterValue("n4", fecha.AddDays(3).Day.ToString());
            reportDocument.SetParameterValue("n5", fecha.AddDays(4).Day.ToString());


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
