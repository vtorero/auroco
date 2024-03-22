namespace AurocoPublicidad.models.request
{
    internal class Ordenes
    {
        public string ID { get; set; }
        public string C_ORDEN { get; set; }
        public string C_MEDIO { get; set; }
        public string NOMBRE { get; set; }

        public string C_CLIENTE { get; set; }

        public string RAZON_SOCIAL { get; set; }

        public string C_EJECUTIVO { get; set; }
        public string EJECUTIVO { get; set; }

        public string PRODUCTO { get; set; }
        public string MOTIVO { get; set; }

        public string DURACION{ get; set; }
        public string OBSERVACIONES { get; set; }

        public string C_CONTRATO { get; set; }

        public string INICIO_VIGENCIA { get; set; }

        public string FIN_VIGENCIA { get; set; }

        public string C_MONEDA { get; set; }
        public string ACTIVA { get; set; }
        public string TOTAL { get; set; }


    }
}
