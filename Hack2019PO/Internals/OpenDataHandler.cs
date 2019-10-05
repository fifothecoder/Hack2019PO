using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.IO;
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

        public static List<string> Poslanci = new List<string>() {
            "17. novembra", "19. januára", "Agátová", "Alexandra Matušku", "Alexeja Duchoňa", "Antona Prídavka", "Arm. gen. Svobodu", "Astrová", "Átriová", "Aurela Stodolu", "Bachingerovka", "Bajkalská", "Banícka", "Baštová", "Bayerova", "Bažantia", "Belianska", "Bencúrova", "Bendíkova", "Bernolákova", "Bezručova", "Bikoš", "Biskupa Gojdiča", "Björnsonova", "Bociania", "Bohúňova", "Borkut", "Borovicová", "Botanická", "Boženy Němcovej", "Bratislavská", "Brezová", "Broskyňová", "Budovateľská", "Buková", "Bulharská", "Burianova", "Čajkovského", "Čapajevova", "Cemjata", "Čerešňová", "Čergovská", "Československej armády", "Chalupkova", "Chmeľová", "Čipkárska", "Dargovská", "Dilongova", "Dlhá", "Dostojevského", "Drozdia", "Družstevná", "Dubová", "Dúbravská", "Duchnovičovo námestie", "Dúhová", "Duklianska", "Ďumbierska", "Engelsova", "Exnárova", "Federátov", "Fintická", "Floriánova", "Fraňa Kráľa", "Francisciho", "Františkánske námestie", "Fučíkova", "Gápľová", "Garbiarska", "Gaštanová", "Genplk. Jána Ambruša", "Gerlachovská", "Gorazdova", "Gorkého", "Grešova", "Haburská", "Herlianska", "Hlavná", "Hodžova", "Holländerova", "Holubia", "Horárska", "Horská", "Hrabová", "Hraničná", "Hrnčiarska", "Hruny", "Hurbanistov", "Hviezdna", "Hviezdoslavova", "Irisová", "Jabloňová", "Jahodová", "Jána Béreša", "Jána Bottu", "Jána Hollého", "Jána Lazoríka", "Jána Nováka", "Janáčkova", "Janka Borodáča", "Jánošíkova", "Janouškova", "Jantárová", "Jarková", "Jarná", "Jastrabia", "Javorinská", "Jazdecká", "Jazvečia", "Jedľová", "Jelenia", "Jelšová", "Jesenná", "Jesenského", "Jilemnického", "Jiráskova", "Jurkovičova", "Justičná", "Južná", "K amfiteátru", "K Okruhliaku", "K potoku", "K prameňu", "K Starej tehelni", "K studničke", "K Surdoku", "Kamencová", "Kamenná", "Karpatská", "Keratsinské námestie", "Kmeťovo stromoradie", "Koceľova", "Kollárova", "Komenského", "Konštantínova", "Kopaniny", "Košická", "Kotrádova", "Kováčska", "Kozmonautov", "Kpt. Nálepku", "Kraskova", "Krátka", "Krížna", "Ku Brezinám", "Ku Kráľovej hore", "Ku Kumštu", "Ku Kyslej vode", "Ku Škáre", "Ku vykládke", "Kukučínova", "Kúpeľná", "Kutuzovova", "Kúty", "Kuzmányho", "Kvašná voda", "Kvetná", "Kysucká", "L. Novomeského", "Ľ. Podjavorinskej", "Labutia", "Lastovičia", "Lesík delostrelcov", "Lesná", "Lesnícka", "Letná", "Levanduľová", "Levočská", "Lidická", "Liesková", "Limbová", "Lipová", "Líščia", "Lomnická", "Ľubotická", "Lúčna", "Magurská", "Majakovského", "Májové námestie", "Malinová", "Malkovská", "Marka Čulena", "Martina Benku", "Masarykova", "Mateja Huľu", "Mateja Murgaša", "Matice slovenskej", "Matky Terezy", "Mätová", "Matúša Trenčianskeho", "Maybaumova", "Medová", "Medvedia", "Medzinárodného dňa žien", "Metodova", "Michala Bosáka", "Mičurinova", "Mirka Nešpora", "Mlynská", "Mojmírova", "Moyzesova", "Mudroňova", "Mukačevská", "Murárska", "Muškátová", "Na Bikoši", "Na brehu", "Na Rovni", "Na Rúrkach", "Na Tablách", "Na vyhliadke", "Nábrežná", "Námestie 1. mája", "Námestie biskupa Vasiľa Hopka", "Námestie Kráľovnej pokoja", "Námestie Krista Kráľa", "Námestie legionárov", "Námestie mieru", "Námestie mládeže", "Námestie Národného povstania", "Námestie osloboditeľov", "Narcisová", "Nemčíkova", "Nevädzová", "Nová", "Obrancov mieru", "Odborárska", "Okrajová", "Okružná", "Októbrová", "Ondavská", "Opavská", "Oravská", "Orechová", "Orgovánová", "Orlia", "Ortáš", "Padlých hrdinov", "Palackého", "Palárikova", "Partizánska", "Pávia", "Pavla Horova", "Pavlovičovo námestie", "Pažica", "Pekná", "Petőfiho", "Petrovianska", "Pionierska", "Plavárenská", "Plzenská", "Pod Debrami", "Pod dubom", "Pod Hrádkom", "Pod Kalváriou", "Pod Kamennou baňou", "Pod komínom", "Pod Rúrkami", "Pod Šalgovíkom", "Pod Skalkou", "Pod Táborom", "Pod Turňou", "Pod Vinicami", "Pod Wilec hôrkou", "Poľná", "Poľovnícka", "Popradská", "Pöschlova", "Potočná", "Požiarnická", "Pražská", "Pri Delni", "Pri hati", "Pri ihrisku", "Pri kostole", "Pri majáku", "Pri mlyne", "Pri Toryse", "Pribinova", "Priemyselná", "Prostějovská", "Protifašistických bojovníkov", "Púpavová", "Puškinova", "Pustá dolina", "Račia", "Radlinského", "Rastislavova", "Raymanova", "Remscheidská", "Rezbárska", "Riečna", "Rombauerova", "Royova", "Rumanova", "Rusínska", "Ružová", "Rybárska", "Rybníčky", "Sabinovská", "Sadová", "Sadovnícka", "Šafárikova", "Šalviová", "Šarišská", "Sázavského", "Šebastovská", "Sedliackeho povstania", "Sekčovská", "Severná", "Sibírska", "Sídlisko duklianskych hrdinov", "Šidlovec", "Šidlovská", "Šípková", "Školská", "Skromná", "Škultétyho", "Sládkovičova", "Slanská", "Slávičia", "Slnečná", "Slovenská", "Šmeralova", "Smetanova", "Smreková", "Sokolia", "Soľanková", "Solivarská", "Soľná", "Soľnobanská", "Šoltésovej", "Sovia", "Spannerovej", "Špitálska", "Športová", "Srnčia", "Šrobárova", "Staré záhrady", "Stavbárska", "Štefana Náhalku", "Štefánikova", "Strážnická", "Strojnícka", "Štúrova", "Suchomlynská", "Suchoňova", "Súľovská", "Surdok", "Suvorovova", "Švábska", "Svätoplukova", "Tajovského", "Tarasa Ševčenka", "Tarjányiho", "Tatranská", "Tehelná", "Terchovská", "Teriakovská", "Tichá", "Tkáčska", "Tokajícka", "Tomášikova", "Topoľová", "Trnková", "Tulipánová", "Turistická", "Údenárska", "Urbánkova", "Urxova", "Úzka", "Vajanského", "Valkovská", "Vansovej", "Važecká", "Včelárska", "Veselá", "Veterná", "Vihorlatská", "Višňová", "Vlada Clementisa", "Vlčia", "Vodárenská", "Vodná", "Volgogradská", "Vranovská", "Východná", "Vydumanec", "Weberova", "Wolkerova", "Za Kalváriou", "Za traťou", "Zabíjaná", "Záborského", "Záhradná", "Záhradnícka", "Zajačia", "Západná", "Zápotockého", "Zborovská", "Železničiarska", "Železničná", "Zemplínska", "Zimná", "Zimný potok", "Zlatobanská"
        };

        public static AttendanceRecord[] GetAttendanceFromWeb(string name)
        {
            List<AttendanceRecord> records = new List<AttendanceRecord>();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.po-kraj.sk/sk/e-sluzby/zastupitelstvo/dochadzka-poslancov-zasadnutia-zastupitelstva/?d-2452262-e=1&6578706f7274=1");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            while (!sr.EndOfStream)
            {
                var data = sr.ReadLine().Split(',');
                if (data.Length != 5 || data[2] != name) 
                    continue;
                records.Add(new AttendanceRecord() { SessionID = data[0], SessionDate = data[1], Name = data[2], Party = data[3], Attended = data[4]});
            }

            return (records.Count > 0) ? records.ToArray() : null;
        }

        public static VotingRecord[] GetVotingFromWeb(string name)
        {
            List<VotingRecord> records = new List<VotingRecord>();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.po-kraj.sk/sk/e-sluzby/zastupitelstvo/hlasovanie-poslancov-zastupitelstva/zoznam-hlasovani-poslancov.html?d-2452262-e=1&filterBtn=Odosla%C5%A5&f_firstname$wildlike=&d-2452262-p=11&f_year=2019&f_surname$wildlike=&f_n_sitting=&6578706f7274=1");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            while (!sr.EndOfStream)
            {
                var data = sr.ReadLine().Split(',');
                if (data.Length != 7 || data[4] != name)
                    continue;
                records.Add(new VotingRecord() { Session = data[0], ProgramNumber = data[1], ProgramPoint = data[2], Note = data[3], Person = data[4],
                                                 Party = data[5], Vote = data[6]});
            }


            return (records.Count > 0) ? records.ToArray() : null;
        }

    }
}