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
    public partial class FrmPrograma : Form
    {
        int pos;
        Boolean nuevo = true;
        public FrmPrograma()
        {
            InitializeComponent();
        }

        private async void FrmPrograma_Load(object sender, EventArgs e)
        {
            string medios = await GetService(Global.servicio + "/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
            List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios);
            comboMedio.DataSource = lstM;
            comboMedio.DisplayMember = "NOMBRE";
            comboMedio.ValueMember = "NOMBRE";
            comboMedio.SelectedValue = "0";
          /*  if (valorRecibido != "")
            {
                comboMedio.SelectedValue = valorRecibido;
                btnGuardar.Enabled = true;
                btnGuardar.Text = "&Actualizar";
            }*/

            cargarProgramas();
        }
     

        private async void cargarProgramas()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/programas");
            List<models.request.Programa> lst = JsonConvert.DeserializeObject<List<models.request.Programa>>(respuesta);




            DgProgramas.Rows.Clear();

            foreach (Programa med in lst)
            {
                int rowIndex = DgProgramas.Rows.Add();
                DgProgramas.Rows[rowIndex].Cells["codigo"].Value = med.ID;
                DgProgramas.Rows[rowIndex].Cells["nombre"].Value = med.PROGRAMA;
                DgProgramas.Rows[rowIndex].Cells["canal"].Value = med.CANAL;
                DgProgramas.Rows[rowIndex].Cells["dias"].Value = med.DIAS;
                DgProgramas.Rows[rowIndex].Cells["horario"].Value = med.PERIODO;
                DgProgramas.Rows[rowIndex].Cells["costo"].Value = med.COSTO;
                DgProgramas.Rows[rowIndex].Cells["usuario"].Value = med.C_USUARIO;
                DgProgramas.Rows[rowIndex].Cells["fcreacion"].Value = med.F_CREACION;
                DgProgramas.Rows[rowIndex].Cells["estado"].Value = med.ESTADO;

            }
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void DgProgramas_DoubleClick(object sender, EventArgs e)
        {
            nuevo = false;
            btnGuardar.Text = "&Actualizar";
            pos = DgProgramas.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(DgProgramas[0, pos].Value);
            txtPrograma.Text = Convert.ToString(DgProgramas[1, pos].Value);
            txtDia.Text = Convert.ToString(DgProgramas[3, pos].Value);
            txtHorario.Text = Convert.ToString(DgProgramas[4, pos].Value);
            comboMedio.SelectedValue = Convert.ToString(DgProgramas[2, pos].Value);
            string est = Convert.ToString(DgProgramas[8, pos].Value);
            if(est == "SI")
            {
                chkEstado.Checked = true;
            }
            else
            {
                chkEstado.Checked = false;
            }



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


            if ((!string.IsNullOrWhiteSpace(txtPrograma.Text)) && (!string.IsNullOrWhiteSpace(txtHorario.Text))
            && (comboMedio.SelectedIndex != 0)
                        )
            {

                string url = Global.servicio + "/api-auroco/programa";
                Programa programa = new Programa();
                programa.ID = txtCodigo.Text; 
                programa.PROGRAMA = txtPrograma.Text;
                programa.CANAL = comboMedio.SelectedValue.ToString();
                programa.PERIODO = txtHorario.Text;
                programa.COSTO = Convert.ToDecimal(txtCosto.Text);
                programa.DIAS=txtDia.Text;
                if(chkEstado.Checked) {
                    programa.ESTADO = "SI";
                }
                else
                {
                    programa.ESTADO = "NO";
                }
                
                programa.C_USUARIO = Global.sessionUsuario.ToString().ToUpper();


                string resultado = Send<Programa>(url, programa, metodo);

                JObject jObject = JObject.Parse(resultado);
                JToken objeto = jObject["status"];
                string status = (string)objeto;

                if (status == "True")
                {
                    MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nuevo = true;
                    txtCodigo.Text = "";
                    txtPrograma.Text = "";
                    txtDia.Text = "";
                    txtHorario.Text = "00:00:00";
                    btnGuardar.Text = "Guardar";
                    txtCosto.Text = "0.00";
                    comboMedio.SelectedIndex = 0;
                    chkEstado.Checked = false;  
                    cargarProgramas();
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

    }
}
