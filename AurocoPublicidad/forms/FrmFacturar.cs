using AurocoPublicidad.models.request;
using AurocoPublicidad.models.request.factura;
using AurocoPublicidad.reportes;
using AurocoPublicidad.util;
using CrystalDecisions.ReportAppServer.CommonControls;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Tls;
using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Cliente = AurocoPublicidad.models.request.factura.Cliente;






namespace AurocoPublicidad.forms
{
    public partial class FrmFacturar : Form
    {
        private string valorRecibido;
        private string valorIdOrden;
        private string valorCliente;
        private string valorRuc;
        private string valorContrato;
        private string valorEjecutivo;
        private string valorFecha;
        private string valorInicio;
        private string valorFin;
        private string valorMoneda;
        private string valorTotal;
        private string valorProducto;
        private string valorMotivo;
        private string valorDuracion;
        private string valorObservaciones;
        private string valorAgencia;
        private decimal totalorden;

        private string apiUrl = Global.servicio + "/api-auroco/facturacion.php/test-factura";
        public FrmFacturar(string id, string cliente, string ruc, string fecha, string observaciones, string moneda, string producto, string motivo, string total)
        {

            InitializeComponent();
            valorIdOrden = id;
            valorCliente = cliente;
            valorRuc = ruc;
            valorFecha = fecha;
            valorMoneda = moneda;
            valorTotal = total;
            valorProducto = producto;
            valorMotivo = motivo;
            Console.Write(valorTotal);
            valorObservaciones = observaciones;





            if (id != "")
            {



                LblNumero.Visible = true;
                txtNumero.Visible = true;
                txtNumero.Text = id;
                btnEnviar.Visible = true;

                pintaDias();


            }
            else
            {
                LblNumero.Visible = false;
                txtNumero.Visible = false;

                btnEnviar.Visible = false;
                txtNumero.Text = "";
                DateTime primerDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime ultimoDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                // Establecer el valor del DateTimePicker al primer día del mes actual
                inicioVigencia.Value = primerDiaDelMes;

                pintaDias();
            }


        }



        private async void ComboBoxAutocomplete_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && comboCliente.Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                string clientes = await GetService(Global.servicio + "/api-auroco/cliente_buscar/" + comboCliente.Text);
                List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
                comboCliente.DataSource = lstC;
                comboCliente.DisplayMember = "RAZON_SOCIAL";
                comboCliente.ValueMember = "C_CLIENTE";
                comboCliente.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            if (e.KeyCode == Keys.Enter && comboCliente.Text == "")
            {
                fillClientes();
            }



        }


        private async void fillClientes()
        {
            Cursor.Current = Cursors.WaitCursor;
            string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            Cursor.Current = Cursors.Default;
        }


        private void inicioVigencia_Validated(object sender, EventArgs e)
        {

            pintaDias();



        }

        private async Task<List<OrdenesLinea>> cargarLineas(string id)
        {

            string ordenes = await GetService(Global.servicio + "/api-auroco/orden/" + id);
            List<models.request.OrdenesLinea> lstC = JsonConvert.DeserializeObject<List<models.request.OrdenesLinea>>(ordenes);






            return lstC;
        }




