using System;
using Npgsql;

namespace Commands
{
    class Get
    {
        public static async Task GetNote()
        {
            string connString = Connection.Connection.Setup();


            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Connection en cours...");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM Note", conn))
                {

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                string.Format(
                                    "{0}. {2}, Le : {1}\n{3}\n",
                                    reader.GetInt64(0),
                                    reader.GetDateTime(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                    )
                                );
                        }
                        reader.Close();
                    }
                    else
                    {
                        Console.WriteLine("Erreur : aucune note trouvée");
                    }
                }
            }
        }
    }
}
