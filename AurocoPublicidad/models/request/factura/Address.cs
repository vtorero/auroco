using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    internal class Address
    {
    
       public string  direccion {  get; set; }  
      public string provincia { get; set; }  
      public string departamento { get; set; }  
      public string distrito { get; set; }
      public string ubigueo { get; set; }

    }
}
