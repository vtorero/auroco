using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace AurocoPublicidad.forms
{
    public partial class FrmOrden : Form
    {
        private const string apiUrl = "https://tudominio.com/api/tuendpoint";
        public FrmOrden()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRowCollection filas = dataGridOrden.Rows;

            filas.Add();

        }

        private void FrmOrden_Load(object sender, EventArgs e)
        {
          
        }

     
        private void inicioVigencia_Validated(object sender, EventArgs e)
        {

            pintaDias();



        }

        private string pintaDias()
        {
            var fecha = inicioVigencia.Value;
            L1.Text = generico.traduceDia(fecha.DayOfWeek.ToString());
            L2.Text = generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString());
            L3.Text = generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString());

            d1.HeaderText = fecha.Day.ToString();
            d2.HeaderText = fecha.AddDays(1).Day.ToString();
            d3.HeaderText = fecha.AddDays(2).Day.ToString();



            return fecha.ToString();

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string clientes = await  GetService("https://aprendeadistancia.online/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";

            //dataGridOrden.Columns.Insert(0, comboBoxColumn);

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Programa";
            comboBoxColumn.Name = "Programa";
            comboBoxColumn.DisplayMember = "RAZON_SOCIAL";
            comboBoxColumn.ValueMember = "C_CLIENTE";
            comboBoxColumn.DataSource= lstC;
            comboBoxColumn.AutoComplete = true;
            dataGridOrden.Columns.Insert(0,comboBoxColumn);


            // Obtén los datos del DataGridView
            List<Dictionary<string, object>> datos = ObtenerDatosDataGridView();
            //MessageBox.Show(datos + "");
            Console.Write(datos);
            


            // Envía los datos al API REST

            //await EnviarDatosAlApi(datos);
        }

        private List<Dictionary<string, object>> ObtenerDatosDataGridView()
        {
            List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();

            // Itera a través de las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridOrden.Rows)
            {
                // Verifica si la fila no es nueva y no es la fila de encabezado
                if (!fila.IsNewRow)
                {
                    Dictionary<string, object> filaDatos = new Dictionary<string, object>();

                    // Itera a través de las celdas en la fila
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        // Usa el nombre de la columna como clave y el valor de la celda como valor
                        filaDatos[dataGridOrden.Columns[celda.ColumnIndex].Name] = celda.Value;
                    }

                    // Agrega la fila de datos a la lista
                    datos.Add(filaDatos);
                }
            }

            return datos;
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }


        private async Task EnviarDatosAlApi(List<Dictionary<string, object>> datos)
        {
            using (HttpClient cliente = new HttpClient())
            {
                // Serializa los datos a formato JSON
                string datosJson = Newtonsoft.Json.JsonConvert.SerializeObject(datos);

                // Crea el contenido de la solicitud HTTP
                StringContent contenido = new StringContent(datosJson, Encoding.UTF8, "application/json");

                try
                {
                    // Realiza la solicitud POST al API REST
                    HttpResponseMessage respuesta = await cliente.PostAsync(apiUrl, contenido);

                    // Maneja la respuesta según sea necesario
                    if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Datos enviados correctamente al API REST.");
                    }
                    else
                    {
                        MessageBox.Show($"Error al enviar datos al API REST. Código de estado: {respuesta.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar datos al API REST: {ex.Message}");
                }
            }

        }

        private void dataGridOrden_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("cambio programa");
        }
    }
}



 

