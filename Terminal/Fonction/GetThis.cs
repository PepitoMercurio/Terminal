using System;
using Npgsql;
using Connection;

namespace Commands
{
    class GetThis
    {
        public static async Task GetNote()
        {
            int id = Inputs.ValidNumber();

            string connString = Connection.Connection.Setup();

            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Connection en cours...");
                conn.Open();

                using (var command = new NpgsqlCommand($"SELECT * FROM Note WHERE ID = {id}", conn))
                {

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                string.Format(
                                    "{2}, Le : {1}\n{3}\n",
                                    reader.GetInt64(0),
                                    reader.GetDateTime(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                    )
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Aucune note avec l'id {id} a été trouvé");
                    }
                    reader.Close();
                }
            }
        }
    }
}
