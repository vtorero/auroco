using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;





namespace AurocoPublicidad.forms
{
    public partial class FrmOrden : Form
    {
        private const string apiUrl = "https://aprendeadistancia.online/api-auroco/orden";
        public FrmOrden()
        {
            InitializeComponent();
            dataGridOrden.EditingControlShowing += dataGridOrden_EditingControlShowing;
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

            string medios = await GetService("https://aprendeadistancia.online/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.Items.Add("Selecciona un medio");
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "NOMBRE";

            string ejecutivos = await GetService("https://aprendeadistancia.online/api-auroco/tabla/ORD_EJECUTIVOS/NOMBRES");
            List<models.request.Ejecutivo> lstE = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(ejecutivos);
            cmbEjecutivo.Items.Add("Selecciona un medio");
            cmbEjecutivo.DataSource = lstE;
            cmbEjecutivo.DisplayMember = "NOMBRES";
            cmbEjecutivo.ValueMember = "C_EJECUTIVO";


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

        private  void btnGuardar_Click(object sender, EventArgs e)

        {
            // Obtén los datos del DataGridView
            List<Dictionary<string, object>> datos = ObtenerDatosDataGridView(dataGridOrden);
            //MessageBox.Show(datos + "");
            Console.Write(datos);
            // Envía los datos al API REST

            Orden orden = new Orden();
            orden.C_CLIENTE = comboCliente.SelectedValue.ToString();
            orden.C_CONTRATO = comboContratos.SelectedValue.ToString();
            orden.C_MEDIO = comboMedio.SelectedValue.ToString();
            orden.IGV = comboIgv.SelectedItem.ToString();
            orden.CONSUMIR_EN = comboCambio.SelectedItem.ToString();
            orden.FECHA_INICIO = inicioVigencia.Value.ToString();
            orden.FECHA_FIN= finVigencia.Value.ToString();  
            orden.C_EJECUTIVO= cmbEjecutivo.SelectedValue.ToString();
            orden.PRODUCTO = textProducto.Text;
            orden.MOTIVO = textMotivo.Text;
            orden.DURACION = textDuracion.Text;
            orden.OBSERVACIONES = textObservaciones.Text;
            orden.orden = datos;
            orden.C_USUARIO = Global.sessionUsuario.ToString();

            string resultado = Send<Orden>(apiUrl, orden, "POST");

            JObject jObject = JObject.Parse(resultado);
            JToken objeto = jObject["status"];
            string status = (string)objeto;
            Console.Write(resultado);

            if (status == "True")
            {
                MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 // await EnviarDatosAlApi(datos);

            }
            else {
                MessageBox.Show((string)jObject["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private List<Dictionary<string, object>> ObtenerDatosDataGridView(DataGridView dgv)
        {
        List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();

            // Itera a través de las filas del DataGridView
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                // Verifica si la fila no es nueva y no es la fila de encabezado
                if (!fila.IsNewRow)
                {
                    Dictionary<string, object> filaDatos = new Dictionary<string, object>();

                    // Itera a través de las celdas en la fila
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        // Usa el nombre de la columna como clave y el valor de la celda como valor
                        filaDatos[dgv.Columns[celda.ColumnIndex].Name] = celda.Value;
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
                Orden orden = new Orden();
                orden.C_MEDIO = comboMedio.SelectedValue.ToString();
                orden.C_CONTRATO= comboContratos.SelectedValue.ToString();
                orden.orden = datos;
             


                string datosJson = Newtonsoft.Json.JsonConvert.SerializeObject(orden);

                // Crea el contenido de la solicitud HTTP
                StringContent resultado = new StringContent(Send(apiUrl, orden, "POST"));

                //StringContent contenido = new StringContent(datosJson, Encoding.UTF8, "application/json");

                try
                {
                    // Realiza la solicitud POST al API REST
                  //  HttpResponseMessage respuesta = await cliente.PostAsync(apiUrl, contenido);
                    
                    
                   // JObject jObject = JObject.Parse(resultado);

                    // Maneja la respuesta según sea necesario
                  /*  if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Datos enviados correctamente al API REST.");
                    }
                    else
                    {
                        MessageBox.Show($"Error al enviar datos al API REST. Código de estado: {respuesta.StatusCode}");
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar datos al API REST: {ex.Message}");
                }
            }

        }



        private void comboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            comboContratos.DataSource = null;
            comboContratos.Items.Clear();

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





        private async void comboContratos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cInicioVigencia.Text = null;
                cFinVigencia.Text = null;
                cNumeroFisico.Text = null;
                cTipoCambio.Text = null;
                cSaldo.Text = null;

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
                    cMoneda.Text = data[0].C_MONEDA;
                    cTipoCambio.Text = data[0].TIPO_CAMBIO;
                    cNumeroFisico.Text = data[0].NRO_FISICO;
                    cSaldo.Text = data[0].saldo_actual;



                }


            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void comboMedio_DropDownClosed(object sender, EventArgs e)
        {
            cargaprograma();

        }

        public async void cargaprograma()
        {
            if (dataGridOrden.Columns.Contains("programa"))
            {
                dataGridOrden.Columns.Remove("programa");

            }



            string canal = comboMedio.SelectedValue.ToString();

            string programas = await GetService($"https://aprendeadistancia.online/api-auroco/medio_programas/{canal}");
            List<models.request.Programa> lstC = JsonConvert.DeserializeObject<List<models.request.Programa>>(programas);

            // comboCliente.DisplayMember = "PROGRAMA";
            //comboCliente.ValueMember = "PROGRAMA";

            //dataGridOrden.Columns.Insert(0, comboBoxColumn);

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Programa";
            comboBoxColumn.Width = 210;
            comboBoxColumn.Name = "Programa";
            comboBoxColumn.DisplayMember = "PROGRAMA";
            comboBoxColumn.ValueMember = "ID";
            comboBoxColumn.DataSource = lstC;
            comboBoxColumn.AutoComplete = true;
            dataGridOrden.Columns.Insert(0, comboBoxColumn);


            // Obtén los datos del DataGridView
            List<Dictionary<string, object>> datos = ObtenerDatosDataGridView(dataGridOrden);
            //MessageBox.Show(datos + "");
            Console.Write(datos);
        }

        private void dataGridOrden_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Verificar si la celda actual es la que contiene un ComboBox
            if (dataGridOrden.CurrentCell is DataGridViewComboBoxCell)
            {
                // Obtener el ComboBox
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    // Suscribirse al evento de selección del ComboBox
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }

        private async void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ComboBox que disparó el evento
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                // Obtener el valor seleccionado

                if (comboBox.SelectedValue != null)
                {
                    string selectedValue = comboBox.SelectedValue.ToString();
                
                    

                    HttpClient clienteHttp = new HttpClient();


                    string urlApi = $"https://aprendeadistancia.online/api-auroco/programa/{selectedValue}"; // URL de tu servicio API con parámetros   

                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();

                        int currentRow = dataGridOrden.CurrentCell.RowIndex;
              //          int currentColumn = dataGridOrden.CurrentCell.ColumnIndex;

                        // Procesar el contenido recibido y mostrarlo en TextBoxes
                        // Supongamos que el contenido es un objeto JSON y queremos mostrar algunos de sus campos en TextBoxes
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);
                       
                        
                            foreach (var ansValue in data)
                            {
                            dataGridOrden.Rows[currentRow].Cells[1].Value = Convert.ToString(ansValue["DIAS"]) +" "+Convert.ToString(ansValue["PERIODO"]);
                            dataGridOrden.Rows[currentRow].Cells[2].Value = "0.00";
                            }
                        


                        //if (data.value.HasValues) { 
                        //dataGridOrden.Rows[currentRow].Cells[1].Value = data[0].PERIODO;
                        //dataGridOrden.Rows[currentRow].Cells[2].Value = data[0].DIAS;
                        }

                    }

                }

                // Obtener la fila y columna actual


                // Hacer algo con el valor seleccionado, como mostrarlo en un MessageBox
                //MessageBox.Show("Valor seleccionado en la fila " + currentRow.ToString() + ", columna " + currentColumn.ToString() + ": " + selectedValue);
            }
        }
    }







 