        private string pintaDias()
        {
            var fecha = inicioVigencia.Value;

            if (valorInicio != "")
            {
                fecha = Convert.ToDateTime(valorInicio);
            }



            /* if (fecha.DayOfWeek() = 'S') { 
             }
            */


            return fecha.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //progressBar1.Visible = false;
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

                orden.orden = datos;



                string datosJson = Newtonsoft.Json.JsonConvert.SerializeObject(orden);

                // Crea el contenido de la solicitud HTTP
                StringContent resultado = new StringContent(Send(apiUrl, orden, "POST",""   ));

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






        public static string SendDos<T>(string url, T data, string method, string token)
        {
            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(data);

            // Crear el request
            WebRequest request = WebRequest.Create(url);
            request.Method = method.ToUpper();
            request.ContentType = "application/json";

            // Agregar encabezado Authorization con el token
            request.Headers["Authorization"] = "Bearer " + token;

            // Escribir el cuerpo de la solicitud
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
            }

            // Obtener la respuesta
            using (WebResponse response = request.GetResponse())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }


        }
        



        public string Send<T>(string url, T ObjectRequest, string method = "POST",string token="")
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
                request.Headers["Authorization"] = "Bearer " + token;
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








        public async void cargaprograma(string canal)
        {





        }

        private void dataGridOrden_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Verificar si la celda actual es la que contiene un ComboBox

        }

        private async void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ComboBox que disparó el evento
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox != null)
            {
                // Obtener el valor seleccionado

                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (comboBox.SelectedValue != null)
                {
                    string selectedValue = comboBox.SelectedValue.ToString();



                    HttpClient clienteHttp = new HttpClient();


                    string urlApi = Global.servicio + "/api-auroco/programa/" + selectedValue; // URL de tu servicio API con parámetros   

                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();


                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);








                    }

                }

            }

        }

        private void dataGridOrden_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


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



        private void button1_Click(object sender, EventArgs e)
        {
            Form childForm = new formReportes(valorIdOrden, inicioVigencia.Value.ToString(), txtAgencia.Text);

            childForm.Text = "Orden nro: " + valorIdOrden;
            childForm.Show();

        }

        private void dataGridOrden_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //btnGuardar.Enabled = true;
        }

        private void dataGridOrden_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // btnGuardar.Enabled = true;
        }

        private void dataGridOrden_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //btnGuardar.Enabled = true;
        }

        private void dataGridOrden_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void FrmFacturar_Load(object sender, EventArgs e)
        {

            comboCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCliente.KeyDown += ComboBoxAutocomplete_TextChanged;
            string simboloMoneda = "";
            if (valorMoneda == "Soles")
            {
                simboloMoneda = "S/.";
            }
            else
            {
                simboloMoneda = "$";
            }
            Double igv = 0;
            Double totalOrd = 0;
            if (valorTotal != "")
            {
                igv = Convert.ToDouble(valorTotal) * 0.18;

                totalOrd = Convert.ToDouble(valorTotal) + igv;
                totalorden = Convert.ToDecimal(totalOrd);
            }
            if (valorTotal != "") totalOrden.Text = string.Format("{0}{1:N2}", simboloMoneda, valorTotal);
            if (valorTotal != "") txtIgv.Text = string.Format("{0}{1:N2}", simboloMoneda, igv);
            if (valorTotal != "") totalBruto.Text = string.Format("{0}{1:N2}", simboloMoneda, totalOrd);
            if (valorRuc != "") txtRuc.Text = valorRuc;
            cargaRuc(valorRuc);
            if (valorObservaciones != "") textObservaciones.Text = valorObservaciones;
            if (valorMoneda != "") cMoneda.Text = valorMoneda;
            if (valorProducto != "") txtProducto.Text = valorProducto;
            if (valorMotivo != "") txtMotivo.Text = valorMotivo;






            if (valorObservaciones != "") textObservaciones.Text = valorObservaciones;


            string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedValue = "0";
            if (valorCliente != "")
                comboCliente.SelectedValue = valorCliente;

            string medios = await GetService(Global.servicio + "/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);


            string ejecutivos = await GetService(Global.servicio + "/api-auroco/tabla/ORD_EJECUTIVOS/NOMBRES");
            List<models.request.Ejecutivo> lstE = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(ejecutivos);


            string monedas = await GetService(Global.servicio + "/api-auroco/monedas");
            List<models.request.Monedas> lstMo = JsonConvert.DeserializeObject<List<models.request.Monedas>>(monedas);


            // Seleccionar el primer elemento por defecto

            txtAgencia.Items.Add(new ListItem("0", "Seleccionar"));
            txtAgencia.Items.Add(new ListItem("AUROCO", "AUROCO"));
            txtAgencia.Items.Add(new ListItem("OPTIMIZA", "OPTIMIZA"));
            // Seleccionar el primer elemento por defecto

            if (valorAgencia != "" && valorAgencia == "AUROCO")
                txtAgencia.SelectedIndex = 1;
            else if (valorAgencia != "" && valorAgencia == "OPTIMIZA")
                txtAgencia.SelectedIndex = 2;
            else
                txtAgencia.SelectedIndex = 1;

            dataCuentas.Columns.Add(new CalendarColumn
            {
                HeaderText = "Fecha Vencimiento",
                Name = "colFecha"
            });


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void textObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataCuentas.Enabled = true;
            dataCuentas.Visible = true;
        }

        private void rdContado_CheckedChanged(object sender, EventArgs e)
        {
            dataCuentas.Rows.Clear();
            dataCuentas.Enabled = false;
            dataCuentas.Visible = false;
        }

        private void CalcularTotalYComparar()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataCuentas.Rows)
            {
                if (row.Cells[0].Value != null && decimal.TryParse(row.Cells[0].Value.ToString(), out decimal monto))
                {
                    total += monto;
                    Console.Write(total);
                }
            }

            // Mostrar el total (opcional, por ejemplo en un label)
            //lblTotal.Text = "Total: " + total.ToString("C");

            // Comparar con monto máximo
            //if (totalorden, out decimal montoMaximo))
            //{
            if (total > totalorden)
            {
                MessageBox.Show("El total de montos excede el monto permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
        }

        private void dataCuentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotalYComparar();
        }

        private void dataCuentas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularTotalYComparar();
        }

        private async void cargaRuc(string nro)
        {
            if (nro != "")
            {
                try
                {


                    Ruc people = await GetJsonArrayFromUrlAsync<Ruc>(Global.urlRuc + nro + "?token=" + Global.tokenApi);
                    // Aquí puedes hacer algo con el array 'people'
                    txtDireccion.Text = people.Direccion;
                    txtDpto.Text = people.Departamento;
                    txtProvincia.Text = people.Provincia;
                    txtDistrito.Text = people.Distrito;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error: {ex.Message}");
                    MessageBox.Show("Número de RUC iválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un número de RUC", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        private async Task<Ruc> GetJsonArrayFromUrlAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Realiza la solicitud HTTP GET a la URL especificada
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verifica si la respuesta es exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como una cadena
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserializa la cadena JSON en un array de tipo T
                        Ruc ruc = JsonConvert.DeserializeObject<Ruc>(jsonResponse);

                        return ruc;
                    }
                    else
                    {
                        throw new Exception("No se pudo obtener una respuesta exitosa del servidor.");
                    }
                }
                catch (Exception ex)
                {
                    // Maneja excepciones si la solicitud HTTP falla
                    throw new Exception($"Error al realizar la solicitud GET: {ex.Message}");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                porcentajeDet.Enabled = true;
            }
            else
            {
                porcentajeDet.Enabled = false;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            Company comp = new Company();   
            Cliente client = new Cliente();
            Address address = new Address();
            Cuotas cuotas = new Cuotas();
            /*cuerpo factura*/
            factura.ublVersion = "2.1";
            factura.tipoOperacion = "0101";
            factura.tipoDoc = "01";
            factura.serie = "F001";
            factura.correlativo = "00001";
            factura.fechaEmision = "2021-01-27T00:00:00-05:00";
            comp.razonSocial = "AUROCO PUBLICIDAD S A";
            comp.ruc = "20111409391";
            comp.nombreComercial = "AUROCO PUBLICIDAD S A";
            factura.company= comp;  
            //factura.cuotas;
            List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();
            bool campoOEsNulo = false;
            foreach (DataGridViewRow fila in dataCuentas.Rows)
            {
                if (!fila.IsNewRow)
                {
                    Dictionary<string, object> filaDatos = new Dictionary<string, object>();

                    // Itera a través de las celdas en la fila
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreColumna = dataCuentas.Columns[celda.ColumnIndex].Name;
                        object valorCelda = celda.Value;
                        if (nombreColumna == "o" && valorCelda == null)
                        {
                            campoOEsNulo = true;
                            break; // No hace falta seguir iterando esta fila
                        }
                        // Usa el nombre de la columna como clave y el valor de la celda como valor
                        filaDatos[nombreColumna] = valorCelda;
                        
                    }
                    if (!campoOEsNulo)
                    {
                        datos.Add(filaDatos);
                    }
                    // Agrega la fila de datos a la lista
                    //datos.Add(filaDatos);
                }
            }
            
     



            address.departamento = txtDpto.Text;
            address.provincia = txtProvincia.Text;
            address.distrito = txtDistrito.Text;
            client.numDoc = txtRuc.Text;
            client.Address = address;
            factura.cliente = client;
            factura.formaPago = new FormaPago();

            
            if (rdContado.Checked) {
            factura.formaPago.Tipo = "Contado";
            }
            if (rdCredito.Checked) {
                factura.formaPago.Tipo = "Credito";
                factura.formaPago.Monto = 100;
            }
            factura.cuotas = datos;
            if (cMoneda.Text == "Soles")
            {
                factura.tipoMoneda = "PEN";
                factura.formaPago.Moneda = "PEN";

            }
            if (cMoneda.Text == "Dolares")
            {
                factura.tipoMoneda = "USD";
                factura.formaPago.Moneda = "USD";
            }


            string Resultado = SendDos<Factura>("https://facturacion.apisperu.com/api/v1/invoice/send", factura,"POST", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJ1c2VybmFtZSI6InZ0b3Jlcm8iLCJjb21wYW55IjoiMjAxMTE0MDkzOTEiLCJpYXQiOjE3Mjg1OTYwNjIsImV4cCI6ODAzNTc5NjA2Mn0.i-MOya93NHQM8G1b457hSVFu57isfM08ePqjoIPBdTTrG2_MGnWT9sYACoTFLxspRXSngO3-QbTpP7gT9oL1tutEW1Yo7qboXJyWOAGP9MDTvG-fwJwB0SRi_qYmnBkZgzu9KooITZky7RER1I3VY1RmvoOAfrJmlo9pe_9cOd66kkKqpChW_tNg-BqooF1c8hB4tsPXudkOSmncV3A2n1gSoV4LHgkvWxEVCG8iK0CFjhPcID6ySdQRf_ARJHOMi0yoX4UEPJ-wcg-3zqB1Hma_QA_omirao1A2lvR2mCO1InOmVpCCAj8rfARFktchiC1bV86F0CVku9Obq4jkLwJrDn6PGVk17HIuJ_DyPxCMFxLdPHHrC2iqWAemZkiOVNYPLHRgOc17RIGhjEmdRKz0zsyOK-tevuQa4AsYFQIzUEQDfgH48vrSDRD1Z_RNLjk0utqhgbWfQq3QWAg7ls5UtXEKuCf5otKA82tqEUPajkhpFAg5SQZFQopHFrYZmJWvQyjMKF3CVAw6E7kqzd9ujDHWKnqwltx3TFQ9laWPo9iE7J8jAHcgwFkUE7Zlj7ZRpOIeA2K-eE-MG7qFLk5011sMSujW9f9Sh0Te7LRfJ6LMPsXLUt8NpZ4wGSMBhCrRdqDYadJUL7Cq09nv7APVWKp-i3fd_QX-I9UH9M4");

          
            JObject jObject = JObject.Parse(Resultado);
            JToken objeto = jObject["sunatResponse"];
           // JToken objcodigo = jObject["codigo"];
            MessageBox.Show("" + (string)objeto["error"]["message"]);
            Console.Write(Resultado);

            Console.Write(factura.ToString());

        }


    }
}