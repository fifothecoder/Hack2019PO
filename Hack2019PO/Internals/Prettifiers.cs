using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hack2019PO.Internals
{
    public class Prettifiers
    {


        public static List<string> PartiesPrettified { get; } = new List<string>() { "KDH/SaS/OĽaNO/NOVA", "Nezaradený poslanec", "Smer-SD", "SNS", "Úsvit"};

        public static string PrettifyPartyName(string input)
        {
            if (!OpenDataHandler.Parties.Contains(input)) return input;     //Not in list, impossible but you never know :)
            switch (input)
            {
                case "KDH-SAS-OLANO-NOVA": return "KDH/SaS/OĽaNO/NOVA";
                case "nez_pos": return "Nezaradený poslanec";
                case "SMER": return "Smer-SD";
                case "SNS": return "SNS";
                case "USVIT": return "Úsvit";
                default: return input;                      //Bypass CS0161 and SNS
            }
        }
        public static string DeprettifyPartyName(string input)
        {
            if (!PartiesPrettified.Contains(input)) return input;     //Not in list, impossible but you never know :)
            switch (input)
            {
                case "KDH/SaS/OĽaNO/NOVA": return "KDH-SAS-OLANO-NOVA";
                case "Nezaradený poslanec": return "nez_pos";
                case "Smer-SD": return "SMER";
                case "Úsvit": return "USVIT";
                default: return input;                      //Bypass CS0161 and SNS
            }
        }
    }
}