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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FrmEjecutivo : Form
    {
        public FrmEjecutivo()
        {
            InitializeComponent();
        }

        private void DgMedios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmEjecutivo_Load(object sender, EventArgs e)
        {
            cargarEjecutivos();
        }


        private async void cargarEjecutivos()
        {
            string respuesta = await GetService(Global.servicio + "/api-auroco/ejecutivos");
            List<models.request.Ejecutivo> lst = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(respuesta);




            DgMedios.Rows.Clear();

            foreach (Ejecutivo eje in lst)
            {
                int rowIndex = DgMedios.Rows.Add();
                DgMedios.Rows[rowIndex].Cells["codigo"].Value = eje.C_EJECUTIVO;
                DgMedios.Rows[rowIndex].Cells["nombre"].Value = eje.NOMBRES;
                DgMedios.Rows[rowIndex].Cells["dni"].Value = eje.DNI_EJECUTIVO;
                DgMedios.Rows[rowIndex].Cells["usuario"].Value = eje.USUARIO;
                DgMedios.Rows[rowIndex].Cells["fcreacion"].Value = eje.F_CREACION;

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
