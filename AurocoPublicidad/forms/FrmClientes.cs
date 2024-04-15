using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, System.EventArgs e)
        {
            cargarClientes();
        }


        private async void cargarClientes()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/clientes");
            List<models.request.Cliente> lst = JsonConvert.DeserializeObject<List<models.request.Cliente>>(respuesta);



            DgClientes.Rows.Clear();

            foreach (Cliente ord in lst)
            {
                int rowIndex = DgClientes.Rows.Add();
                DgClientes.Rows[rowIndex].Cells["codigo"].Value = ord.C_CLIENTE;
                DgClientes.Rows[rowIndex].Cells["razon"].Value = ord.RAZON_SOCIAL;
                DgClientes.Rows[rowIndex].Cells["ruc"].Value = ord.RUC;

            }

        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

    }
}
