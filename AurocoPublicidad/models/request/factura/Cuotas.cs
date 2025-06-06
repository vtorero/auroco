using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    internal class Cuotas

    {
        string moneda { get; set; }
        decimal monto { get; set; }
        string fechaPago { get; set; }
    }
}