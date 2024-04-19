using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
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
using static System.Net.WebRequestMethods;

namespace AurocoPublicidad.forms
{
    public partial class formReportes : Form
    {
        private string numeroOrden;
        private string fechaInicial;
        private string valorAgencia;
        public formReportes(string idOrden,string fechainicio,string agencia)
        {
            InitializeComponent();
            numeroOrden= idOrden;
            fechaInicial= fechainicio;  
            valorAgencia= agencia;  
            LoadReportAsync();
        }

        private async void LoadReportAsync()
        {
            string apiUrl = Global.servicio + "/api-auroco/ordenprint/" + numeroOrden;
            var data = await GetService(apiUrl);

            // Asegúrate de que tu reporte y el modelo de datos (MyDataModel) coincidan
            ReportDocument reportDocument = new ReportDocument();
            //Console.Write(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            //  reportDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "\\AurocoPublicidad\\reportes\\orden.rpt"));
            //  reportDocument.Load("orden.rpt");
            // reportDocument.Load("d:\\auroco\\AurocoPublicidad\\reportes\\NcrOrdenes.rpt");
            if (valorAgencia == "AUROCO") { 
            reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\OrdenesAu.rpt");
             //reportDocument.Load("d:\\auroco\\AurocoPublicidad\\reportes\\OrdenesAu.rpt");
            }
            if (valorAgencia == "OPTIMIZA") {
               reportDocument.Load("C:\\Users\\vtore\\source\\repos\\AurocoPublicidad\\AurocoPublicidad\\reportes\\OrdenesOpt.rpt");
           //     reportDocument.Load("d:\\auroco\\AurocoPublicidad\\reportes\\OrdenesOpt.rpt");
            }
            
                // Asigna los datos al reporte

                var datos = JsonConvert.DeserializeObject<List<Ordenprint>>(data);
            reportDocument.SetDataSource(datos);
            
            var fecha = Convert.ToDateTime(fechaInicial);


            reportDocument.SetParameterValue("d1", generico.traduceDia(fecha.DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d2",generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d3", generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d4", generico.traduceDia(fecha.AddDays(3).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d5", generico.traduceDia(fecha.AddDays(4).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d6", generico.traduceDia(fecha.AddDays(5).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d7", generico.traduceDia(fecha.AddDays(6).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d8", generico.traduceDia(fecha.AddDays(7).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d9", generico.traduceDia(fecha.AddDays(8).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d10", generico.traduceDia(fecha.AddDays(9).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d11", generico.traduceDia(fecha.AddDays(10).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d12", generico.traduceDia(fecha.AddDays(11).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d13", generico.traduceDia(fecha.AddDays(12).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d14", generico.traduceDia(fecha.AddDays(13).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d15", generico.traduceDia(fecha.AddDays(14).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d16", generico.traduceDia(fecha.AddDays(15).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d17", generico.traduceDia(fecha.AddDays(16).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d18", generico.traduceDia(fecha.AddDays(17).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d19", generico.traduceDia(fecha.AddDays(18).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d20", generico.traduceDia(fecha.AddDays(19).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d21", generico.traduceDia(fecha.AddDays(20).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d22", generico.traduceDia(fecha.AddDays(21).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d23", generico.traduceDia(fecha.AddDays(22).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d24", generico.traduceDia(fecha.AddDays(23).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d25", generico.traduceDia(fecha.AddDays(24).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d26", generico.traduceDia(fecha.AddDays(25).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d27", generico.traduceDia(fecha.AddDays(26).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d28", generico.traduceDia(fecha.AddDays(27).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d29", generico.traduceDia(fecha.AddDays(28).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d30", generico.traduceDia(fecha.AddDays(29).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("d31", generico.traduceDia(fecha.AddDays(30).DayOfWeek.ToString()));
            reportDocument.SetParameterValue("n1", fecha.Day.ToString());
            reportDocument.SetParameterValue("n2", fecha.AddDays(1).Day.ToString());
            reportDocument.SetParameterValue("n3", fecha.AddDays(2).Day.ToString());
            reportDocument.SetParameterValue("n4", fecha.AddDays(3).Day.ToString());
            reportDocument.SetParameterValue("n5", fecha.AddDays(4).Day.ToString());
            reportDocument.SetParameterValue("n6", fecha.AddDays(5).Day.ToString());
            reportDocument.SetParameterValue("n7", fecha.AddDays(6).Day.ToString());
            reportDocument.SetParameterValue("n8", fecha.AddDays(7).Day.ToString());
            reportDocument.SetParameterValue("n9", fecha.AddDays(8).Day.ToString());
            reportDocument.SetParameterValue("n10", fecha.AddDays(9).Day.ToString());
            reportDocument.SetParameterValue("n11", fecha.AddDays(10).Day.ToString());
            reportDocument.SetParameterValue("n12", fecha.AddDays(11).Day.ToString());
            reportDocument.SetParameterValue("n13", fecha.AddDays(12).Day.ToString());
            reportDocument.SetParameterValue("n14", fecha.AddDays(13).Day.ToString());
            reportDocument.SetParameterValue("n15", fecha.AddDays(14).Day.ToString());
            reportDocument.SetParameterValue("n16", fecha.AddDays(15).Day.ToString());
            reportDocument.SetParameterValue("n17", fecha.AddDays(16).Day.ToString());
            reportDocument.SetParameterValue("n18", fecha.AddDays(17).Day.ToString());
            reportDocument.SetParameterValue("n19", fecha.AddDays(18).Day.ToString());
            reportDocument.SetParameterValue("n20", fecha.AddDays(19).Day.ToString());
            reportDocument.SetParameterValue("n21", fecha.AddDays(20).Day.ToString());
            reportDocument.SetParameterValue("n22", fecha.AddDays(21).Day.ToString());
            reportDocument.SetParameterValue("n23", fecha.AddDays(22).Day.ToString());
            reportDocument.SetParameterValue("n24", fecha.AddDays(23).Day.ToString());
            reportDocument.SetParameterValue("n25", fecha.AddDays(24).Day.ToString());
            reportDocument.SetParameterValue("n26", fecha.AddDays(25).Day.ToString());
            reportDocument.SetParameterValue("n27", fecha.AddDays(26).Day.ToString());
            reportDocument.SetParameterValue("n28", fecha.AddDays(27).Day.ToString());
            reportDocument.SetParameterValue("n29", fecha.AddDays(28).Day.ToString());
            reportDocument.SetParameterValue("n30", fecha.AddDays(29).Day.ToString());
            reportDocument.SetParameterValue("n31", fecha.AddDays(30).Day.ToString());


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
