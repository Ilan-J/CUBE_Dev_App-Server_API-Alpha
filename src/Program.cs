using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Server_API.DBConnection;

namespace CsMySQLTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtenez de l'objet Connection qui se connecte à DB.

            MySqlConnection conn = DBUtils.GetDBConnection();
            if (!DBUtils.TryDBConnection(conn))
            {
                Console.Read();
                return;
            }

            try
            {
                Console.WriteLine("Connexion à la base de données réussie.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }


            Console.Read();

        }
    }
}