using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    internal class ReporteUilidad
    {
        public string C_CONTRATO { get; set; }
        public string C_CLIENTE { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string RUC { get; set; }
        public string INICIO_VIGENCIA { get; set; }
        public string FIN_VIGENCIA { get; set; }
        public string C_MONEDA { get; set; }
        public decimal INVERSION { get; set; }
        public decimal MONTO_ORDENADO { get; set; }
        public decimal UTILIDAD { get; set; }

    }
}
