using AurocoPublicidad.models.request;
using AurocoPublicidad.reportes;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AurocoPublicidad.forms
{
    public partial class FrmClientes : Form
    {
        int pos;
        Boolean nuevo = true;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, System.EventArgs e)
        {
            cargarClientes();
        }


        private async void cargarClientes()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/clientes");
            List<models.request.Cliente> lst = JsonConvert.DeserializeObject<List<models.request.Cliente>>(respuesta);

            DgClientes.Rows.Clear();

            foreach (Cliente ord in lst)
            {
                int rowIndex = DgClientes.Rows.Add();
                DgClientes.Rows[rowIndex].Cells["codigo"].Value = ord.C_CLIENTE;
                DgClientes.Rows[rowIndex].Cells["ruc"].Value = ord.RUC;
                DgClientes.Rows[rowIndex].Cells["razon"].Value = ord.RAZON_SOCIAL;
                DgClientes.Rows[rowIndex].Cells["direccion"].Value = ord.DIRECCION;
                DgClientes.Rows[rowIndex].Cells["telefono"].Value = ord.TELEFONO;
                DgClientes.Rows[rowIndex].Cells["contacto"].Value = ord.CONTACTO;
                DgClientes.Rows[rowIndex].Cells["rptlegal"].Value = ord.RPT_LEGAL;
                DgClientes.Rows[rowIndex].Cells["rpt_dni"].Value = ord.RPT_DNI;
                DgClientes.Rows[rowIndex].Cells["rptdireccion"].Value = ord.RPT_DIRECCION;

            }

        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void DgClientes_DoubleClick(object sender, System.EventArgs e)
        {
            nuevo = false;
            btnGuardar.Text = "&Actualizar";
            pos = DgClientes.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(DgClientes[0, pos].Value);
            txtRUC.Text = Convert.ToString(DgClientes[1, pos].Value);
            txtRazon.Text = Convert.ToString(DgClientes[2, pos].Value);
            txtcontacto.Text = Convert.ToString(DgClientes[5, pos].Value);
            txtDireccion.Text = Convert.ToString(DgClientes[3, pos].Value);
            txtTelefono.Text = Convert.ToString(DgClientes[4, pos].Value);
            txtRepresentante.Text = Convert.ToString(DgClientes[6, pos].Value);
            txtDNI.Text = Convert.ToString(DgClientes[7, pos].Value);
            rpt_Direccion.Text = Convert.ToString(DgClientes[8, pos].Value);


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string metodo = "";
            if (nuevo)
            {
                metodo = "POST";

            }
            else
            {
                metodo = "PUT";
            }


            if ((!string.IsNullOrWhiteSpace(txtRazon.Text)) && (!string.IsNullOrWhiteSpace(txtRUC.Text))
            && (!string.IsNullOrWhiteSpace(txtcontacto.Text))
                        )
            {

                string url = Global.servicio + "/api-auroco/cliente";
                Cliente cliente = new Cliente();
                cliente.C_CLIENTE = txtCodigo.Text;
                cliente.id = txtCodigo.Text;
                cliente.RUC = txtRUC.Text;
                cliente.RAZON_SOCIAL = txtRazon.Text;
                cliente.CONTACTO = txtcontacto.Text;
                cliente.DIRECCION = txtDireccion.Text;
                cliente.TELEFONO = txtTelefono.Text;
                cliente.RPT_LEGAL = txtRepresentante.Text;
                cliente.RPT_DNI = txtDNI.Text;
                cliente.RPT_DIRECCION = txtDireccion.Text;
                cliente.USUARIO_CREACION = Global.sessionUsuario.ToString();





                string resultado = Send<Cliente>(url, cliente, metodo);

                JObject jObject = JObject.Parse(resultado);
                JToken objeto = jObject["status"];
                string status = (string)objeto;

                if (status == "True")
                {
                    MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nuevo = true;
                    txtCodigo.Text = "";
                    txtRUC.Text = "";
                    txtRazon.Text = "";
                    txtcontacto.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    txtRepresentante.Text = "";
                    txtDNI.Text = "";
                    txtDireccion.Text = "";
                    rpt_Direccion.Text = "";

                    cargarClientes();


                }
                else
                {
                    MessageBox.Show("Ocurrió un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            else
            {
                MessageBox.Show("Algunos campos estan incompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            nuevo = true;
            txtCodigo.Text = "";
            txtRUC.Text = "";
            txtRazon.Text = "";
            txtcontacto.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtRepresentante.Text = "";
            txtDNI.Text = "";
            txtDireccion.Text = "";
            rpt_Direccion.Text = "";
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtRUC.Text != "") { 
            try
            {


                Ruc people = await GetJsonArrayFromUrlAsync<Ruc>(Global.urlRuc+txtRUC.Text+"?token="+Global.tokenApi);
                // Aquí puedes hacer algo con el array 'people'
                txtRazon.Text = people.razonSocial;
                txtDireccion.Text = people.direccion;

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

        private void button3_Click(object sender, EventArgs e)
        {
            DgClientes.Rows.Clear();
            string url = Global.servicio + "/api-auroco/buscaclientes";
            Cliente cliente = new Cliente();
            cliente.RAZON_SOCIAL = textoRazon.Text;
            string resultado = Send<Cliente>(url, cliente, "POST");
            List<models.request.Cliente> lst = JsonConvert.DeserializeObject<List<models.request.Cliente>>(resultado);


            foreach (Cliente ord in lst)
            {
                int rowIndex = DgClientes.Rows.Add();
                DgClientes.Rows[rowIndex].Cells["codigo"].Value = ord.C_CLIENTE;
                DgClientes.Rows[rowIndex].Cells["ruc"].Value = ord.RUC;
                DgClientes.Rows[rowIndex].Cells["razon"].Value = ord.RAZON_SOCIAL;
                DgClientes.Rows[rowIndex].Cells["direccion"].Value = ord.DIRECCION;
                DgClientes.Rows[rowIndex].Cells["telefono"].Value = ord.TELEFONO;
                DgClientes.Rows[rowIndex].Cells["contacto"].Value = ord.CONTACTO;
                DgClientes.Rows[rowIndex].Cells["rptlegal"].Value = ord.RPT_LEGAL;
                DgClientes.Rows[rowIndex].Cells["rpt_dni"].Value = ord.RPT_DNI;
                DgClientes.Rows[rowIndex].Cells["rptdireccion"].Value = ord.RPT_DIRECCION;


            }
        }
    }
    }

