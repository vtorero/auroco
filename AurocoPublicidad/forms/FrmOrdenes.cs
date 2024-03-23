using AurocoPublicidad.models.request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FrmOrdenes : Form
    {
        public FrmOrdenes()
        {
            InitializeComponent();
        }

        private async void FrmOrdenes_Load(object sender, EventArgs e)
        {
            string clientes = await GetService("https://aprendeadistancia.online/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedValue = "0";

            string medios = await GetService("https://aprendeadistancia.online/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "C_MEDIO";
            comboMedio.SelectedValue = "0";


            string respuesta = await GetService("https://aprendeadistancia.online/api-auroco/ordenes");
            List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(respuesta);
            //dgOrdenes.DataSource = lst;

            foreach (Ordenes ord in lst)
            {
                int rowIndex = dgOrdenes.Rows.Add();
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_ORDEN"].Value = ord.C_ORDEN;
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                dgOrdenes.Rows[rowIndex].Cells["Cliente"].Value = ord.RAZON_SOCIAL;
                dgOrdenes.Rows[rowIndex].Cells["C_MEDIO"].Value = ord.C_MEDIO;
                dgOrdenes.Rows[rowIndex].Cells["Medio"].Value = ord.NOMBRE;
                dgOrdenes.Rows[rowIndex].Cells["C_EJECUTIVO"].Value = ord.C_EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["EJECUTIVO"].Value = ord.EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["finicio"].Value = ord.INICIO_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["ffin"].Value = ord.FIN_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                dgOrdenes.Rows[rowIndex].Cells["producto"].Value = ord.PRODUCTO;
                dgOrdenes.Rows[rowIndex].Cells["motivo"].Value = ord.MOTIVO;
                dgOrdenes.Rows[rowIndex].Cells["duracion"].Value = ord.DURACION;
                dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                dgOrdenes.Rows[rowIndex].Cells["activa"].Value = ord.ACTIVA;


            }
        }
        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }


        private void dgOrdenes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int pos;
                pos = dgOrdenes.CurrentRow.Index;
                //MessageBox.Show(dgOrdenes[1, pos].Value.ToString());

                var idOrden = dgOrdenes[1, pos].Value.ToString();
                var idMedio = dgOrdenes[4, pos].Value.ToString();
                var idCliente = dgOrdenes[2, pos].Value.ToString();
                var idEjecutivo = dgOrdenes[6, pos].Value.ToString();
                var finicio = dgOrdenes[8, pos].Value.ToString();
                var ffin = dgOrdenes[9, pos].Value.ToString();
                var idContrato = dgOrdenes[10, pos].Value.ToString();
                var moneda = dgOrdenes[11, pos].Value.ToString();
                var totalOrden = dgOrdenes[12, pos].Value.ToString();

                var producto = dgOrdenes[13, pos].Value.ToString();
                var motivo = dgOrdenes[14, pos].Value.ToString();
                var duracion = dgOrdenes[15, pos].Value.ToString();
                var observaciones = dgOrdenes[16, pos].Value.ToString();
                FrmOrden frmOrden = new FrmOrden(idOrden, idMedio, idCliente, idContrato, idEjecutivo, finicio, ffin, moneda, totalOrden, producto, motivo, duracion, observaciones);
                frmOrden.ShowDialog();

            }
            catch (NullReferenceException ex)
            {


                MessageBox.Show("Algun dato esta incompleto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dgOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgOrdenes.Columns["total"].Index && e.Value != null)
            {


                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {

                    string monedaFormateada = "";
                    string simboloMoneda = "";


                    {

                        switch ((string)this.dgOrdenes.Rows[e.RowIndex].Cells["moneda"].Value)
                        {

                            case "Soles":

                                simboloMoneda = "S/."; // Símbolo del Nuevo Sol peruano

                                break;


                            case "Dolares":
                                simboloMoneda = "$"; // Símbolo del dólar estadounidense

                                break;

                        }



                        // Aplicar formato de moneda según la moneda deseada


                        // Seleccionar el símbolo de la moneda según el caso (dólares o soles)






                        // Aplicar formato de moneda con el símbolo seleccionado
                        monedaFormateada = string.Format("{0}{1:N2}", simboloMoneda, valor); // "N2" indica dos dígitos decimales

                        e.Value = monedaFormateada;
                        e.FormattingApplied = true; // Indicar que se ha aplicado el formato

                    }
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dgOrdenes.Rows.Clear();
            string url = "https://aprendeadistancia.online/api-auroco/buscaorden";
            Ordenes orden = new Ordenes();
            orden.C_CLIENTE = comboCliente.SelectedValue.ToString();
            orden.C_MEDIO = comboMedio.SelectedValue.ToString();
            orden.INICIO_VIGENCIA = dtDesde.Value.ToString();
            orden.FIN_VIGENCIA = dtHasta.Value.ToString();
            string resultado = Send<Ordenes>(url, orden, "POST");
            List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(resultado);

            foreach (Ordenes ord in lst)
            {
                int rowIndex = dgOrdenes.Rows.Add();
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_ORDEN"].Value = ord.C_ORDEN;
                dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                dgOrdenes.Rows[rowIndex].Cells["Cliente"].Value = ord.RAZON_SOCIAL;
                dgOrdenes.Rows[rowIndex].Cells["C_MEDIO"].Value = ord.C_MEDIO;
                dgOrdenes.Rows[rowIndex].Cells["Medio"].Value = ord.NOMBRE;
                dgOrdenes.Rows[rowIndex].Cells["C_EJECUTIVO"].Value = ord.C_EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["EJECUTIVO"].Value = ord.EJECUTIVO;
                dgOrdenes.Rows[rowIndex].Cells["finicio"].Value = ord.INICIO_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["ffin"].Value = ord.FIN_VIGENCIA;
                dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                dgOrdenes.Rows[rowIndex].Cells["producto"].Value = ord.PRODUCTO;
                dgOrdenes.Rows[rowIndex].Cells["motivo"].Value = ord.MOTIVO;
                dgOrdenes.Rows[rowIndex].Cells["duracion"].Value = ord.DURACION;
                dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;


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

        private async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int pos;
                string estado="";
                pos = dgOrdenes.CurrentRow.Index;
               var idOrden = dgOrdenes[1, pos].Value.ToString();
                if (dgOrdenes[17, pos].Value.ToString() != "NO")
                {
                    estado = dgOrdenes[17, pos].Value.ToString();

                    HttpClient clienteHttp = new HttpClient();
                    string urlApi = $"https://aprendeadistancia.online/api-auroco/anulaorden/{idOrden}"; // URL de tu servicio API con parámetros   

                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);
                        JObject jObject = JObject.Parse(contenido);
                        JToken objeto = jObject["message"];
                        string status = (string)objeto;
                        MessageBox.Show(status, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(respuesta.ReasonPhrase, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La orden ya esta anulada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                 

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}