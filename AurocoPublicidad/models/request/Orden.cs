﻿using System.Collections.Generic;

namespace AurocoPublicidad.models.request
{
    internal class Orden
    {
        public string ID { get; set; }
        public string C_ORDEN { get; set; }

        public string REVISION { get; set; }

        public string d1 { get; set; }
        public string d2 { get; set; }
        public string C_CLIENTE { get; set; }
        public string C_CONTRATO { get; set; }
        public string C_MEDIO { get; set; }
        public string IGV{ get; set; }
        public string C_MONEDA { get; set; }
        public string FECHA_INICIO { get; set; }
        public string FECHA_FIN { get; set; }

        public string C_EJECUTIVO {  get; set; }

        public string PRODUCTO{ get; set; }
        public string MOTIVO{ get; set; }
        public string DURACION{ get; set; }
        public string OBSERVACIONES { get; set; }

        public List<Dictionary<string, object>> orden { get; set; }    
         public string C_USUARIO { get; set; }


    }
}
