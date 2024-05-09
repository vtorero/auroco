using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static AurocoPublicidad.forms.FrmOrden;

namespace AurocoPublicidad.forms
{
    public partial class FrmMedio : Form
    {
        int pos;
        Boolean nuevo = true;
        public FrmMedio()
        {
            InitializeComponent();
        }

        private void FrmMedio_Load(object sender, EventArgs e)
        {
            cargarMedios();

            cmbTipo.Items.Add(new ListItem("0", "Seleccionar"));
            cmbTipo.Items.Add(new ListItem("TELEVISIÓN", "TELEVISIÓN"));
            cmbTipo.Items.Add(new ListItem("RADIO", "RADIO"));
            // Seleccionar el primer elemento por defecto
            cmbTipo.SelectedIndex = 0;

        }
        private async void cargarMedios()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/medios");
            List<models.request.Medio> lst = JsonConvert.DeserializeObject<List<models.request.Medio>>(respuesta);




            DgMedios.Rows.Clear();

            foreach (Medio med in lst)
            {
                int rowIndex = DgMedios.Rows.Add();
                DgMedios.Rows[rowIndex].Cells["codigo"].Value = med.C_MEDIO;
                DgMedios.Rows[rowIndex].Cells["nombre"].Value = med.NOMBRE;
                DgMedios.Rows[rowIndex].Cells["descripcion"].Value = med.DESCRIPCION;
                DgMedios.Rows[rowIndex].Cells["tipo"].Value = med.TIPO.ToUpper();
                DgMedios.Rows[rowIndex].Cells["usuario"].Value = med.C_USUARIO_CREACION;
                DgMedios.Rows[rowIndex].Cells["fcreacion"].Value = med.F_CREACION;

            }
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
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


            if ((!string.IsNullOrWhiteSpace(txtNombre.Text)) && (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
            && (cmbTipo.SelectedIndex != 0 )
                        )
            {

                string url = Global.servicio + "/api-auroco/medio";
                Medio medio = new Medio();
                medio.C_MEDIO = txtCodigo.Text;
                medio.NOMBRE= txtNombre.Text;
                medio.DESCRIPCION= txtDescripcion.Text;
                medio.TIPO= cmbTipo.SelectedItem.ToString().ToUpper();  
                medio.C_USUARIO_CREACION= Global.sessionUsuario.ToString().ToUpper();


                string resultado = Send<Medio>(url, medio, metodo);

                JObject jObject = JObject.Parse(resultado);
                JToken objeto = jObject["status"];
                string status = (string)objeto;

                if (status == "True")
                {
                    MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    nuevo = true;
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    cmbTipo.Text = "";
                    btnGuardar.Text = "Guardar";
                    cmbTipo.SelectedIndex = 0;
                    cargarMedios();
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

        private void DgMedios_DoubleClick(object sender, EventArgs e)
        {
            nuevo = false;
            btnGuardar.Text = "&Actualizar";
            pos = DgMedios.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(DgMedios[0, pos].Value);
            txtNombre.Text = Convert.ToString(DgMedios[1, pos].Value);
            txtDescripcion.Text = Convert.ToString(DgMedios[2, pos].Value);
            string tipoo= Convert.ToString(DgMedios[3, pos].Value);
            if (tipoo == "TELEVISIÓN")
                cmbTipo.SelectedIndex = 1;
            else if (tipoo== "RADIO")
                cmbTipo.SelectedIndex = 2;
            else
                cmbTipo.SelectedIndex = 0;


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nuevo = true;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cmbTipo.Text = "";
            btnGuardar.Text = "&Guardar";
            cmbTipo.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DgMedios.Rows.Clear();
            string url = Global.servicio + "/api-auroco/buscamedio";
            Medio medio= new Medio();
            medio.NOMBRE = textoNombre.Text;
            string resultado = Send<Medio>(url, medio, "POST");
            List<models.request.Medio> lst = JsonConvert.DeserializeObject<List<models.request.Medio>>(resultado);


            DgMedios.Rows.Clear();

            foreach (Medio med in lst)
            {
                int rowIndex = DgMedios.Rows.Add();
                DgMedios.Rows[rowIndex].Cells["codigo"].Value = med.C_MEDIO;
                DgMedios.Rows[rowIndex].Cells["nombre"].Value = med.NOMBRE;
                DgMedios.Rows[rowIndex].Cells["descripcion"].Value = med.DESCRIPCION;
                DgMedios.Rows[rowIndex].Cells["tipo"].Value = med.TIPO.ToUpper();
                DgMedios.Rows[rowIndex].Cells["usuario"].Value = med.C_USUARIO_CREACION;
                DgMedios.Rows[rowIndex].Cells["fcreacion"].Value = med.F_CREACION;

            }
        }
    }
}
