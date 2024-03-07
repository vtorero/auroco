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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;





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
            string clientes = await GetService("https://aprendeadistancia.online/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedIndex = 0;

            string medios = await GetService("https://aprendeadistancia.online/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "C_MEDIO";

            string ejecutivos = await GetService("https://aprendeadistancia.online/api-auroco/tabla/ORD_EJECUTIVOS/NOMBRES");
            List<models.request.Ejecutivo> lstE = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(ejecutivos);
            cmbEjecutivo.DataSource = lstE;
            cmbEjecutivo.DisplayMember = "NOMBRES";
            cmbEjecutivo.ValueMember = "C_EJECUTIVO";

            string monedas = await GetService("https://aprendeadistancia.online/api-auroco/monedas");
            List<models.request.Monedas> lstMo = JsonConvert.DeserializeObject<List<models.request.Monedas>>(monedas);
            comboCambio.DataSource = lstMo;
            comboCambio.DisplayMember = "NOMBRE";
            comboCambio.ValueMember = "VALOR";

            comboIgv.Items.Add(new ListItem("0", "Seleccionar"));
            comboIgv.Items.Add(new ListItem("Si", "Si"));
            comboIgv.Items.Add(new ListItem("No", "No"));

            // Seleccionar el primer elemento por defecto
            comboIgv.SelectedIndex = 0;
        }


        private void inicioVigencia_Validated(object sender, EventArgs e)
        {

            pintaDias();



        }

        private string pintaDias()
        {
            var fecha = inicioVigencia.Value;

            d1.ToolTipText = fecha.DayOfWeek.ToString();
            d1.HeaderText = generico.traduceDia(fecha.DayOfWeek.ToString())+" "+fecha.Day.ToString();
            d2.HeaderText = generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString()) + " " + fecha.AddDays(1).Day.ToString();
            d3.HeaderText = generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString()) + " " + fecha.AddDays(2).Day.ToString();
            d4.HeaderText = generico.traduceDia(fecha.AddDays(3).DayOfWeek.ToString()) + " " + fecha.AddDays(3).Day.ToString();
            d5.HeaderText = generico.traduceDia(fecha.AddDays(4).DayOfWeek.ToString()) + " " + fecha.AddDays(4).Day.ToString();
            d6.HeaderText = generico.traduceDia(fecha.AddDays(5).DayOfWeek.ToString()) + " " + fecha.AddDays(5).Day.ToString();
            d7.HeaderText = generico.traduceDia(fecha.AddDays(6).DayOfWeek.ToString()) + " " + fecha.AddDays(6).Day.ToString();
            d8.HeaderText = generico.traduceDia(fecha.AddDays(7).DayOfWeek.ToString()) + " " + fecha.AddDays(7).Day.ToString();
            d9.HeaderText = generico.traduceDia(fecha.AddDays(8).DayOfWeek.ToString()) + " " + fecha.AddDays(8).Day.ToString();
            d10.HeaderText = generico.traduceDia(fecha.AddDays(9).DayOfWeek.ToString()) + " " + fecha.AddDays(9).Day.ToString();
            d11.HeaderText = generico.traduceDia(fecha.AddDays(10).DayOfWeek.ToString()) + " " + fecha.AddDays(10).Day.ToString();
            d12.HeaderText = generico.traduceDia(fecha.AddDays(11).DayOfWeek.ToString()) + " " + fecha.AddDays(11).Day.ToString();
            d13.HeaderText = generico.traduceDia(fecha.AddDays(12).DayOfWeek.ToString()) + " " + fecha.AddDays(12).Day.ToString();
            d14.HeaderText = generico.traduceDia(fecha.AddDays(13).DayOfWeek.ToString()) + " " + fecha.AddDays(13).Day.ToString();
            d15.HeaderText = generico.traduceDia(fecha.AddDays(14).DayOfWeek.ToString()) + " " + fecha.AddDays(14).Day.ToString();
            d16.HeaderText = generico.traduceDia(fecha.AddDays(15).DayOfWeek.ToString()) + " " + fecha.AddDays(15).Day.ToString();
            d17.HeaderText = generico.traduceDia(fecha.AddDays(16).DayOfWeek.ToString()) + " " + fecha.AddDays(16).Day.ToString();
            d18.HeaderText = generico.traduceDia(fecha.AddDays(17).DayOfWeek.ToString()) + " " + fecha.AddDays(17).Day.ToString();
            d19.HeaderText = generico.traduceDia(fecha.AddDays(18).DayOfWeek.ToString()) + " " + fecha.AddDays(18).Day.ToString();
            d20.HeaderText = generico.traduceDia(fecha.AddDays(19).DayOfWeek.ToString()) + " " + fecha.AddDays(19).Day.ToString();
            d21.HeaderText = generico.traduceDia(fecha.AddDays(20).DayOfWeek.ToString()) + " " + fecha.AddDays(20).Day.ToString();
            d22.HeaderText = generico.traduceDia(fecha.AddDays(21).DayOfWeek.ToString()) + " " + fecha.AddDays(21).Day.ToString();
            d23.HeaderText = generico.traduceDia(fecha.AddDays(22).DayOfWeek.ToString()) + " " + fecha.AddDays(22).Day.ToString();
            d24.HeaderText = generico.traduceDia(fecha.AddDays(23).DayOfWeek.ToString()) + " " + fecha.AddDays(23).Day.ToString();
            d25.HeaderText = generico.traduceDia(fecha.AddDays(24).DayOfWeek.ToString()) + " " + fecha.AddDays(24).Day.ToString();
            d26.HeaderText = generico.traduceDia(fecha.AddDays(25).DayOfWeek.ToString()) + " " + fecha.AddDays(25).Day.ToString();
            d27.HeaderText = generico.traduceDia(fecha.AddDays(26).DayOfWeek.ToString()) + " " + fecha.AddDays(26).Day.ToString();
            d28.HeaderText = generico.traduceDia(fecha.AddDays(27).DayOfWeek.ToString()) + " " + fecha.AddDays(27).Day.ToString();
            d29.HeaderText = generico.traduceDia(fecha.AddDays(28).DayOfWeek.ToString()) + " " + fecha.AddDays(28).Day.ToString();
            d30.HeaderText = generico.traduceDia(fecha.AddDays(29).DayOfWeek.ToString()) + " " + fecha.AddDays(29).Day.ToString();
            d31.HeaderText = generico.traduceDia(fecha.AddDays(30).DayOfWeek.ToString()) + " " + fecha.AddDays(30).Day.ToString();


            return fecha.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textProducto.Text)) && (!string.IsNullOrWhiteSpace(textMotivo.Text))
       && (!string.IsNullOrWhiteSpace(comboIgv.Text))
                   )
            {


                try
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
                    orden.FECHA_FIN = finVigencia.Value.ToString();
                    orden.C_EJECUTIVO = cmbEjecutivo.SelectedValue.ToString();
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

                        // comboCliente.SelectedIndex = 0;
                        comboMedio.SelectedIndex = 0;
                        comboContratos.SelectedIndex = 0;   
                        comboCliente.SelectedIndex = 0;
                        cmbEjecutivo.SelectedIndex = 0;
                        comboIgv.SelectedIndex = 0;
                        comboCambio.SelectedIndex = 0;
                        textProducto.Text = "";
                        textMotivo.Text = "";
                        textDuracion.Text = "";
                        textObservaciones.Text = "";
                        dataGridOrden.Rows.Clear();
                        totalOrden.Text = "";

                        cInicioVigencia.Text = "";
                        cFinVigencia.Text = "";
                        cNumeroFisico.Text = "";
                        cTipoCambio.Text = "";
                        cSaldo.Text = "";

                    }


                    else
                    {
                        MessageBox.Show((string)jObject["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Algunos campos requeridos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                orden.C_CONTRATO = comboContratos.SelectedValue.ToString();
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
                cInicioVigencia.Text = "";
                cFinVigencia.Text = "";
                cNumeroFisico.Text = "";
                cTipoCambio.Text = "";
                cSaldo.Text = "";

                

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
                    cSaldo.Text = data[0].SALDO_ACTUAL;





                }

                
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            comboBoxColumn.Name = "programa";
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
                System.Windows.Forms.ComboBox comboBox = e.Control as System.Windows.Forms.ComboBox;
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
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
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
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);
                        foreach (var ansValue in data)
                        {
                            dataGridOrden.Rows[currentRow].Cells[1].Value = Convert.ToString(ansValue["DIAS"]) + " " + Convert.ToString(ansValue["PERIODO"]);
                            dataGridOrden.Rows[currentRow].Cells[2].Value = Convert.ToString(ansValue["COSTO"]);
                        }



                       
                    }

                }

            }

        }

        private void dataGridOrden_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                double totalorden = 0;
                if (e.ColumnIndex >= 3 && e.ColumnIndex <= 34 ||
            e.ColumnIndex == dataGridOrden.Columns["costo"].Index)
                {
                    // Recorrer todas las filas
                    foreach (DataGridViewRow fila in dataGridOrden.Rows)
                    {
                        totalorden += Convert.ToDouble(fila.Cells["total"].Value);


                        // Obtener valores de cantidad y costo de la fila actual
                        double d1 = Convert.ToDouble(fila.Cells["d1"].Value);
                        double d2 = Convert.ToDouble(fila.Cells["d2"].Value);
                        double d3 = Convert.ToDouble(fila.Cells["d3"].Value);
                        double d4 = Convert.ToDouble(fila.Cells["d4"].Value);
                        double d5 = Convert.ToDouble(fila.Cells["d5"].Value);
                        double d6 = Convert.ToDouble(fila.Cells["d6"].Value);
                        double d7 = Convert.ToDouble(fila.Cells["d7"].Value);
                        double d8 = Convert.ToDouble(fila.Cells["d8"].Value);
                        double d9 = Convert.ToDouble(fila.Cells["d9"].Value);
                        double d10 = Convert.ToDouble(fila.Cells["d10"].Value);
                        double d11 = Convert.ToDouble(fila.Cells["d11"].Value);
                        double d12 = Convert.ToDouble(fila.Cells["d12"].Value);
                        double d13 = Convert.ToDouble(fila.Cells["d13"].Value);
                        double d14 = Convert.ToDouble(fila.Cells["d14"].Value);
                        double d15 = Convert.ToDouble(fila.Cells["d15"].Value);
                        double d16 = Convert.ToDouble(fila.Cells["d16"].Value);
                        double d17 = Convert.ToDouble(fila.Cells["d17"].Value);
                        double d18 = Convert.ToDouble(fila.Cells["d18"].Value);
                        double d19 = Convert.ToDouble(fila.Cells["d19"].Value);
                        double d20 = Convert.ToDouble(fila.Cells["d20"].Value);
                        double d21 = Convert.ToDouble(fila.Cells["d21"].Value);
                        double d22 = Convert.ToDouble(fila.Cells["d22"].Value);
                        double d23 = Convert.ToDouble(fila.Cells["d23"].Value);
                        double d24 = Convert.ToDouble(fila.Cells["d24"].Value);
                        double d25 = Convert.ToDouble(fila.Cells["d25"].Value);
                        double d26 = Convert.ToDouble(fila.Cells["d26"].Value);
                        double d27 = Convert.ToDouble(fila.Cells["d27"].Value);
                        double d28 = Convert.ToDouble(fila.Cells["d28"].Value);
                        double d29 = Convert.ToDouble(fila.Cells["d29"].Value);
                        double d30 = Convert.ToDouble(fila.Cells["d30"].Value);
                        double d31 = Convert.ToDouble(fila.Cells["d31"].Value);
                        double costo = Convert.ToDouble(fila.Cells["costo"].Value);

                        // Calcular el total
                        double total = (d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12 + d13 + d14 + d15 + d16 + d17 + d18 + d19 + d20 + d21 + d22 + d23 + d24 + d25 + d26 + d27 + d28 + d29 + d30 + d31) * costo;
                        double avisos = (d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12 + d13 + d14 + d15 + d16 + d17 + d18 + d19 + d20 + d21 + d22 + d23 + d24 + d25 + d26 + d27 + d28 + d29 + d30 + d31);
                        // Asignar el total a la columna "Total" de la fila actual
                        fila.Cells["total"].Value = total;
                        fila.Cells["avisos"].Value = avisos;


                    }
                    totalorden = 0;
                    foreach (DataGridViewRow fila in dataGridOrden.Rows)
                    {
                        totalorden += Convert.ToDouble(fila.Cells["total"].Value);
                        
                    }
                    totalOrden.Text = totalorden.ToString();
                }

                if (dataGridOrden.Rows.Count == 0)
                {
                    // Si está vacío, desactivar el botón
                    btnGuardar.Enabled = false;
                }
                else
                {
                    // Si no está vacío, activar el botón
                    btnGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void comboMedio_Leave(object sender, EventArgs e)
        {
            cargaprograma();
        }

        public class ListItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ListItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}









