using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Server_API.DBConnection;
using Server_API.DBQuery;

namespace CsMySQLTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                QueryClient.Select();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }

            /*

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
            */

        }
    }
}