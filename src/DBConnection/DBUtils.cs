using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Server_API.DBConnection
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            try
            {
                using StreamReader r = new StreamReader("./dbconfig.json");
                string config = r.ReadToEnd();

                DBConfig? dbConfig = JsonConvert.DeserializeObject<DBConfig>(config);

                if (dbConfig != null)
                {
                    return DBMySQLUtils.
                        GetDBConnection(dbConfig.host, dbConfig.port, dbConfig.database, dbConfig.username, dbConfig.password);
                }
                else
                {
                    return DBMySQLUtils.
                        GetDBConnection(null, null, null, null, null);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fichier \"dbconfig.json\" introuvable.");
                Console.ForegroundColor = ConsoleColor.White;
                return DBMySQLUtils.
                        GetDBConnection(null, null, null, null, null);
            }

        }
        public static bool TryDBConnection(MySqlConnection conn)
        {
            Console.WriteLine("Getting Connection ...");

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }
    }

    class DBConfig
    {
        public string? host { get; set; }
        public int port { get; set; }
        public string? database { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
