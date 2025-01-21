using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AurocoPublicidad.forms
{

    public partial class FrmContratos : Form
    {

        System.Windows.Forms.Button button = new System.Windows.Forms.Button();
        int pos;
        Boolean nuevo = true;
        String metodo;
        public FrmContratos()
        {
            InitializeComponent();
        }


        private async void FrmContratos_Load(object sender, EventArgs e)
        {
            //comboCliente.AutoCompleteCustomSource = cargarDatosAPI();
            comboCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCliente.KeyDown += ComboBoxAutocomplete_TextChanged;

            string clientes = await GetService(Global.servicio+ "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            

            string monedas = await GetService(Global.servicio + "/api-auroco/monedas");
            List<models.request.Monedas> lstM = JsonConvert.DeserializeObject<List<models.request.Monedas>>(monedas);
            comboMoneda.DataSource = lstM;
            comboMoneda.DisplayMember = "NOMBRE";
            comboMoneda.ValueMember = "VALOR";
            DgContratos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            cargarContratos();
            

        }

        private async void fillClientes()
        {
            Cursor.Current = Cursors.WaitCursor;
            string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            Cursor.Current = Cursors.Default;
        }

        private async  void ComboBoxAutocomplete_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && comboCliente.Text!="") {
                Cursor.Current = Cursors.WaitCursor;
                string clientes = await GetService(Global.servicio + "/api-auroco/cliente_buscar/"+comboCliente.Text);
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
                comboCliente.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            if(e.KeyCode == Keys.Enter && comboCliente.Text == "")
            {
                fillClientes(); 
            }
           
            
            
        }

        private async void cargarContratos()
        {
           Cursor.Current = Cursors.WaitCursor;

            string respuesta = await GetService(Global.servicio + "/api-auroco/contratos");
            List<models.request.Contrato> lst = JsonConvert.DeserializeObject<List<models.request.Contrato>>(respuesta);

   

            DgContratos.Rows.Clear();
         
            foreach (Contrato ord in lst)
            {
              
                int rowIndex = DgContratos.Rows.Add();
                DgContratos.Rows[rowIndex].Cells["codigo"].Value = ord.ID;
                DgContratos.Rows[rowIndex].Cells["contrato"].Value = ord.C_CONTRATO;
                DgContratos.Rows[rowIndex].Cells["cliente"].Value = ord.C_CLIENTE;
                DgContratos.Rows[rowIndex].Cells["razon_social"].Value = ord.RAZON_SOCIAL;
                DgContratos.Rows[rowIndex].Cells["inicioVigencia"].Value = ord.INICIO_VIGENCIA;
                DgContratos.Rows[rowIndex].Cells["finVigencia"].Value = ord.FIN_VIGENCIA;
                DgContratos.Rows[rowIndex].Cells["saldo"].Value = ord.SALDO;
                DgContratos.Rows[rowIndex].Cells["nrofisico"].Value = ord.NRO_FISICO;
                DgContratos.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                DgContratos.Rows[rowIndex].Cells["monto"].Value = ord.INVERSION;
                DgContratos.Rows[rowIndex].Cells["tipocambio"].Value = ord.TIPO_CAMBIO;
                DgContratos.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                DgContratos.Rows[rowIndex].Cells["usuario"].Value = ord.C_USUARIO.ToUpper();
                DgContratos.Rows[rowIndex].Cells["fecha"].Value = ord.F_CREACION;
                DgContratos.Rows[rowIndex].Cells["tcambio"].Value = ord.TIPO_CAMBIO;

            }
           Cursor.Current = Cursors.Default;
        }

            private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

      
        private async void button1_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                metodo = "POST";

            }
            else
            {
                metodo = "PUT";
            }


                if ((!string.IsNullOrWhiteSpace(txtNroFisico.Text)) && (!string.IsNullOrWhiteSpace(comboCliente.Text))
                && (!string.IsNullOrWhiteSpace(comboMoneda.Text))
                            )
            {

                string url = Global.servicio + "/api-auroco/contrato";
                Contrato contratoR = new Contrato();
                contratoR.ID= txtCodigo.Text;
                contratoR.NRO_FISICO = txtNroFisico.Text;
                contratoR.C_CLIENTE = comboCliente.SelectedValue.ToString();
                contratoR.INICIO_VIGENCIA = this.dataFechaInicio.Value.ToString("yyyy-MM-dd");
                contratoR.FIN_VIGENCIA = this.dataFechaFin.Value.ToString("yyyy-MM-dd");
                contratoR.C_MONEDA = comboMoneda.Text;
                contratoR.TIPO_CAMBIO = Convert.ToDecimal(txtTipoCambio.Text);
                contratoR.INVERSION = Convert.ToDecimal(txtMonto.Text);
                contratoR.OBSERVACIONES = txtObservaciones.Text;
                contratoR.C_USUARIO = Global.sessionUsuario.ToString();
                      

            string resultado =  Send<Contrato>(url, contratoR, metodo);

            JObject jObject = JObject.Parse(resultado);
            JToken objeto = jObject["status"];
            string status= (string)objeto;

            if (status == "True")
            {
                MessageBox.Show( (string) jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Form childForm = new MDIPrincipal();
                    //childForm.Show();
                    //this.Hide();
                    nuevo = true;
                    txtCodigo.Text = "";
                    txtTipoCambio.Text = "";
                    txtMonto.Text = "";
                    txtSaldo.Text = "";
                    txtObservaciones.Text = "";
                    txtNroFisico.Text = ""; 
                    btnGuardar.Text = "Guardar";
                    comboCliente.SelectedIndex = 0;
                    dataFechaInicio.Value=DateTime.Now;
                    dataFechaFin.Value = DateTime.Now;



                    cargarContratos();


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

        private void DgContratos_DoubleClick(object sender, EventArgs e)
        {
            nuevo = false;
            btnGuardar.Text = "&Actualizar";
            pos = DgContratos.CurrentRow.Index;
            comboMoneda.SelectedText=null;
            txtCodigo.Text = Convert.ToString(DgContratos[1, pos].Value);
        
            comboCliente.SelectedValue = Convert.ToString(DgContratos[2, pos].Value);


            string simboloMoneda = "";
            if (Convert.ToString(DgContratos[8, pos].Value) == "Soles")
            {
                simboloMoneda = "S/";
            }
            else
            {
                simboloMoneda = "$";
            }

            txtSaldo.Text = string.Format("{0}{1:N2}", simboloMoneda, Convert.ToString(DgContratos[6, pos].Value));
            //txtMonto.Text = string.Format("{0}{1:N2}", simboloMoneda, Convert.ToString(DgContratos[9, pos].Value)); 
            txtMonto.Text = Convert.ToString(DgContratos[9, pos].Value);


            txtNroFisico.Text= Convert.ToString(DgContratos[7, pos].Value);
            comboMoneda.SelectedValue = Convert.ToString(DgContratos[8, pos].Value);
            
           
            dataFechaInicio.Value= Convert.ToDateTime(DgContratos[4, pos].Value);
            dataFechaFin.Value = Convert.ToDateTime(DgContratos[5, pos].Value);
            txtTipoCambio.Text = Convert.ToString(DgContratos[10, pos].Value);
            txtObservaciones.Text=Convert.ToString(DgContratos[11, pos].Value);
            
        }

   
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DgContratos.Rows.Clear();
                string url = Global.servicio + "/api-auroco/buscacontratos";
                Contrato contrato = new Contrato();
                contrato.RAZON_SOCIAL = textoRazon.Text;
                string resultado = Send<Contrato>(url, contrato, "POST");
                List<models.request.Contrato> lst = JsonConvert.DeserializeObject<List<models.request.Contrato>>(resultado);

                if (lst.Count > 0)
                {
                    foreach (Contrato ord in lst)
                    {
                        int rowIndex = DgContratos.Rows.Add();
                        DgContratos.Rows[rowIndex].Cells["codigo"].Value = ord.ID;
                        DgContratos.Rows[rowIndex].Cells["contrato"].Value = ord.C_CONTRATO;
                        DgContratos.Rows[rowIndex].Cells["cliente"].Value = ord.C_CLIENTE;
                        DgContratos.Rows[rowIndex].Cells["razon_social"].Value = ord.RAZON_SOCIAL;
                        DgContratos.Rows[rowIndex].Cells["inicioVigencia"].Value = ord.INICIO_VIGENCIA;
                        DgContratos.Rows[rowIndex].Cells["finVigencia"].Value = ord.FIN_VIGENCIA;
                        DgContratos.Rows[rowIndex].Cells["saldo"].Value = ord.SALDO;
                        DgContratos.Rows[rowIndex].Cells["nrofisico"].Value = ord.NRO_FISICO;
                        DgContratos.Rows[rowIndex].Cells["moneda"].Value = ord.C_MONEDA;
                        DgContratos.Rows[rowIndex].Cells["monto"].Value = ord.INVERSION;
                        DgContratos.Rows[rowIndex].Cells["tipocambio"].Value = ord.TIPO_CAMBIO;
                        DgContratos.Rows[rowIndex].Cells["observaciones"].Value = ord.OBSERVACIONES;
                        DgContratos.Rows[rowIndex].Cells["usuario"].Value = ord.C_USUARIO;
                        DgContratos.Rows[rowIndex].Cells["fecha"].Value = ord.F_CREACION;

                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados de la busqueda: " + textoRazon.Text, "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Aviso",ex.Message);
                Cursor.Current = Cursors.Default;

            }
            Cursor.Current = Cursors.Default;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgContratos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DgContratos.Columns["monto"].Index && e.Value != null)
            {


                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {

                    string monedaFormateada = "";
                    string simboloMoneda = "";


                    {

                        switch ((string)this.DgContratos.Rows[e.RowIndex].Cells["moneda"].Value)
                        {

                            case "Soles":

                                simboloMoneda = "S/."; // Símbolo del Nuevo Sol peruano

                                break;


                            case "Dolares":
                                simboloMoneda = "$"; // Símbolo del dólar estadounidense

                                break;

                        }



                        // Aplicar formato de moneda según la moneda deseada


                        // Seleccionar el símbolo de la moneda según el caso (dólares o soles)






                        // Aplicar formato de moneda con el símbolo seleccionado
                        monedaFormateada = string.Format("{0}{1:N2}", simboloMoneda, valor); // "N2" indica dos dígitos decimales

                        e.Value = monedaFormateada;
                        e.FormattingApplied = true; // Indicar que se ha aplicado el formato

                    }
                }
            }


            if (e.ColumnIndex == DgContratos.Columns["saldo"].Index && e.Value != null)
            {


                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {

                    string monedaFormateada = "";
                    string simboloMoneda = "";


                    {

                        switch ((string)this.DgContratos.Rows[e.RowIndex].Cells["moneda"].Value)
                        {

                            case "Soles":

                                simboloMoneda = "S/"; // Símbolo del Nuevo Sol peruano

                                break;


                            case "Dolares":
                                simboloMoneda = "$"; // Símbolo del dólar estadounidense

                                break;

                        }



                        // Aplicar formato de moneda según la moneda deseada


                        // Seleccionar el símbolo de la moneda según el caso (dólares o soles)






                        // Aplicar formato de moneda con el símbolo seleccionado
                        monedaFormateada = string.Format("{0}{1:N2}", simboloMoneda, valor); // "N2" indica dos dígitos decimales

                        e.Value = monedaFormateada;
                        e.FormattingApplied = true; // Indicar que se ha aplicado el formato

                    }
                }
            }

        }

          private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if(comboCliente.Text.Length > 0) {
            Cursor.Current = Cursors.WaitCursor;
            string clientes = await GetService(Global.servicio + "/api-auroco/cliente_buscar/" + comboCliente.Text);
            List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes);
            comboCliente.DataSource = lstC;
            comboCliente.DisplayMember = "RAZON_SOCIAL";
            comboCliente.ValueMember = "C_CLIENTE";
            comboCliente.DroppedDown = true;
            Cursor.Current = Cursors.Default;
        }
            if(comboCliente.Text == "")
            {
                fillClientes(); 
            }

            //fillClientes();
        }
    }



}
