using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AurocoPublicidad.forms
{
    public partial class frmFacturado : Form
    {
        public frmFacturado()
        {
            InitializeComponent();
        }

        private async void frmFacturado_Load(object sender, EventArgs e)
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
            string apiUrl = Global.servicio + "/api-auroco/facturados";
            using (HttpClient client = new HttpClient())

            {
                try
                {
                

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
                       
                        int rowIndex = dgOrdenes.Rows.Add();
                        dgOrdenes.Rows[rowIndex].Cells["C_ORDEN"].Value = ord.C_ORDEN;
                        dgOrdenes.Rows[rowIndex].Cells["C_CLIENTE"].Value = ord.RAZON_SOCIAL;
                        dgOrdenes.Rows[rowIndex].Cells["C_RUC"].Value = ord.C_RUC;
                        dgOrdenes.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                        dgOrdenes.Rows[rowIndex].Cells["total"].Value = ord.TOTAL;
                        dgOrdenes.Rows[rowIndex].Cells["agencia"].Value = ord.AGENCIA;
                        dgOrdenes.Rows[rowIndex].Cells["fecha"].Value = ord.F_CREACION;
                        dgOrdenes.Rows[rowIndex].Cells["estado"].Value = ord.EJECUTIVO;
                        dgOrdenes.Rows[rowIndex].Cells["mensaje"].Value = ord.MOTIVO;


                        if (contador % 5 == 0 || contador == total)
                        {
                            dgOrdenes.DataSource = null;
                            // dgOrdenes.DataSource = new List<Ordenes>(content);
                        }

                    }
                 //   lblPorcentaje.Text = "¡Carga completa!";
                    await Task.Delay(50);
                   // lblPorcentaje.Visible = false;
                   // progressBar1.Visible = false;
                    Cursor.Current = Cursors.Default;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
