using AurocoPublicidad.forms;
using AurocoPublicidad.models.request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AurocoPublicidad
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://aprendeadistancia.online/api-auroco/login";
            UsuarioRequest usuarioR = new UsuarioRequest();
            usuarioR.usuario = txtNombre.Text;
            usuarioR.password = txtPassword.Text;
            string resultado = Send<UsuarioRequest>(url, usuarioR, "POST");

            JObject jObject = JObject.Parse(resultado);
            JToken objeto = jObject["status"];
            string nombre = (string) objeto;

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



        public string Send<T>(string url,T ObjectRequest,string method = "POST")
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
            catch(Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
