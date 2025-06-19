using System;

namespace AurocoPublicidad
{


    public static class generico
    {
        private static string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private static string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static string[] especiales = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private static string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public static string traduceDia(string original)
        {
            string traduccion = "";

            switch (original)
            {
                case "Monday":
                    // code block
                    traduccion = "L";
                    break;
                case "Tuesday":
                    // code block
                    traduccion = "M";
                    break;
                case "Wednesday":
                    // code block
                    traduccion = "M";
                    break;
                case "Thursday":
                    // code block
                    traduccion = "J";
                    break;
                case "Friday":
                    // code block
                    traduccion = "V";
                    break;
                case "Saturday":
                    // code block
                    traduccion = "S";
                    break;
                case "Sunday":
                    // code block
                    traduccion = "D";
                    break;
                default:
                    // code block
                    break;
            }


            return traduccion;


        }

     


    


    public static string NumeroALetras(decimal numero)
        {
            long parteEntera = (long)Math.Floor(numero);
            int centavos = (int)((numero - parteEntera) * 100);

            string letras = ConvertirNumero(parteEntera);
            letras += " con " + centavos.ToString("00") + "/100";

            return letras.Trim().ToUpper();
        }

        private static string ConvertirNumero(long numero)
        {
            if (numero == 0)
                return "cero";

            if (numero == 100)
                return "cien";

            string resultado = "";

            if (numero >= 1000000)
            {
                long millones = numero / 1000000;
                resultado += (millones == 1 ? "un millón" : ConvertirNumero(millones) + " millones") + " ";
                numero %= 1000000;
            }

            if (numero >= 1000)
            {
                long miles = numero / 1000;
                if (miles == 1)
                    resultado += "mil ";
                else
                    resultado += ConvertirNumero(miles) + " mil ";
                numero %= 1000;
            }

            if (numero >= 100)
            {
                long centena = numero / 100;
                resultado += centenas[centena] + " ";
                numero %= 100;
            }

            if (numero >= 20)
            {
                long decena = numero / 10;
                resultado += decenas[decena];
                numero %= 10;
                if (numero > 0)
                    resultado += " y " + unidades[numero];
            }
            else if (numero >= 10)
            {
                resultado += especiales[numero - 10];
            }
            else if (numero > 0)
            {
                resultado += unidades[numero];
            }

            return resultado.Trim();
        }


    } 
}
