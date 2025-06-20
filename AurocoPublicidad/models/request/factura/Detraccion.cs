using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    public class Detraccion
    {

            public string codBienDetraccion { get; set; }
            public string codMedioPago { get; set; } 
            public string ctaBanco { get; set; }    
            public decimal percent {  get; set; }   
            public decimal mount { get; set; } 
        
    }
}
