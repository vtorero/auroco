using AurocoPublicidad.models.request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AurocoPublicidad.forms { 
    
    public partial class FrmContratos : Form
    {
        public FrmContratos()
        {
            InitializeComponent();
        }

               
        private async void FrmContratos_Load(object sender, EventArgs e)
        {
            string respuesta = await GetContratos("https://aprendeadistancia.online/api-auroco/contratos");
            List<models.request.Contrato> lst = JsonConvert.DeserializeObject<List<models.request.Contrato>>(respuesta);
            DgContratos.DataSource = lst;

            string clientes = await GetContratos("https://aprendeadistancia.online/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
       




        }






        private async Task<string> GetContratos(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://aprendeadistancia.online/api-auroco/contrato";
            Contrato contratoR  = new Contrato();
            contratoR.C_CLIENTE = comboCliente.SelectedValue.ToString();
            contratoR.INICIO_VIGENCIA = this.dataFechaInicio.Value.ToString("yyyy-MM-dd");
            contratoR.FIN_VIGENCIA= this.dataFechaFin.Value.ToString("yyyy-MM-dd");

            string resultado = Send<Contrato>(url, contratoR, "POST");

            JObject jObject = JObject.Parse(resultado);
            JToken objeto = jObject["status"];
            string nombre = (string)objeto;

            if (nombre == "True")
            {
                //MessageBox.Show("Acceso autorizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form childForm = new MDIPrincipal();
                childForm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Acceso denegado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }



}
