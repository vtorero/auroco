﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurocoPublicidad.models.request.factura
{
    public class Cliente
    {

        public string tipoDoc {  get; set; }
        public string numDoc {  get; set; }
        public string  rznSocial { get; set; }
        public Address address { get; set; }    
    }
}
