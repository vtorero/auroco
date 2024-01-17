using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
        int pos;
        public FrmContratos()
        {
            InitializeComponent();
        }


        private async void FrmContratos_Load(object sender, EventArgs e)
        {
            string respuesta = await GetService("https://aprendeadistancia.online/api-auroco/contratos");
            List<models.request.Contrato> lst = JsonConvert.DeserializeObject<List<models.request.Contrato>>(respuesta);
            DgContratos.DataSource = lst;



            string clientes = await GetService("https://aprendeadistancia.online/api-auroco/clientes");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";


            string monedas = await GetService("https://aprendeadistancia.online/api-auroco/monedas");
            List<models.request.Monedas> lstM = JsonConvert.DeserializeObject<List<models.request.Monedas>>(monedas);
            comboMoneda.DataSource = lstM;
            comboMoneda.DisplayMember = "NOMBRE";
            comboMoneda.ValueMember = "VALOR";


            DgContratos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }






        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(txtNroFisico.Text)) && (!string.IsNullOrWhiteSpace(comboCliente.Text))
                && (!string.IsNullOrWhiteSpace(comboMoneda.Text))
                            )
            {

                string url = "https://aprendeadistancia.online/api-auroco/contrato";
                Contrato contratoR = new Contrato();
                contratoR.NRO_FISICO = txtNroFisico.Text;
                contratoR.C_CLIENTE = comboCliente.SelectedValue.ToString();
                contratoR.INICIO_VIGENCIA = this.dataFechaInicio.Value.ToString("yyyy-MM-dd");
                contratoR.FIN_VIGENCIA = this.dataFechaFin.Value.ToString("yyyy-MM-dd");
                contratoR.C_MONEDA = comboMoneda.Text;
                contratoR.TIPO_CAMBIO = Convert.ToDecimal(txtTipoCambio.Text);
                contratoR.C_MONTO_PAGAR = Convert.ToDecimal(txtMonto.Text);
                contratoR.C_MONTO_ORDENAR = Convert.ToDecimal(txtOrdenar.Text);
                contratoR.OBSERVACIONES = txtObservaciones.Text;
                contratoR.C_USUARIO = Global.sessionUsuario.ToString();

            
            
            

            

            string resultado = Send<Contrato>(url, contratoR, "POST");

            JObject jObject = JObject.Parse(resultado);
            JToken objeto = jObject["status"];
            string status= (string)objeto;

            if (status == "True")
            {
                MessageBox.Show( (string) jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Form childForm = new MDIPrincipal();
                //childForm.Show();
                //this.Hide();

               string respuesta = await GetService("https://aprendeadistancia.online/api-auroco/contratos");
                List<models.request.Contrato> lst = JsonConvert.DeserializeObject<List<models.request.Contrato>>(respuesta);
                DgContratos.DataSource = lst;


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

        private void DgContratos_DoubleClick(object sender, EventArgs e)
        {
            pos = DgContratos.CurrentRow.Index;
            comboMoneda.SelectedText=null;
            txtCodigo.Text = Convert.ToString(DgContratos[1, pos].Value);
            comboCliente.SelectedValue = Convert.ToString(DgContratos[2, pos].Value);
            txtNroFisico.Text= Convert.ToString(DgContratos[6, pos].Value);
            comboMoneda.SelectedValue = Convert.ToString(DgContratos[7, pos].Value);
            txtMonto.Text = Convert.ToString(DgContratos[8, pos].Value);
            txtOrdenar.Text = Convert.ToString(DgContratos[9, pos].Value);
            dataFechaInicio.Value= Convert.ToDateTime(DgContratos[4, pos].Value);
            dataFechaFin.Value = Convert.ToDateTime(DgContratos[5, pos].Value);
            txtTipoCambio.Text = Convert.ToString(DgContratos[10, pos].Value);
            txtObservaciones.Text=Convert.ToString(DgContratos[11, pos].Value);
            //MessageBox.Show(pos+"","ss");
        }
    }



}
