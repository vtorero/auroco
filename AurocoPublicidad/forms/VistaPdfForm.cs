using System;
using System.IO;
using System.Windows.Forms;
using PdfiumViewer;

namespace VistaPdfDesdeApi
{
    public partial class VistaPdfForm : Form
    {
        private PdfViewer pdfViewer;

        public VistaPdfForm(byte[] pdfBytes)
        {
            InitializeComponent();
            this.Text = "Vista previa del PDF";
            this.Width = 800;
            this.Height = 600;

            pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(pdfViewer);

             var stream = new MemoryStream(pdfBytes);
            var document = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer.Document = document;
        }
    }
}
