using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    public class FormaPago
    {

            public string moneda { get; set; }
            public string tipo { get; set; } 
            public decimal monto { get; set; } 
        
    }
}
