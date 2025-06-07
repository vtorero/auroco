using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    public class Client
    {

        public string tipoDoc {  get; set; }
        public string numDoc {  get; set; }
        public string  rznSocial { get; set; }
        public Address Address { get; set; }    
    }
}
