using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    public class Details
    {
       public string codProducto {  get; set; }
        public string unidad { get; set; } = "NIU";
      public string descripcion { get; set; }
      public double cantidad { get; set; }  
      public decimal mtoValorUnitario { get; set; }
        public decimal mtoValorVenta { get; set; }
      public decimal mtoBaseIgv { get; set; }
        public decimal porcentajeIgv { get; set; }
        public decimal igv { get; set; }
        public decimal tipAfeIgv { get; set; }
        public decimal totalImpuestos { get; set; }
        public decimal mtoPrecioUnitario { get; set; }
    }
}
