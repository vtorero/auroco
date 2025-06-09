using AurocoPublicidad.models.request;
using AurocoPublicidad.models.request.factura;
using System.Collections.Generic;

namespace AurocoPublicidad.models.request.factura

{
    internal class Factura

    {
        public string ublVersion { get; set; }
        public string tipoOperacion { get; set; }
        public string tipoDoc { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string fechaEmision { get; set; }

        public FormaPago formaPago { get; set; }
        //public List<Dictionary<Cuotas, object>> cuotas { get; set; }
        public List<Dictionary<string, object>> cuotas { get; set; }
        public string tipoMoneda { get; set; }
        public Cliente cliente { get; set; }
        public Company company { get; set; }

        public decimal mtoOperGravadas { get; set; }
        public decimal mtoIGV { get; set; }
        public decimal totalImpuestos { get; set; }
        public decimal valorVenta { get; set; }
        public decimal subTotal { get; set; }
        public decimal mtoImpVenta { get; set; }
        public List<Dictionary<Details, object>> detail { get; set; }

        public Legends Legends { get; set; }

    }
}
