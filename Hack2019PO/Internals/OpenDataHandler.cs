using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
        /// 

        public static List<string> Addresses = new List<string>() {
            "17. novembra", "19. januára", "Agátová", "Alexandra Matušku", "Alexeja Duchoňa", "Antona Prídavka", "Arm. gen. Svobodu", "Astrová", "Átriová", "Aurela Stodolu", "Bachingerovka", "Bajkalská", "Banícka", "Baštová", "Bayerova", "Bažantia", "Belianska", "Bencúrova", "Bendíkova", "Bernolákova", "Bezručova", "Bikoš", "Biskupa Gojdiča", "Björnsonova", "Bociania", "Bohúňova", "Borkut", "Borovicová", "Botanická", "Boženy Němcovej", "Bratislavská", "Brezová", "Broskyňová", "Budovateľská", "Buková", "Bulharská", "Burianova", "Čajkovského", "Čapajevova", "Cemjata", "Čerešňová", "Čergovská", "Československej armády", "Chalupkova", "Chmeľová", "Čipkárska", "Dargovská", "Dilongova", "Dlhá", "Dostojevského", "Drozdia", "Družstevná", "Dubová", "Dúbravská", "Duchnovičovo námestie", "Dúhová", "Duklianska", "Ďumbierska", "Engelsova", "Exnárova", "Federátov", "Fintická", "Floriánova", "Fraňa Kráľa", "Francisciho", "Františkánske námestie", "Fučíkova", "Gápľová", "Garbiarska", "Gaštanová", "Genplk. Jána Ambruša", "Gerlachovská", "Gorazdova", "Gorkého", "Grešova", "Haburská", "Herlianska", "Hlavná", "Hodžova", "Holländerova", "Holubia", "Horárska", "Horská", "Hrabová", "Hraničná", "Hrnčiarska", "Hruny", "Hurbanistov", "Hviezdna", "Hviezdoslavova", "Irisová", "Jabloňová", "Jahodová", "Jána Béreša", "Jána Bottu", "Jána Hollého", "Jána Lazoríka", "Jána Nováka", "Janáčkova", "Janka Borodáča", "Jánošíkova", "Janouškova", "Jantárová", "Jarková", "Jarná", "Jastrabia", "Javorinská", "Jazdecká", "Jazvečia", "Jedľová", "Jelenia", "Jelšová", "Jesenná", "Jesenského", "Jilemnického", "Jiráskova", "Jurkovičova", "Justičná", "Južná", "K amfiteátru", "K Okruhliaku", "K potoku", "K prameňu", "K Starej tehelni", "K studničke", "K Surdoku", "Kamencová", "Kamenná", "Karpatská", "Keratsinské námestie", "Kmeťovo stromoradie", "Koceľova", "Kollárova", "Komenského", "Konštantínova", "Kopaniny", "Košická", "Kotrádova", "Kováčska", "Kozmonautov", "Kpt. Nálepku", "Kraskova", "Krátka", "Krížna", "Ku Brezinám", "Ku Kráľovej hore", "Ku Kumštu", "Ku Kyslej vode", "Ku Škáre", "Ku vykládke", "Kukučínova", "Kúpeľná", "Kutuzovova", "Kúty", "Kuzmányho", "Kvašná voda", "Kvetná", "Kysucká", "L. Novomeského", "Ľ. Podjavorinskej", "Labutia", "Lastovičia", "Lesík delostrelcov", "Lesná", "Lesnícka", "Letná", "Levanduľová", "Levočská", "Lidická", "Liesková", "Limbová", "Lipová", "Líščia", "Lomnická", "Ľubotická", "Lúčna", "Magurská", "Majakovského", "Májové námestie", "Malinová", "Malkovská", "Marka Čulena", "Martina Benku", "Masarykova", "Mateja Huľu", "Mateja Murgaša", "Matice slovenskej", "Matky Terezy", "Mätová", "Matúša Trenčianskeho", "Maybaumova", "Medová", "Medvedia", "Medzinárodného dňa žien", "Metodova", "Michala Bosáka", "Mičurinova", "Mirka Nešpora", "Mlynská", "Mojmírova", "Moyzesova", "Mudroňova", "Mukačevská", "Murárska", "Muškátová", "Na Bikoši", "Na brehu", "Na Rovni", "Na Rúrkach", "Na Tablách", "Na vyhliadke", "Nábrežná", "Námestie 1. mája", "Námestie biskupa Vasiľa Hopka", "Námestie Kráľovnej pokoja", "Námestie Krista Kráľa", "Námestie legionárov", "Námestie mieru", "Námestie mládeže", "Námestie Národného povstania", "Námestie osloboditeľov", "Narcisová", "Nemčíkova", "Nevädzová", "Nová", "Obrancov mieru", "Odborárska", "Okrajová", "Okružná", "Októbrová", "Ondavská", "Opavská", "Oravská", "Orechová", "Orgovánová", "Orlia", "Ortáš", "Padlých hrdinov", "Palackého", "Palárikova", "Partizánska", "Pávia", "Pavla Horova", "Pavlovičovo námestie", "Pažica", "Pekná", "Petőfiho", "Petrovianska", "Pionierska", "Plavárenská", "Plzenská", "Pod Debrami", "Pod dubom", "Pod Hrádkom", "Pod Kalváriou", "Pod Kamennou baňou", "Pod komínom", "Pod Rúrkami", "Pod Šalgovíkom", "Pod Skalkou", "Pod Táborom", "Pod Turňou", "Pod Vinicami", "Pod Wilec hôrkou", "Poľná", "Poľovnícka", "Popradská", "Pöschlova", "Potočná", "Požiarnická", "Pražská", "Pri Delni", "Pri hati", "Pri ihrisku", "Pri kostole", "Pri majáku", "Pri mlyne", "Pri Toryse", "Pribinova", "Priemyselná", "Prostějovská", "Protifašistických bojovníkov", "Púpavová", "Puškinova", "Pustá dolina", "Račia", "Radlinského", "Rastislavova", "Raymanova", "Remscheidská", "Rezbárska", "Riečna", "Rombauerova", "Royova", "Rumanova", "Rusínska", "Ružová", "Rybárska", "Rybníčky", "Sabinovská", "Sadová", "Sadovnícka", "Šafárikova", "Šalviová", "Šarišská", "Sázavského", "Šebastovská", "Sedliackeho povstania", "Sekčovská", "Severná", "Sibírska", "Sídlisko duklianskych hrdinov", "Šidlovec", "Šidlovská", "Šípková", "Školská", "Skromná", "Škultétyho", "Sládkovičova", "Slanská", "Slávičia", "Slnečná", "Slovenská", "Šmeralova", "Smetanova", "Smreková", "Sokolia", "Soľanková", "Solivarská", "Soľná", "Soľnobanská", "Šoltésovej", "Sovia", "Spannerovej", "Špitálska", "Športová", "Srnčia", "Šrobárova", "Staré záhrady", "Stavbárska", "Štefana Náhalku", "Štefánikova", "Strážnická", "Strojnícka", "Štúrova", "Suchomlynská", "Suchoňova", "Súľovská", "Surdok", "Suvorovova", "Švábska", "Svätoplukova", "Tajovského", "Tarasa Ševčenka", "Tarjányiho", "Tatranská", "Tehelná", "Terchovská", "Teriakovská", "Tichá", "Tkáčska", "Tokajícka", "Tomášikova", "Topoľová", "Trnková", "Tulipánová", "Turistická", "Údenárska", "Urbánkova", "Urxova", "Úzka", "Vajanského", "Valkovská", "Vansovej", "Važecká", "Včelárska", "Veselá", "Veterná", "Vihorlatská", "Višňová", "Vlada Clementisa", "Vlčia", "Vodárenská", "Vodná", "Volgogradská", "Vranovská", "Východná", "Vydumanec", "Weberova", "Wolkerova", "Za Kalváriou", "Za traťou", "Zabíjaná", "Záborského", "Záhradná", "Záhradnícka", "Zajačia", "Západná", "Zápotockého", "Zborovská", "Železničiarska", "Železničná", "Zemplínska", "Zimná", "Zimný potok", "Zlatobanská"
        };

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
                    string ulica = GetValidNumber("Ulica", ref reader);

                    string orc = GetValidNumber("Or._č." ,ref reader);
                    DumpData("Adresa", ref reader);
                    string nazovOkrsku = GetValidNumber("Názov_okrsku", ref reader);
                    string cisloOkrsku = GetValidNumber("Číslo_okrsku", ref reader);
                    DumpData("Volebná_miestnosť", ref reader);
                    string adresaVM = GetValidNumber("Adresa_volebnej_miestnosti", ref reader);
                    DumpData("Zapisovateľ", ref reader);


                    if (ulica == streetName && orc == streetNumber) 
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
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name)
                throw new ArgumentException("Wrong filedata " + name);
            return toReturn.Trim();
        }

        private static string GetValidNumber(string name, ref XmlReader reader)
        {
            string s = "";
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            if(reader.NodeType != XmlNodeType.Element || reader.Name != name) throw new ArgumentException("Wrong filedata");
            reader.Read();

            if (reader.NodeType == XmlNodeType.Whitespace) 
                return s;
            s = reader.Value;
            reader.Read();
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name)
                throw new ArgumentException("Wrong filedata");

            return s.Trim();

        }

        private static void DumpData(string name, ref XmlReader reader)
        {
            string s = "";
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            if (reader.NodeType != XmlNodeType.Element || reader.Name != name) throw new ArgumentException("Wrong filedata");
            reader.Read();

            if (reader.NodeType == XmlNodeType.Whitespace) return;
                s = reader.Value;
            reader.Read();
            if (reader.NodeType != XmlNodeType.EndElement || reader.Name != name)
                throw new ArgumentException("Wrong filedata");
        }

    }
}