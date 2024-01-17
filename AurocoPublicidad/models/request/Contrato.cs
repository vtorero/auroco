using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    internal class Contrato
    {
        
        public string ID { get; set; }
        public string C_CONTRATO{ get; set; }
        public string C_CLIENTE { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string INICIO_VIGENCIA { get; set; }
        public string FIN_VIGENCIA { get; set; }
        public string NRO_FISICO { get; set; }
        public string C_MONEDA { get; set; }
      public Decimal C_MONTO_PAGAR { get; set; }
        public Decimal C_MONTO_ORDENAR { get; set; }
     
        public Decimal TIPO_CAMBIO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string C_USUARIO { get; set; }
        public string F_CREACION { get; set; }




    }
}
