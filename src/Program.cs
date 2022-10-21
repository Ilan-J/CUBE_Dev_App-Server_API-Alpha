using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;

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
                /*
                // La commande Insert.
                string sql = "INSERT INTO client (name, surname, address, postal_code, town, email, password)"
                    + "values (@name, @surname, @address, @postal_code, @town, @email, @password)";


                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // Créez un objet Paramètre.
                MySqlParameter gradeParam = new MySqlParameter("@name", SqlDbType.VarChar);
                gradeParam.Value = "Dujardin";
                cmd.Parameters.Add(gradeParam);

                // Ajoutez le paramètre @highSalary (Écrire plus court).
                MySqlParameter highSalaryParam = cmd.Parameters.Add("@highSalary", (MySqlDbType)SqlDbType.Float);
                highSalaryParam.Value = 20000;

                // Ajoutez le paramètre @lowSalary (Écrire plus court).
                cmd.Parameters.Add("@lowSalary", (MySqlDbType)SqlDbType.Float).Value = 10000;
                */

                // Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
                string sql = "INSERT INTO client (name, surname, address, postal_code, town, email, password) values ('Dujardin', 'Jean', '1 Rue de la Liberté','75001', 'Paris', 'jd@gmail.com', 'coucou')";
                
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
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