﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request
{
    internal class Ordenes
    {
        public string ID { get; set; }
        public string C_ORDEN { get; set; }

        public string RAZON_SOCIAL { get; set; }

        public string PRODUCTO { get; set; }
        public string MOTIVO { get; set; }

        public string C_CONTRATO { get; set; }

        public string INICIO_VIGENCIA { get; set; }

        public string FIN_VIGENCIA { get; set; }
		
	
    }
}