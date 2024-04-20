using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
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

namespace AurocoPublicidad.forms
{
    public partial class FrmEjecutivo : Form
    {
        int pos;
        Boolean nuevo = true;
        public FrmEjecutivo()
        {
            InitializeComponent();
        }

      
        private void FrmEjecutivo_Load(object sender, EventArgs e)
        {
            cargarEjecutivos();
        }


        private async void cargarEjecutivos()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/ejecutivos");
            List<models.request.Ejecutivo> lst = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(respuesta);




            DgEjecutivos.Rows.Clear();

            foreach (Ejecutivo eje in lst)
            {
                int rowIndex = DgEjecutivos.Rows.Add();
                DgEjecutivos.Rows[rowIndex].Cells["codigo"].Value = eje.C_EJECUTIVO;
                DgEjecutivos.Rows[rowIndex].Cells["nombre"].Value = eje.NOMBRES;
                DgEjecutivos.Rows[rowIndex].Cells["dni"].Value = eje.DNI_EJECUTIVO;
                DgEjecutivos.Rows[rowIndex].Cells["usuario"].Value = eje.USUARIO;
                DgEjecutivos.Rows[rowIndex].Cells["fcreacion"].Value = eje.F_CREACION;

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


            if ((!string.IsNullOrWhiteSpace(txtNombre.Text)) && (!string.IsNullOrWhiteSpace(txtDNI.Text)))
            {

                string url = Global.servicio + "/api-auroco/ejecutivo";
                Ejecutivo ejecutivo = new Ejecutivo();
                ejecutivo.C_EJECUTIVO = txtCodigo.Text;
                ejecutivo.NOMBRES= txtNombre.Text;
                ejecutivo.DNI_EJECUTIVO= txtDNI.Text;
ejecutivo.USUARIO = Global.sessionUsuario.ToString().ToUpper();


                string resultado = Send<Ejecutivo>(url, ejecutivo, metodo);

                JObject jObject = JObject.Parse(resultado);
                JToken objeto = jObject["status"];
                string status = (string)objeto;

                if (status == "True")
                {
                    MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nuevo = true;
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtDNI.Text = "";
                   btnGuardar.Text = "Guardar";
                 
                    cargarEjecutivos();
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

        private void DdEjecutivos_DoubleClick(object sender, EventArgs e)
        {
            nuevo = false;
            btnGuardar.Text = "&Actualizar";
            pos = DgEjecutivos.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(DgEjecutivos[0, pos].Value);
            txtNombre.Text = Convert.ToString(DgEjecutivos[1, pos].Value);
            txtDNI.Text = Convert.ToString(DgEjecutivos[2, pos].Value);
            
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nuevo = true;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDNI.Text = "";
            btnGuardar.Text = "Guardar";
        }
    }
}
