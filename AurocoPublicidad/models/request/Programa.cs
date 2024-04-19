namespace AurocoPublicidad.models.request
{
    internal class Programa
    {
        public string ID { get; set; }
        public string PROGRAMA { get; set; }
        public string CANAL { get; set; }
        public string GENERO { get; set;}   
        public string DIAS { get; set;}  
        public string PERIODO { get; set;}
        public decimal COSTO{ get; set; }
        public string C_USUARIO{ get; set; }
        public string F_CREACION { get; set; }
        public string ESTADO { get; set; }
    }
}
