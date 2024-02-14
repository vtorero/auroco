using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    internal class Orden
    {
        public string ID { get; set; }
        public string MEDIO { get; set; }    
        public string C_CONTRATO { get; set; }
        
        public List<Dictionary<string, object>> orden { get; set; }    
         public string C_USUARIO { get; set; }


    }
}
