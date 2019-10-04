using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using Hack2019PO.Models;

namespace Hack2019PO.Internals
{
    public static class OpenDataHandler
    {     
        /// <summary>
        /// Get election district from the Prešov Open Data
        /// </summary>
        /// <param name="streetName"></param>
        /// <param name="streetNumber"></param>
        /// <returns></returns>
        public static VoteDistrict GetDistrict(string streetName, string streetNumber)
        {
            //Initialize XmlReader
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(ConfigurationManager.ConnectionStrings["ElectionDistrictOpenData"].ConnectionString, settings);
            VoteDistrict district = null;

            //Get to data start
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Voľby")
                {


                    reader.Read();
                    string electionType = reader.Value;
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.EndElement || reader.Name != "Voľby") throw new ArgumentException("Wrong filedata " + reader.Name);
                    

                    DumpData("Mesto", ref reader);
                    string ulica = GetValidData("Ulica", ref reader);
                    string orc = GetValidData("Or._č.", ref reader);
                    DumpData("Adresa", ref reader);
                    string nazovOkrsku = GetValidData("Názov_okrsku", ref reader);
                    string cisloOkrsku = GetValidData("Číslo_okrsku", ref reader);
                    DumpData("Volebná_miestnosť", ref reader);
                    string adresaVM = GetValidData("Adresa_volebnej_miestnosti", ref reader);
                    DumpData("Zapisovateľ", ref reader);

                    district = new VoteDistrict(ulica, orc, nazovOkrsku, adresaVM, int.Parse(cisloOkrsku));

                }
            }

            return district;


        }
        
        private static string GetValidData(string name, ref XmlReader reader)
        {
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace) reader.Read();
            if (reader.NodeType != XmlNodeType.Element || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
            reader.Read();
            string toReturn = reader.Value;
            reader.Read();
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
            return toReturn.Trim();
        }

        private static void DumpData(string name, ref XmlReader reader)
        {
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace) reader.Read();
            if (reader.NodeType != XmlNodeType.Element || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
            reader.Read();
            reader.Read();
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
        }

    }
}