using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    public class Company
    {

        public string ruc { get; set; }

        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public Address address { get; set; }    

    }
}
