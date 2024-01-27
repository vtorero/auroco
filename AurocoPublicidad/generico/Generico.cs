using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AurocoPublicidad
{

    
public static class generico
{

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

}


}
