using AurocoPublicidad.models.request;
using AurocoPublicidad.models.request.factura;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AurocoPublicidad.models.request.factura

{
    internal class FacturaContado

    {
        public string ublVersion { get; set; }
        public string tipoOperacion { get; set; }
        public string tipoDoc { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string fechaEmision { get; set; }
        public string fecVencimiento { get; set; }

        public string observacion { get; set; }
        public FormaPago formaPago { get; set; }
        public string tipoMoneda { get; set; }
        public Cliente client { get; set; }
        public Company company { get; set; }

        public decimal mtoOperGravadas { get; set; }
        public decimal mtoIGV { get; set; }
        public decimal totalImpuestos { get; set; }
        public decimal valorVenta { get; set; }
        public decimal subTotal { get; set; }
        public decimal mtoImpVenta { get; set; }

        public Detraccion detraccion { get; set; }  
        public List<Details> details { get; set; }
        
        //public Details details { get; set; }   

        //public List<Dictionary<string, object>> detail { get; set; }

        public List<Legends> legends { get; set; }

    }
}
