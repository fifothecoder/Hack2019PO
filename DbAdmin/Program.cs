using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;

namespace DbAdmin
{
    public class Stuff
    {
        [JsonProperty("Voľby")]
        public string volby { get; set; }

        [JsonProperty("Mesto")]
        public string mesto { get; set; }

        [JsonProperty("Ulica")]
        public string ulica { get; set; }

        [JsonProperty("Or._č.")]
        public string orc { get; set; }

        [JsonProperty("Adresa")]
        public string adresa { get; set; }

        [JsonProperty("Názov_okrsku")]
        public string nazok { get; set; }

        [JsonProperty("Číslo_okrsku")]
        public string cisok { get; set; }

        [JsonProperty("Volebná_miestnosť")]
        public string vm { get; set; }

        [JsonProperty("Adresa_volebnej_miestnosti")]
        public string avm { get; set; }

        [JsonProperty("Zapisovateľ")]
        public string zap { get; set; }

        [JsonProperty("Názov_volebného_obvodu")]
        public string nvo { get; set; }

        [JsonProperty("Mestská_časť_-_adresy_zaradenej_do_volieb")]
        public string mc { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = "Server=tcp:udaje.database.windows.net,1433;Initial Catalog=Udaje;Persist Security Info=False;User ID=stcmicrosoft;Password=Matejpenis123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand c = new SqlCommand("SELECT * FROM dbo.ElectionVenues WHERE Street=@add ", conn);
                c.Parameters.AddWithValue("@add", "Volgogradská");
                //c.Parameters.AddWithValue("@addno", "26");
                using (SqlDataReader reader = c.ExecuteReader())
                {
                    while(reader.Read())
                    {

                        Console.WriteLine("{0}", reader["RoomAddress"]);
                        Console.WriteLine("{0}", reader["DistrictAlias"]);
                    }
                }
                conn.Close();

            }
            //InsertIntoDatabase(connectionstring);
            

            Console.ReadLine();
        }

        static void QuerySomething()
        {

        }

        static void InsertIntoDatabase(string connectionstring)
        {
            var data = GetJSONData();
            SqlConnection conn = null;
            SqlCommand command = null;
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();

                    command = new SqlCommand("CREATE TABLE ElectionVenues (Elections varchar(255),City varchar(255),Street varchar(255),StreetNo varchar(255),Address varchar(255)," +
                        "DistrictName varchar(255),DistrictNumber varchar(255),Room varchar(255),RoomAddress varchar(255),Noter varchar(255),DistrictAlias varchar(255),CityPart varchar(255))", conn);
                    command.ExecuteNonQuery();

                    foreach (var item in data)
                    {
                        string insertQuery = "INSERT INTO ElectionVenues(Elections,City,Street,StreetNo,Address," +
                        "DistrictName,DistrictNumber,Room,RoomAddress,Noter,DistrictAlias,CityPart)values (@election,@city,@street,@streetNo,@address,@district,@districtNumber,@room,@roomAddress,@noter,@districtAlias,@cityPart)";
                        command = new SqlCommand(insertQuery, conn);
                        command.Parameters.AddWithValue("@election", item.volby);
                        command.Parameters.AddWithValue("@city", item.mesto);
                        command.Parameters.AddWithValue("@street", item.ulica);
                        command.Parameters.AddWithValue("@streetNo", item.orc);
                        command.Parameters.AddWithValue("@address", item.adresa);
                        command.Parameters.AddWithValue("@district", item.nazok);
                        command.Parameters.AddWithValue("@districtNumber", item.cisok);
                        command.Parameters.AddWithValue("@room", item.vm);
                        command.Parameters.AddWithValue("@roomAddress", item.avm);
                        command.Parameters.AddWithValue("@noter", item.zap);
                        command.Parameters.AddWithValue("@districtAlias", item.nvo);
                        command.Parameters.AddWithValue("@cityPart", item.mc);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Executing query {0} {1}", item.ulica, item.orc);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                command?.Dispose();
                conn?.Close();
            }
        }
        static List<Stuff> GetJSONData()
        {
            Console.WriteLine("Downloading JSON...");
            var downloaded = new WebClient().DownloadData("https://egov.presov.sk/Default.aspx?NavigationState=802:0::plac2112:_266000_5_8");
            string json = Encoding.UTF8.GetString(downloaded);
            
            Console.WriteLine("JSON Downloaded");

            var list = JsonConvert.DeserializeObject<List<Stuff>>(json);
            Console.WriteLine("JSON Parsed");
            return list;
        }

        
    }
}
