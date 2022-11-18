using APIServer.DBConnection;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Server_API.DBQuery
{
    public class QueryClient
    {
        #region Insert Into
        public static void InsertInto(MySqlConnection conn,
            string name, string surname, string address, string postal_code, string town, string email, string password)
        {
            string sql = "INSERT INTO client (name, surname, address, postal_code, town, email, password)"
                + "values (@name, @surname, @address, @postal_code, @town, @email, @password)";


            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add("@name", (MySqlDbType)SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@surname", (MySqlDbType)SqlDbType.VarChar).Value = surname;
            cmd.Parameters.Add("@address", (MySqlDbType)SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@postal_code", (MySqlDbType)SqlDbType.VarChar).Value = postal_code;
            cmd.Parameters.Add("@town", (MySqlDbType)SqlDbType.VarChar).Value = town;
            cmd.Parameters.Add("@email", (MySqlDbType)SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@password", (MySqlDbType)SqlDbType.VarChar).Value = password;

            int rowCount = cmd.ExecuteNonQuery();

            Console.WriteLine();
        }
        #endregion

        #region Select
        public static void Select()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            if (!DBUtils.TryDBConnection(conn))
            {
                Console.Read();
                return;
            }

            string sql = "SELECT `Id_Client`,`name`,`surname`,`address`,`postal_code`,`town`,`email`,`password` FROM client";

            // Créez un objet Command.
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Récupérez les données.
                        int id = reader.GetInt16(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string address = reader.GetString(3);
                        string postal_code = reader.GetString(4);
                        string town = reader.GetString(5);
                        string email = reader.GetString(6);
                        string password = reader.GetString(7);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Id_Client:" + id);
                        Console.WriteLine("name:" + name);
                        Console.WriteLine("surname:" + surname);
                        Console.WriteLine("address:" + address);
                        Console.WriteLine("postal_code:" + postal_code);
                        Console.WriteLine("town:" + town);
                        Console.WriteLine("email:" + email);
                        Console.WriteLine("password:" + password);
                    }
                }
            }

            conn.Close();
            conn.Dispose();

            Console.Read();
        } 
        #endregion
    }
}
