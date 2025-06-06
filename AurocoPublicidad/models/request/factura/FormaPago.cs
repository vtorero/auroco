using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    internal class FormaPago
    {

            public string Moneda { get; set; }
            public string Tipo { get; set; } 
            public decimal Monto { get; set; } 
        
    }
}
