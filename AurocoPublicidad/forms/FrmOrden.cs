using AurocoPublicidad.models.request;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




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

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRowCollection filas = dataGridOrden.Rows;

            filas.Add();

        }

        private async void FrmOrden_Load(object sender, EventArgs e)
        {
            string clientes = await GetService("https://aprendeadistancia.online/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.Items.Add("Selecciona un Cliente");
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";

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
            string clientes = await GetService("https://aprendeadistancia.online/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);

            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";

            //dataGridOrden.Columns.Insert(0, comboBoxColumn);

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Programa";
            comboBoxColumn.Name = "Programa";
            comboBoxColumn.DisplayMember = "RAZON_SOCIAL";
            comboBoxColumn.ValueMember = "C_CLIENTE";
            comboBoxColumn.DataSource = lstC;
            comboBoxColumn.AutoComplete = true;
            dataGridOrden.Columns.Insert(0, comboBoxColumn);


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
            //MessageBox.Show("cambio programa");
        }

        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void comboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            string url = "https://aprendeadistancia.online/api-auroco/contratos_cliente";

            string cod_cliente = comboCliente.SelectedValue.ToString();
            string text_cliente = comboCliente.SelectedText.ToString();
            if (cod_cliente != "0" && cod_cliente != "AurocoPublicidad.models.request.Cliente")
            {
                Cliente cliente = new Cliente();
                cliente.C_CLIENTE = cod_cliente;
                string resultado = Send<Cliente>(url, cliente, "POST");
                Console.Write(resultado);
                //if (resultado.te) {                                              
                List<Contrato> lstC = JsonConvert.DeserializeObject<List<models.request.Contrato>>(resultado);
                comboContratos.DataSource = lstC;
                comboContratos.DisplayMember = "C_CONTRATO";
                comboContratos.ValueMember = "C_CONTRATO";

                //else
                //{
                //  MessageBox.Show("El cliente " + text_cliente + " no tiene contratos registrados");
                //}

            }


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

     

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private async void comboContratos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                HttpClient clienteHttp = new HttpClient();
                string codigo_contrato = comboContratos.SelectedValue.ToString();

                string urlApi = $"https://aprendeadistancia.online/api-auroco/index.php/contrato_detalle/{codigo_contrato}"; // URL de tu servicio API con parámetros   

                HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenido = await respuesta.Content.ReadAsStringAsync();



                    // Procesar el contenido recibido y mostrarlo en TextBoxes
                    // Supongamos que el contenido es un objeto JSON y queremos mostrar algunos de sus campos en TextBoxes
                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);
                    cInicioVigencia.Text = (data[0].INICIO_VIGENCIA);
                    cFinVigencia.Text = (data[0].FIN_VIGENCIA);


                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}



 

