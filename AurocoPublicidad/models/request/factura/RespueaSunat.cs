using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AurocoPublicidad.models.request.factura
{
    [XmlRoot("respuesta")]

    public class RespuestaSunat
        {
        
            [XmlElement("codigo")]
            public string Codigo { get; set; }

            [XmlElement("mensaje")]
            public string Mensaje { get; set; }

            [XmlElement("cdrZip")]
            public string CdrZip { get; set; }

            [XmlElement("hash")]
            public string Hash { get; set; }
        }
    }

