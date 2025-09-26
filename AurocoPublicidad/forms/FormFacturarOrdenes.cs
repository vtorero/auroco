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
            string apiUrl = Global.servicio + "/api-auroco/facturar";
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
                       // await Task.Delay(50);
                        contador++;
                        int porcentaje = (int)((contador * 100.0) / total);
                        progressBar1.Value = porcentaje;
                        lblPorcentaje.Text = $"{porcentaje}%";
                        lblPorcentaje.Refresh();

                        int rowIndex = dgOrdenes.Rows.Add();
                        dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                        dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                        dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                        dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                        dgOrdenes.Rows[rowIndex].Cells["CLIENTE"].Value = ord.RAZON_SOCIAL;
                        dgOrdenes.Rows[rowIndex].Cells["C_RUC"].Value = ord.C_RUC;
                        dgOrdenes.Rows[rowIndex].Cells["f_creacion"].Value = ord.F_CREACION;
                        dgOrdenes.Rows[rowIndex].Cells["f_inicio"].Value = ord.INICIO_VIGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["f_fin"].Value = ord.FIN_VIGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                        dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                        dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                        dgOrdenes.Rows[rowIndex].Cells["tipoCambio"].Value = ord.TIPO_CAMBIO;
                        if (contador % 5 == 0 || contador == total)
                        {
                            dgOrdenes.DataSource = null;
                           // dgOrdenes.DataSource = new List<Ordenes>(content);
                        }

                    }
                    lblPorcentaje.Text = "¡Carga completa!";
                    await Task.Delay(50);
                    lblPorcentaje.Visible = false;
                    progressBar1.Visible = false;
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
            EditarOrden();
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
                var idOrden = dgOrdenes[0, pos].Value.ToString();
                var ccontrato = dgOrdenes[1, pos].Value.ToString();
                var idCliente = dgOrdenes[2, pos].Value.ToString();
                var ruc = dgOrdenes[4, pos].Value.ToString();
                var fcreacion = dgOrdenes[5, pos].Value.ToString();
                
                var moneda = dgOrdenes[8, pos].Value.ToString();
                var totalOrden = dgOrdenes[9, pos].Value.ToString();
                var observaciones = dgOrdenes[10, pos].Value.ToString();
                var tipo_cambio = dgOrdenes[11, pos].Value.ToString();
                FrmFacturar frmFacturar = new FrmFacturar(idOrden,ccontrato, idCliente,ruc,fcreacion, observaciones,moneda,totalOrden, tipo_cambio);
                frmFacturar.FormClosed += (s, args) => cargaOrdenes();

                frmFacturar.ShowDialog();
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
                string url = Global.servicio + "/api-auroco/buscafacturas";
                Ordenes orden = new Ordenes();
                orden.C_CLIENTE = comboCliente.SelectedValue.ToString();
                               orden.INICIO_VIGENCIA = dtDesde.Value.ToString();
                orden.FIN_VIGENCIA = dtHasta.Value.ToString();
                orden.C_CONTRATO = txtOrden.Text;
                string resultado = Send<Ordenes>(url, orden, "POST");
                List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(resultado);

                foreach (Ordenes ord in lst)
                {
                    int rowIndex = dgOrdenes.Rows.Add();
                    dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                    dgOrdenes.Rows[rowIndex].Cells["C_CONTRATO"].Value = ord.C_CONTRATO;
                    dgOrdenes.Rows[rowIndex].Cells["ID"].Value = ord.ID;
                    dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.C_CLIENTE;
                    dgOrdenes.Rows[rowIndex].Cells["CLIENTE"].Value = ord.RAZON_SOCIAL;
                    dgOrdenes.Rows[rowIndex].Cells["C_RUC"].Value = ord.C_RUC;
                    dgOrdenes.Rows[rowIndex].Cells["f_creacion"].Value = ord.F_CREACION;
                    dgOrdenes.Rows[rowIndex].Cells["f_inicio"].Value = ord.INICIO_VIGENCIA;
                    dgOrdenes.Rows[rowIndex].Cells["f_fin"].Value = ord.FIN_VIGENCIA;
                    dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                    dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                    dgOrdenes.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                    dgOrdenes.Rows[rowIndex].Cells["tipoCambio"].Value = ord.TIPO_CAMBIO;

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargaOrdenes();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtOrden_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
