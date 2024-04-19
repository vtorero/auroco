using System;
using System.Windows.Forms;

namespace AurocoPublicidad.forms
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {








        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmContratos();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Contratos";
            childForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmClientes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Clientes";
            childForm.Show();
        }
    

        private void ingresarOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmOrden("","","","",0,"","","","","","","","","","");
            childForm.MdiParent = this;
            childForm.Text = "Ingresar Ordenes";
            childForm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmContratos();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Contratos";
            childForm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmOrdenes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Ordenes";
            childForm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            Form childForm = new FrmMedio();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Medios";
            childForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmClientes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Clientes";
            childForm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmPrograma();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Programas";
            childForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmOrdenes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Ordenes";
            childForm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmPrograma();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Programas";
            childForm.Show();
        }

        private void ejecutivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmEjecutivo();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Ejecutivos";
            childForm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form childForm = new FrmEjecutivo();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Ejecutivos";
            childForm.Show();
        }
    }
}