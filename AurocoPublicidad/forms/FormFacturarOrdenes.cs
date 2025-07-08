using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AurocoPublicidad.forms
{
    public partial class FormFacturarOrdenes : Form
    {
        public FormFacturarOrdenes()
        {
            InitializeComponent();
        }

        private async void FormFacturarOrdenes_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.SelectedValue = "0";

            string medios = await GetService(Global.servicio + "/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "C_MEDIO";
            comboMedio.SelectedValue = "0";

            cargaOrdenes();
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void cargaOrdenes()
        {
            string apiUrl = Global.servicio + "/api-auroco/ordenes";
            using (HttpClient client = new HttpClient())

            {
                try
                {
                    lblPorcentaje.Text = "Conectando...";
                    
                    var response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var lista = JsonConvert.DeserializeObject<List<Ordenes>>(content);


                    int total = lista.Count;
                    int contador = 0;
                    // string respuesta = await GetService(Global.servicio + "/api-auroco/ordenes");

                    List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(content);
                    //dgOrdenes.DataSource = lst;

                    dgOrdenes.Rows.Clear();
                    foreach (Ordenes ord in lst)
                    {

                        contador++;
                        int porcentaje = (int)((contador * 100.0) / total);
                        progressBar1.Value = porcentaje;
                        lblPorcentaje.Text = $"{porcentaje}%";
                        lblPorcentaje.Refresh();

                        int rowIndex = dgOrdenes.Rows.Add();
                        dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                        dgOrdenes.Rows[rowIndex].Cells["C_ORDEN"].Value = ord.C_ORDEN;
                        dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                        dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                        dgOrdenes.Rows[rowIndex].Cells["C_RUC"].Value = ord.C_RUC;
                        dgOrdenes.Rows[rowIndex].Cells["Cliente"].Value = ord.RAZON_SOCIAL;
                        dgOrdenes.Rows[rowIndex].Cells["C_MEDIO"].Value = ord.C_MEDIO;
                        dgOrdenes.Rows[rowIndex].Cells["Medio"].Value = ord.NOMBRE;
                        dgOrdenes.Rows[rowIndex].Cells["C_EJECUTIVO"].Value = ord.C_EJECUTIVO;
                        dgOrdenes.Rows[rowIndex].Cells["EJECUTIVO"].Value = ord.EJECUTIVO;
                        dgOrdenes.Rows[rowIndex].Cells["f_creacion"].Value = ord.F_CREACION;
                        dgOrdenes.Rows[rowIndex].Cells["f_inicio"].Value = ord.INICIO_VIGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["f_fin"].Value = ord.FIN_VIGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                        dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                        dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                        dgOrdenes.Rows[rowIndex].Cells["producto"].Value = ord.PRODUCTO;
                        dgOrdenes.Rows[rowIndex].Cells["motivo"].Value = ord.MOTIVO;
                        dgOrdenes.Rows[rowIndex].Cells["duracion"].Value = ord.DURACION;
                        dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                        dgOrdenes.Rows[rowIndex].Cells["revision"].Value = ord.REVISION;
                        dgOrdenes.Rows[rowIndex].Cells["activa"].Value = ord.ACTIVA;
                        dgOrdenes.Rows[rowIndex].Cells["agencia"].Value = ord.AGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["tipoCambio"].Value = ord.TIPO_CAMBIO;
                        if (contador % 5 == 0 || contador == total)
                        {
                            dgOrdenes.DataSource = null;
                           // dgOrdenes.DataSource = new List<Ordenes>(content);
                        }

                    }
                    lblPorcentaje.Visible = false;  
                    Cursor.Current = Cursors.Default;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void dgOrdenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditarOrden();
        }

        private void EditarOrden()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                System.Threading.Thread.Sleep(500);
                int pos;
                pos = dgOrdenes.CurrentRow.Index;
                var idOrden = dgOrdenes[1, pos].Value.ToString();
                var idCliente = dgOrdenes[2, pos].Value.ToString();
                var ruc = dgOrdenes[3, pos].Value.ToString();
                var fcreacion = dgOrdenes[9, pos].Value.ToString();
                var idEjecutivo = dgOrdenes[7, pos].Value.ToString();
                var finicio = dgOrdenes[9, pos].Value.ToString();
                var ffin = dgOrdenes[10, pos].Value.ToString();
                
                var moneda = dgOrdenes[13, pos].Value.ToString();
                var totalOrden = dgOrdenes[14, pos].Value.ToString();

                var producto = dgOrdenes[15, pos].Value.ToString();
                var motivo = dgOrdenes[16, pos].Value.ToString();
                var duracion = dgOrdenes[17, pos].Value.ToString();
                var observaciones = dgOrdenes[18, pos].Value.ToString();
                var agencia = dgOrdenes[22, pos].Value.ToString();
                var tipo_cambio = dgOrdenes[21, pos].Value.ToString();
                FrmFacturar frmFacturar = new FrmFacturar(idOrden,idCliente,ruc,fcreacion, observaciones,moneda,producto,motivo, totalOrden, tipo_cambio);
                frmFacturar.Show();
                Cursor.Current = Cursors.Default;

            }
            catch (NullReferenceException ex)
            {


                MessageBox.Show("Algun dato esta incompleto " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor.Current = Cursors.Default;
            }



        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {



                Cursor.Current = Cursors.WaitCursor;
                dgOrdenes.Rows.Clear();
                /*string url = Global.servicio + "/api-auroco/ordenes";
                //string url = Global.servicio + "/api-auroco/buscaorden";
                Ordenes orden = new Ordenes();
                orden.C_CLIENTE = comboCliente.SelectedValue.ToString();
                orden.C_MEDIO = Convert.ToString(comboMedio.SelectedValue);
                orden.INICIO_VIGENCIA = dtDesde.Value.ToString();
                orden.FIN_VIGENCIA = dtHasta.Value.ToString();
                orden.C_ORDEN = txtOrden.Text;
                string resultado = Send<Ordenes>(url, orden, "POST");
                */

                string respuesta = await GetService(Global.servicio + "/api-auroco/ordenes");
                List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(respuesta);
               // List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(resultado);

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
                    dgOrdenes.Rows[rowIndex].Cells["f_creacion"].Value = ord.F_CREACION;
                    dgOrdenes.Rows[rowIndex].Cells["f_inicio"].Value = ord.INICIO_VIGENCIA;
                    dgOrdenes.Rows[rowIndex].Cells["f_fin"].Value = ord.FIN_VIGENCIA;
                    dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                    dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                    dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                    dgOrdenes.Rows[rowIndex].Cells["producto"].Value = ord.PRODUCTO;
                    dgOrdenes.Rows[rowIndex].Cells["motivo"].Value = ord.MOTIVO;
                    dgOrdenes.Rows[rowIndex].Cells["duracion"].Value = ord.DURACION;
                    dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                    dgOrdenes.Rows[rowIndex].Cells["revision"].Value = ord.REVISION;
                    dgOrdenes.Rows[rowIndex].Cells["activa"].Value = ord.ACTIVA;
                    dgOrdenes.Rows[rowIndex].Cells["agencia"].Value = ord.AGENCIA;



                }

                Cursor.Current = Cursors.Default;


            }
            catch (Exception ex)
            {

                MessageBox.Show("El criterio no tiene resultados pruebe otras opciones", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
