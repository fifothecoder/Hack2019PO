using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APIPuller
{
    class Program
    {
        static void Main(string[] args)
        {
            PullData();
            Console.ReadLine();
        }

        static void PullData()
        {
            string CONNECTION_STRING = "https://egov.presov.sk/Default.aspx?NavigationState=802:0::plac2112:_266000_5_65537";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(CONNECTION_STRING, settings);

            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Voľby")
                {


                    reader.Read();
                    string typVolieb = reader.Value;
                    reader.Read();
                    if (reader.NodeType != XmlNodeType.EndElement || reader.Name != "Voľby") throw new ArgumentException("Zle");

                    string mesto = GetValidData("Mesto", ref reader);
                    string ulica = GetValidData("Ulica", ref reader);
                    string orc = GetValidData("Or._č.", ref reader);
                    string adresa = GetValidData("Adresa", ref reader);
                    string nazovOkrsku = GetValidData("Názov_okrsku", ref reader);
                    string cisloOkrsku = GetValidData("Číslo_okrsku", ref reader);
                    string volebnaMiestnost = GetValidData("Volebná_miestnosť", ref reader);
                    string adresaVM = GetValidData("Adresa_volebnej_miestnosti", ref reader);
                    string zapisovatel = GetValidData("Zapisovateľ", ref reader);
                }
            }


        }

        static string GetValidData(string name, ref XmlReader reader)
        {
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace) reader.Read();
            if (reader.NodeType != XmlNodeType.Element || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
            reader.Read();
            string toReturn = reader.Value;
            reader.Read();
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name) throw new ArgumentException("Wrong filedata " + name);
            return toReturn;
        }
    }
}
