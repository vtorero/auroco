using Newtonsoft.Json;
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
            string respuesta = await GetService("https://aprendeadistancia.online/api-auroco/ordenes");
            List<models.request.Ordenes> lst = JsonConvert.DeserializeObject<List<models.request.Ordenes>>(respuesta);
            dgOrdenes.DataSource = lst;
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
            int pos;
            pos = dgOrdenes.CurrentRow.Index;
            //MessageBox.Show(dgOrdenes[1, pos].Value.ToString());



            FrmOrden frmOrden = new FrmOrden(dgOrdenes[1, pos].Value.ToString()/*, otros datos si es necesario */);
            frmOrden.ShowDialog();

        }
    }
}
