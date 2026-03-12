using AurocoPublicidad.models.request;
using AurocoPublicidad.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class FrmOrden : Form
    {
        private string valorRecibido;
        private string valorIdOrden;
        private string valorCliente;
        private string valorContrato;
        private int valorRevision;
        private string valorEjecutivo;
        private string valorFecha;
        private string valorInicio;
        private string valorFin;
        private string valorMoneda;
        private string valorTotal;
        private string valorProducto;
        private string valorMotivo;
        private string valorDuracion;
        private string valorObservaciones;
        private string valorAgencia;

        private string apiUrl = Global.servicio + "/api-auroco/orden";

        public FrmOrden(
            string id,
            string medio,
            string cliente,
            string contrato,
            int revision,
            string ejecutivo,
            string fecha,
            string fechainicio,
            string fechafin,
            string moneda,
            string total,
            string producto,
            string motivo,
            string duracion,
            string observaciones,
            string agencia)
        {
            InitializeComponent();

            valorIdOrden = id;
            valorRecibido = medio;
            valorRevision = revision;
            valorCliente = cliente;
            valorContrato = contrato;
            valorEjecutivo = ejecutivo;
            valorFecha = fecha;
            valorInicio = fechainicio;
            valorFin = fechafin;
            valorMoneda = moneda;
            valorTotal = total;
            valorProducto = producto;
            valorMotivo = motivo;
            valorDuracion = duracion;
            valorAgencia = agencia;
            valorObservaciones = observaciones;

            if (id != "")
            {
                LblNumero.Visible = true;
                txtNumero.Visible = true;
                chkRevisar.Visible = true;
                numRevision.Visible = true;
                labelRevision.Visible = true;
                txtNumero.Text = id;
                btnPrint.Visible = true;
                numRevision.Value = valorRevision;
                pintaDias();
            }
            else
            {
                LblNumero.Visible = false;
                txtNumero.Visible = false;
                numRevision.Visible = false;
                labelRevision.Visible = false;
                chkRevisar.Visible = false;
                btnPrint.Visible = false;
                txtNumero.Text = "";

                DateTime primerDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime ultimoDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                inicioVigencia.Value = primerDiaDelMes;
                finVigencia.Value = ultimoDiaDelMes;
                pintaDias();
            }

            dataGridOrden.EditingControlShowing += dataGridOrden_EditingControlShowing;
        }

        private async void FrmOrden_Load(object sender, EventArgs e)
        {
            try
            {
                comboCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboCliente.KeyDown += ComboBoxAutocomplete_TextChanged;

                string simboloMoneda = valorMoneda == "Soles" ? "S/." : "$";
                double igv = 0;
                double totalOrd = 0;

                if (!string.IsNullOrWhiteSpace(valorTotal))
                {
                    double totalTmp = ToDoubleSafe(valorTotal);
                    igv = totalTmp * 0.18;
                    totalOrd = totalTmp + igv;
                    totalOrden.Text = string.Format("{0}{1:N2}", simboloMoneda, totalTmp);
                    txtIgv.Text = string.Format("{0}{1:N2}", simboloMoneda, igv);
                    totalBruto.Text = string.Format("{0}{1:N2}", simboloMoneda, totalOrd);
                }

                if (!string.IsNullOrWhiteSpace(valorInicio))
                    inicioVigencia.Value = Convert.ToDateTime(valorInicio);

                if (!string.IsNullOrWhiteSpace(valorFin))
                    finVigencia.Value = Convert.ToDateTime(valorFin);

                if (!string.IsNullOrWhiteSpace(valorProducto))
                    textProducto.Text = valorProducto;

                if (!string.IsNullOrWhiteSpace(valorMotivo))
                    textMotivo.Text = valorMotivo;

                if (!string.IsNullOrWhiteSpace(valorDuracion))
                    textDuracion.Text = valorDuracion;

                if (!string.IsNullOrWhiteSpace(valorObservaciones))
                    textObservaciones.Text = valorObservaciones;

                string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
                List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes) ?? new List<models.request.Cliente>();
                comboCliente.DataSource = lstC;
                comboCliente.DisplayMember = "RAZON_SOCIAL";
                comboCliente.ValueMember = "C_CLIENTE";

                if (!string.IsNullOrWhiteSpace(valorCliente))
                    comboCliente.SelectedValue = valorCliente;

                string medios = await GetService(Global.servicio + "/api-auroco/tabla/ORD_MEDIOS/NOMBRE");
                List<models.request.Medio> lstM = JsonConvert.DeserializeObject<List<models.request.Medio>>(medios) ?? new List<models.request.Medio>();
                comboMedio.DataSource = lstM;
                comboMedio.DisplayMember = "NOMBRE";
                comboMedio.ValueMember = "C_MEDIO";

                if (!string.IsNullOrWhiteSpace(valorRecibido))
                {
                    comboMedio.SelectedValue = valorRecibido;
                    btnGuardar.Text = "&Actualizar";
                }

                string ejecutivos = await GetService(Global.servicio + "/api-auroco/tabla/ORD_EJECUTIVOS/NOMBRES");
                List<models.request.Ejecutivo> lstE = JsonConvert.DeserializeObject<List<models.request.Ejecutivo>>(ejecutivos) ?? new List<models.request.Ejecutivo>();
                cmbEjecutivo.DataSource = lstE;
                cmbEjecutivo.DisplayMember = "NOMBRES";
                cmbEjecutivo.ValueMember = "C_EJECUTIVO";

                if (!string.IsNullOrWhiteSpace(valorEjecutivo))
                    cmbEjecutivo.SelectedValue = valorEjecutivo;

                string monedas = await GetService(Global.servicio + "/api-auroco/monedas");
                List<models.request.Monedas> lstMo = JsonConvert.DeserializeObject<List<models.request.Monedas>>(monedas) ?? new List<models.request.Monedas>();
                comboCambio.DataSource = lstMo;
                comboCambio.DisplayMember = "NOMBRE";
                comboCambio.ValueMember = "VALOR";

                if (!string.IsNullOrWhiteSpace(valorMoneda))
                    comboCambio.SelectedValue = valorMoneda;

                comboIgv.Items.Clear();
                comboIgv.Items.Add(new ListItem("0", "Seleccionar"));
                comboIgv.Items.Add(new ListItem("Si", "Si"));
                comboIgv.Items.Add(new ListItem("No", "No"));
                comboIgv.SelectedIndex = 1;

                txtAgencia.Items.Clear();
                txtAgencia.Items.Add(new ListItem("0", "Seleccionar"));
                txtAgencia.Items.Add(new ListItem("AUROCO", "AUROCO"));
                txtAgencia.Items.Add(new ListItem("OPTIMIZA", "OPTIMIZA"));

                if (valorAgencia == "AUROCO")
                    txtAgencia.SelectedIndex = 1;
                else if (valorAgencia == "OPTIMIZA")
                    txtAgencia.SelectedIndex = 2;
                else
                    txtAgencia.SelectedIndex = 1;

                // Carga ordenada: primero programas, luego líneas
                if (!string.IsNullOrWhiteSpace(valorRecibido))
                    await cargaprograma(valorRecibido);

                if (!string.IsNullOrWhiteSpace(valorIdOrden))
                    await cargarLineas(valorIdOrden);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComboBoxAutocomplete_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && comboCliente.Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string clientes = await GetService(Global.servicio + "/api-auroco/cliente_buscar/" + comboCliente.Text);
                    List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes) ?? new List<models.request.Cliente>();
                    comboCliente.DataSource = lstC;
                    comboCliente.DisplayMember = "RAZON_SOCIAL";
                    comboCliente.ValueMember = "C_CLIENTE";
                    comboCliente.DroppedDown = true;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            if (e.KeyCode == Keys.Enter && comboCliente.Text == "")
            {
                fillClientes();
            }
        }

        private async void fillClientes()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string clientes = await GetService(Global.servicio + "/api-auroco/clientes_orden");
                List<models.request.Cliente> lstC = JsonConvert.DeserializeObject<List<models.request.Cliente>>(clientes) ?? new List<models.request.Cliente>();
                comboCliente.DataSource = lstC;
                comboCliente.DisplayMember = "RAZON_SOCIAL";
                comboCliente.ValueMember = "C_CLIENTE";
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void inicioVigencia_Validated(object sender, EventArgs e)
        {
            pintaDias();
        }

        private async Task<List<OrdenesLinea>> cargarLineas(string id)
        {
            dataGridOrden.Rows.Clear();

            string ordenes = await GetService(Global.servicio + "/api-auroco/orden/" + id);
            List<models.request.OrdenesLinea> lstC = JsonConvert.DeserializeObject<List<models.request.OrdenesLinea>>(ordenes) ?? new List<models.request.OrdenesLinea>();

            foreach (OrdenesLinea ord in lstC)
            {
                int rowIndex = dataGridOrden.Rows.Add();

                dataGridOrden.Rows[rowIndex].Cells["idprograma"].Value = ord.ID;

                if (dataGridOrden.Columns.Contains("programa"))
                    dataGridOrden.Rows[rowIndex].Cells["programa"].Value = ord.ID;

                dataGridOrden.Rows[rowIndex].Cells["horario"].Value = ord.TEMA;
                dataGridOrden.Rows[rowIndex].Cells["costo"].Value = ToDoubleSafe(ord.INVERSION_TOTAL);

                SetDayCellValue(rowIndex, "d1", ord.d1);
                SetDayCellValue(rowIndex, "d2", ord.d2);
                SetDayCellValue(rowIndex, "d3", ord.d3);
                SetDayCellValue(rowIndex, "d4", ord.d4);
                SetDayCellValue(rowIndex, "d5", ord.d5);
                SetDayCellValue(rowIndex, "d6", ord.d6);
                SetDayCellValue(rowIndex, "d7", ord.d7);
                SetDayCellValue(rowIndex, "d8", ord.d8);
                SetDayCellValue(rowIndex, "d9", ord.d9);
                SetDayCellValue(rowIndex, "d10", ord.d10);
                SetDayCellValue(rowIndex, "d11", ord.d11);
                SetDayCellValue(rowIndex, "d12", ord.d12);
                SetDayCellValue(rowIndex, "d13", ord.d13);
                SetDayCellValue(rowIndex, "d14", ord.d14);
                SetDayCellValue(rowIndex, "d15", ord.d15);
                SetDayCellValue(rowIndex, "d16", ord.d16);
                SetDayCellValue(rowIndex, "d17", ord.d17);
                SetDayCellValue(rowIndex, "d18", ord.d18);
                SetDayCellValue(rowIndex, "d19", ord.d19);
                SetDayCellValue(rowIndex, "d20", ord.d20);
                SetDayCellValue(rowIndex, "d21", ord.d21);
                SetDayCellValue(rowIndex, "d22", ord.d22);
                SetDayCellValue(rowIndex, "d23", ord.d23);
                SetDayCellValue(rowIndex, "d24", ord.d24);
                SetDayCellValue(rowIndex, "d25", ord.d25);
                SetDayCellValue(rowIndex, "d26", ord.d26);
                SetDayCellValue(rowIndex, "d27", ord.d27);
                SetDayCellValue(rowIndex, "d28", ord.d28);
                SetDayCellValue(rowIndex, "d29", ord.d29);
                SetDayCellValue(rowIndex, "d30", ord.d30);
                SetDayCellValue(rowIndex, "d31", ord.d31);

                double avisos = SumDias(ord);
                double costo = ToDoubleSafe(ord.INVERSION_TOTAL);
                double total = avisos * costo;

                dataGridOrden.Rows[rowIndex].Cells["avisos"].Value = avisos;
                dataGridOrden.Rows[rowIndex].Cells["total"].Value = total;
                dataGridOrden.Rows[rowIndex].Cells["totalcalculo"].Value = total;
            }

            foreach (DataGridViewRow row in dataGridOrden.Rows)
            {
                var cellValue = row.Cells["programa"]?.Value?.ToString();
                var codigo = row.Cells["idprograma"]?.Value?.ToString();

                if (!string.IsNullOrWhiteSpace(cellValue) && cellValue == codigo)
                {
                    row.Selected = true;
                    if (row.Cells["programa"] != null)
                    {
                        row.Cells["programa"].Selected = true;
                        dataGridOrden.CurrentCell = row.Cells["programa"];
                    }
                }
            }

            RecalcularTotalesGenerales();
            return lstC;
        }

        private void SetDayCellValue(int rowIndex, string cellName, string value)
        {
            if (dataGridOrden.Columns.Contains(cellName) && value != "0" && !string.IsNullOrWhiteSpace(value))
            {
                dataGridOrden.Rows[rowIndex].Cells[cellName].Value = ToDoubleSafe(value);
            }
        }

        private double SumDias(OrdenesLinea ord)
        {
            return ToDoubleSafe(ord.d1) + ToDoubleSafe(ord.d2) + ToDoubleSafe(ord.d3) + ToDoubleSafe(ord.d4) +
                   ToDoubleSafe(ord.d5) + ToDoubleSafe(ord.d6) + ToDoubleSafe(ord.d7) + ToDoubleSafe(ord.d8) +
                   ToDoubleSafe(ord.d9) + ToDoubleSafe(ord.d10) + ToDoubleSafe(ord.d11) + ToDoubleSafe(ord.d12) +
                   ToDoubleSafe(ord.d13) + ToDoubleSafe(ord.d14) + ToDoubleSafe(ord.d15) + ToDoubleSafe(ord.d16) +
                   ToDoubleSafe(ord.d17) + ToDoubleSafe(ord.d18) + ToDoubleSafe(ord.d19) + ToDoubleSafe(ord.d20) +
                   ToDoubleSafe(ord.d21) + ToDoubleSafe(ord.d22) + ToDoubleSafe(ord.d23) + ToDoubleSafe(ord.d24) +
                   ToDoubleSafe(ord.d25) + ToDoubleSafe(ord.d26) + ToDoubleSafe(ord.d27) + ToDoubleSafe(ord.d28) +
                   ToDoubleSafe(ord.d29) + ToDoubleSafe(ord.d30) + ToDoubleSafe(ord.d31);
        }

        private string pintaDias()
        {
            var fecha = inicioVigencia.Value;

            d1.HeaderCell.Style.ForeColor = Color.Red;
            dataGridOrden.Columns[4].HeaderCell.Style.ForeColor = Color.Red;

            d1.HeaderText = generico.traduceDia(fecha.DayOfWeek.ToString()) + " " + fecha.Day.ToString();
            d2.HeaderText = generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString()) + " " + fecha.AddDays(1).Day.ToString();
            d3.HeaderText = generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString()) + " " + fecha.AddDays(2).Day.ToString();
            d4.HeaderText = generico.traduceDia(fecha.AddDays(3).DayOfWeek.ToString()) + " " + fecha.AddDays(3).Day.ToString();
            d5.HeaderText = generico.traduceDia(fecha.AddDays(4).DayOfWeek.ToString()) + " " + fecha.AddDays(4).Day.ToString();
            d6.HeaderText = generico.traduceDia(fecha.AddDays(5).DayOfWeek.ToString()) + " " + fecha.AddDays(5).Day.ToString();
            d7.HeaderText = generico.traduceDia(fecha.AddDays(6).DayOfWeek.ToString()) + " " + fecha.AddDays(6).Day.ToString();
            d8.HeaderText = generico.traduceDia(fecha.AddDays(7).DayOfWeek.ToString()) + " " + fecha.AddDays(7).Day.ToString();
            d9.HeaderText = generico.traduceDia(fecha.AddDays(8).DayOfWeek.ToString()) + " " + fecha.AddDays(8).Day.ToString();
            d10.HeaderText = generico.traduceDia(fecha.AddDays(9).DayOfWeek.ToString()) + " " + fecha.AddDays(9).Day.ToString();
            d11.HeaderText = generico.traduceDia(fecha.AddDays(10).DayOfWeek.ToString()) + " " + fecha.AddDays(10).Day.ToString();
            d12.HeaderText = generico.traduceDia(fecha.AddDays(11).DayOfWeek.ToString()) + " " + fecha.AddDays(11).Day.ToString();
            d13.HeaderText = generico.traduceDia(fecha.AddDays(12).DayOfWeek.ToString()) + " " + fecha.AddDays(12).Day.ToString();
            d14.HeaderText = generico.traduceDia(fecha.AddDays(13).DayOfWeek.ToString()) + " " + fecha.AddDays(13).Day.ToString();
            d15.HeaderText = generico.traduceDia(fecha.AddDays(14).DayOfWeek.ToString()) + " " + fecha.AddDays(14).Day.ToString();
            d16.HeaderText = generico.traduceDia(fecha.AddDays(15).DayOfWeek.ToString()) + " " + fecha.AddDays(15).Day.ToString();
            d17.HeaderText = generico.traduceDia(fecha.AddDays(16).DayOfWeek.ToString()) + " " + fecha.AddDays(16).Day.ToString();
            d18.HeaderText = generico.traduceDia(fecha.AddDays(17).DayOfWeek.ToString()) + " " + fecha.AddDays(17).Day.ToString();
            d19.HeaderText = generico.traduceDia(fecha.AddDays(18).DayOfWeek.ToString()) + " " + fecha.AddDays(18).Day.ToString();
            d20.HeaderText = generico.traduceDia(fecha.AddDays(19).DayOfWeek.ToString()) + " " + fecha.AddDays(19).Day.ToString();
            d21.HeaderText = generico.traduceDia(fecha.AddDays(20).DayOfWeek.ToString()) + " " + fecha.AddDays(20).Day.ToString();
            d22.HeaderText = generico.traduceDia(fecha.AddDays(21).DayOfWeek.ToString()) + " " + fecha.AddDays(21).Day.ToString();
            d23.HeaderText = generico.traduceDia(fecha.AddDays(22).DayOfWeek.ToString()) + " " + fecha.AddDays(22).Day.ToString();
            d24.HeaderText = generico.traduceDia(fecha.AddDays(23).DayOfWeek.ToString()) + " " + fecha.AddDays(23).Day.ToString();
            d25.HeaderText = generico.traduceDia(fecha.AddDays(24).DayOfWeek.ToString()) + " " + fecha.AddDays(24).Day.ToString();
            d26.HeaderText = generico.traduceDia(fecha.AddDays(25).DayOfWeek.ToString()) + " " + fecha.AddDays(25).Day.ToString();
            d27.HeaderText = generico.traduceDia(fecha.AddDays(26).DayOfWeek.ToString()) + " " + fecha.AddDays(26).Day.ToString();
            d28.HeaderText = generico.traduceDia(fecha.AddDays(27).DayOfWeek.ToString()) + " " + fecha.AddDays(27).Day.ToString();
            d29.HeaderText = generico.traduceDia(fecha.AddDays(28).DayOfWeek.ToString()) + " " + fecha.AddDays(28).Day.ToString();
            d30.HeaderText = generico.traduceDia(fecha.AddDays(29).DayOfWeek.ToString()) + " " + fecha.AddDays(29).Day.ToString();
            d31.HeaderText = generico.traduceDia(fecha.AddDays(30).DayOfWeek.ToString()) + " " + fecha.AddDays(30).Day.ToString();

            return fecha.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textProducto.Text)) &&
                (!string.IsNullOrWhiteSpace(textMotivo.Text)) &&
                (!string.IsNullOrWhiteSpace(comboIgv.Text)) &&
                (cmbEjecutivo.SelectedValue != null && cmbEjecutivo.SelectedValue.ToString() != "0") &&
                (comboCambio.SelectedValue != null && comboCambio.SelectedValue.ToString() != "0") &&
                (txtAgencia.SelectedIndex != 0))
            {
                Cursor.Current = Cursors.WaitCursor;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                System.Threading.Thread.Sleep(200);
                progressBar1.Value = 20;
                System.Threading.Thread.Sleep(200);
                progressBar1.Value = 50;

                try
                {
                    List<Dictionary<string, object>> datos = ObtenerDatosDataGridView(dataGridOrden);

                    string metodo = "";

                    Orden orden = new Orden();
                    orden.C_ORDEN = txtNumero.Text;
                    orden.C_CLIENTE = comboCliente.SelectedValue?.ToString();
                    orden.C_CONTRATO = comboContratos.SelectedValue?.ToString();
                    orden.C_MEDIO = comboMedio.SelectedValue?.ToString();
                    orden.IGV = comboIgv.SelectedItem?.ToString();
                    orden.C_MONEDA = comboCambio.SelectedValue?.ToString();
                    orden.FECHA_INICIO = inicioVigencia.Value.ToString();
                    orden.FECHA_FIN = finVigencia.Value.ToString();
                    orden.C_EJECUTIVO = cmbEjecutivo.SelectedValue?.ToString();
                    orden.PRODUCTO = textProducto.Text;
                    orden.MOTIVO = textMotivo.Text;
                    orden.DURACION = textDuracion.Text;
                    orden.OBSERVACIONES = textObservaciones.Text;
                    orden.AGENCIA = txtAgencia.Text;
                    orden.orden = datos;
                    orden.C_USUARIO = Global.sessionUsuario.ToString();

                    decimal suma = 0;
                    foreach (DataGridViewRow row in dataGridOrden.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            suma += ToDecimalSafe(row.Cells["totalcalculo"]?.Value);
                        }
                    }

                    orden.INVERSION = suma;

                    bool isChecked = chkRevisar.Checked;
                    orden.REVISION = isChecked ? numRevision.Value.ToString() : valorRevision.ToString();

                    metodo = string.IsNullOrWhiteSpace(valorRecibido) ? "POST" : "PUT";

                    System.Threading.Thread.Sleep(100);
                    progressBar1.Value = 100;

                    string resultado = Send<Orden>(apiUrl, orden, metodo);

                    JObject jObject = JObject.Parse(resultado);
                    string status = (string)jObject["status"];
                    string codigo = (string)jObject["codigo"];

                    if (status == "True")
                    {
                        MessageBox.Show((string)jObject["message"], "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarContratos();
                        valorIdOrden = codigo;
                        txtNumero.Visible = true;
                        txtNumero.Text = codigo;
                        btnPrint.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show((string)jObject["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    progressBar1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Algunos campos requeridos estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                progressBar1.Visible = false;
            }
        }

        private List<Dictionary<string, object>> ObtenerDatosDataGridView(DataGridView dgv)
        {
            List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow)
                {
                    Dictionary<string, object> filaDatos = new Dictionary<string, object>();

                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        filaDatos[dgv.Columns[celda.ColumnIndex].Name] = celda.Value;
                    }

                    datos.Add(filaDatos);
                }
            }

            return datos;
        }

        private async Task<string> GetService(string cadena)
        {
            WebRequest oRequest = WebRequest.Create(cadena);
            WebResponse oResponse = await oRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task EnviarDatosAlApi(List<Dictionary<string, object>> datos)
        {
            using (HttpClient cliente = new HttpClient())
            {
                Orden orden = new Orden();
                orden.C_MEDIO = comboMedio.SelectedValue?.ToString();
                orden.C_CONTRATO = comboContratos.SelectedValue?.ToString();
                orden.orden = datos;

                try
                {
                    StringContent resultado = new StringContent(Send(apiUrl, orden, "POST"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar datos al API REST: {ex.Message}");
                }
            }
        }

        private void comboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarContratos();
        }

        private void cargarContratos()
        {
            try
            {
                comboContratos.DataSource = null;
                comboContratos.Items.Clear();

                string url = !string.IsNullOrWhiteSpace(valorContrato)
                    ? Global.servicio + "/api-auroco/contrato_cliente"
                    : Global.servicio + "/api-auroco/contratos_clientes";

                if (comboCliente.SelectedValue != null)
                {
                    string cod_cliente = comboCliente.SelectedValue.ToString();

                    if (cod_cliente != "0" && cod_cliente != "AurocoPublicidad.models.request.Cliente")
                    {
                        Cliente cliente = new Cliente();
                        cliente.C_CLIENTE = cod_cliente;

                        string resultado = Send<Cliente>(url, cliente, "POST");
                        List<Contrato> lstC = JsonConvert.DeserializeObject<List<models.request.Contrato>>(resultado) ?? new List<Contrato>();

                        comboContratos.DataSource = lstC;
                        comboContratos.DisplayMember = "C_CONTRATO";
                        comboContratos.ValueMember = "C_CONTRATO";

                        if (!string.IsNullOrWhiteSpace(valorContrato))
                        {
                            comboContratos.SelectedValue = valorContrato;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public string Send<T>(string url, T ObjectRequest, string method = "POST")
        {
            string result = "";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(ObjectRequest);

                WebRequest request = WebRequest.Create(url);
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

        private async void comboContratos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cInicioVigencia.Text = "";
                cFinVigencia.Text = "";
                cNumeroFisico.Text = "";
                cTipoCambio.Text = "";
                cSaldo.Text = "";

                HttpClient clienteHttp = new HttpClient();

                if (comboContratos.SelectedValue != null)
                {
                    string codigo_contrato = comboContratos.SelectedValue.ToString();
                    string urlApi = Global.servicio + "/api-auroco/index.php/contrato_detalle/" + codigo_contrato;

                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);

                        if (data != null && data.Count > 0)
                        {
                            cInicioVigencia.Text = (data[0].INICIO_VIGENCIA);
                            cFinVigencia.Text = (data[0].FIN_VIGENCIA);
                            cMoneda.Text = data[0].C_MONEDA;
                            cNumeroFisico.Text = data[0].NRO_FISICO;

                            string simboloMoneda = data[0].C_MONEDA == "Soles" ? "S/." : "$";

                            cTipoCambio.Text = string.Format("{0}{1:N2}", "$", ToDoubleSafe((string)data[0].TIPO_CAMBIO));
                            cSaldo.Text = string.Format("{0}{1:N2}", simboloMoneda, ToDoubleSafe((string)data[0].SALDO_ACTUAL));
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public async Task cargaprograma(string canal)
        {
            if (string.IsNullOrWhiteSpace(canal))
                return;

            if (dataGridOrden.Columns.Contains("programa"))
            {
                dataGridOrden.Columns.Remove("programa");
            }

            string programas = await GetService(Global.servicio + "/api-auroco/medio_programas/" + canal);
            List<models.request.Programa> lstC = JsonConvert.DeserializeObject<List<models.request.Programa>>(programas) ?? new List<models.request.Programa>();

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Programa";
            comboBoxColumn.Width = 340;
            comboBoxColumn.Name = "programa";
            comboBoxColumn.DisplayMember = "PROGRAMA";
            comboBoxColumn.ValueMember = "ID";
            comboBoxColumn.DataSource = lstC;
            comboBoxColumn.AutoComplete = true;

            dataGridOrden.Columns.Insert(0, comboBoxColumn);
        }

        private void dataGridOrden_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridOrden.CurrentCell is DataGridViewComboBoxCell)
            {
                System.Windows.Forms.ComboBox comboBox = e.Control as System.Windows.Forms.ComboBox;
                if (comboBox != null)
                {
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }

        private async void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (comboBox.SelectedValue != null && dataGridOrden.CurrentCell != null)
                {
                    string selectedValue = comboBox.SelectedValue.ToString();
                    HttpClient clienteHttp = new HttpClient();
                    string urlApi = Global.servicio + "/api-auroco/programa/" + selectedValue;

                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        int currentRow = dataGridOrden.CurrentCell.RowIndex;
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(contenido);

                        foreach (var ansValue in data)
                        {
                            dataGridOrden.Rows[currentRow].Cells["horario"].Value =
                                Convert.ToString(ansValue["DIAS"]) + " " + Convert.ToString(ansValue["PERIODO"]);

                            dataGridOrden.Rows[currentRow].Cells["costo"].Value =
                                ToDoubleSafe(Convert.ToString(ansValue["COSTO"]));
                        }

                        RecalcularFila(currentRow);
                        RecalcularTotalesGenerales();
                    }
                }
            }
        }

        private void dataGridOrden_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex >= 3 && e.ColumnIndex <= 34) ||
                    e.ColumnIndex == dataGridOrden.Columns["costo"].Index)
                {
                    RecalcularFila(e.RowIndex);
                    RecalcularTotalesGenerales();
                }

                if (dataGridOrden.Rows.Count == 0)
                {
                    btnGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RecalcularFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridOrden.Rows.Count)
                return;

            DataGridViewRow fila = dataGridOrden.Rows[rowIndex];
            if (fila.IsNewRow)
                return;

            double d1v = ToDoubleSafe(fila.Cells["d1"]?.Value);
            double d2v = ToDoubleSafe(fila.Cells["d2"]?.Value);
            double d3v = ToDoubleSafe(fila.Cells["d3"]?.Value);
            double d4v = ToDoubleSafe(fila.Cells["d4"]?.Value);
            double d5v = ToDoubleSafe(fila.Cells["d5"]?.Value);
            double d6v = ToDoubleSafe(fila.Cells["d6"]?.Value);
            double d7v = ToDoubleSafe(fila.Cells["d7"]?.Value);
            double d8v = ToDoubleSafe(fila.Cells["d8"]?.Value);
            double d9v = ToDoubleSafe(fila.Cells["d9"]?.Value);
            double d10v = ToDoubleSafe(fila.Cells["d10"]?.Value);
            double d11v = ToDoubleSafe(fila.Cells["d11"]?.Value);
            double d12v = ToDoubleSafe(fila.Cells["d12"]?.Value);
            double d13v = ToDoubleSafe(fila.Cells["d13"]?.Value);
            double d14v = ToDoubleSafe(fila.Cells["d14"]?.Value);
            double d15v = ToDoubleSafe(fila.Cells["d15"]?.Value);
            double d16v = ToDoubleSafe(fila.Cells["d16"]?.Value);
            double d17v = ToDoubleSafe(fila.Cells["d17"]?.Value);
            double d18v = ToDoubleSafe(fila.Cells["d18"]?.Value);
            double d19v = ToDoubleSafe(fila.Cells["d19"]?.Value);
            double d20v = ToDoubleSafe(fila.Cells["d20"]?.Value);
            double d21v = ToDoubleSafe(fila.Cells["d21"]?.Value);
            double d22v = ToDoubleSafe(fila.Cells["d22"]?.Value);
            double d23v = ToDoubleSafe(fila.Cells["d23"]?.Value);
            double d24v = ToDoubleSafe(fila.Cells["d24"]?.Value);
            double d25v = ToDoubleSafe(fila.Cells["d25"]?.Value);
            double d26v = ToDoubleSafe(fila.Cells["d26"]?.Value);
            double d27v = ToDoubleSafe(fila.Cells["d27"]?.Value);
            double d28v = ToDoubleSafe(fila.Cells["d28"]?.Value);
            double d29v = ToDoubleSafe(fila.Cells["d29"]?.Value);
            double d30v = ToDoubleSafe(fila.Cells["d30"]?.Value);
            double d31v = ToDoubleSafe(fila.Cells["d31"]?.Value);
            double costo = ToDoubleSafe(fila.Cells["costo"]?.Value);

            double avisos = d1v + d2v + d3v + d4v + d5v + d6v + d7v + d8v + d9v + d10v +
                            d11v + d12v + d13v + d14v + d15v + d16v + d17v + d18v + d19v + d20v +
                            d21v + d22v + d23v + d24v + d25v + d26v + d27v + d28v + d29v + d30v + d31v;

            double total = avisos * costo;

            string simboloM = (comboCambio.SelectedValue != null && comboCambio.SelectedValue.ToString() == "Soles") ? "S/." : "$";

            fila.Cells["total"].Value = string.Format("{0}{1:N2}", simboloM, total);
            fila.Cells["totalcalculo"].Value = total;
            fila.Cells["avisos"].Value = avisos;
        }

        private void RecalcularTotalesGenerales()
        {
            double totalorden = 0;

            foreach (DataGridViewRow fila in dataGridOrden.Rows)
            {
                if (!fila.IsNewRow)
                {
                    totalorden += ToDoubleSafe(fila.Cells["totalcalculo"]?.Value);
                }
            }

            string simboloMoneda = (comboCambio.SelectedValue != null && comboCambio.SelectedValue.ToString() == "Soles") ? "S/." : "$";
            totalOrden.Text = string.Format("{0}{1:N2}", simboloMoneda, totalorden);
        }

        private void comboMedio_Leave(object sender, EventArgs e)
        {
            if (comboMedio.SelectedValue != null)
            {
                _ = cargaprograma(comboMedio.SelectedValue.ToString());
            }
        }

        public class ListItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ListItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
        }

        private void dataGridOrden_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridOrden.Columns[e.ColumnIndex].HeaderText.Contains("S") ||
                this.dataGridOrden.Columns[e.ColumnIndex].HeaderText.Contains("D"))
            {
                e.CellStyle.ForeColor = Color.Red;
            }

            if (e.ColumnIndex == dataGridOrden.Columns["total"].Index && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    string simboloMoneda = "S/.";
                    if (!string.IsNullOrWhiteSpace(valorMoneda) && valorMoneda.Equals("Dolares"))
                    {
                        simboloMoneda = "$";
                    }

                    e.Value = string.Format("{0}{1:N2}", simboloMoneda, valor);
                    e.FormattingApplied = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form childForm = new formReportes(valorIdOrden, inicioVigencia.Value.ToString(), txtAgencia.Text);
            childForm.Text = "Orden nro: " + valorIdOrden;
            childForm.Show();
        }

        private void dataGridOrden_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridOrden_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void dataGridOrden_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridOrden_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private double ToDoubleSafe(object value)
        {
            if (value == null) return 0;

            double resultado;
            return double.TryParse(value.ToString(), out resultado) ? resultado : 0;
        }

        private decimal ToDecimalSafe(object value)
        {
            if (value == null) return 0;

            decimal resultado;
            return decimal.TryParse(value.ToString(), out resultado) ? resultado : 0;
        }
    }
}