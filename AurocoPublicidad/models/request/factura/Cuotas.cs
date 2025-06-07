using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    public class Cuotas
    {
        public string moneda { get; set; }
        public decimal monto { get; set; }
        public string fechaPago { get; set; }
    }
}