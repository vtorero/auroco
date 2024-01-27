using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace AurocoPublicidad.forms
{
    public partial class FrmOrden : Form
    {
        public FrmOrden()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRowCollection filas = dataGridOrden.Rows;

            filas.Add();

        }

        private void FrmOrden_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Programa";
            comboBoxColumn.Name = "programa";
            comboBoxColumn.Items.Add("Programa 1");
            comboBoxColumn.Items.Add("Programa 2");
            comboBoxColumn.Items.Add("Programa 3");

            dataGridOrden.Columns.Insert(0, comboBoxColumn);
            //dataGridOrden.Columns.Add(comboBoxColumn);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inicioVigencia_Validated(object sender, EventArgs e)
        {

            pintaDias();



        }

        private string pintaDias()
        {
            var fecha = inicioVigencia.Value;
            L1.Text = generico.traduceDia(fecha.DayOfWeek.ToString());
            L2.Text = generico.traduceDia(fecha.AddDays(1).DayOfWeek.ToString());
            L3.Text = generico.traduceDia(fecha.AddDays(2).DayOfWeek.ToString());
            return fecha.ToString();

        }
    }
}



 

