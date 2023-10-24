using System;
using Npgsql;

namespace Commands
{
    class Add
    {
        public static async Task AddNote()
        {
            Console.Write("Entrez le nom de la catégorie : ");
            string category = Console.ReadLine();

            Console.WriteLine("Entrez le contenu de la note :");
            string content = Console.ReadLine();
            

            string connString = Connection.Connection.Setup();

            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Connection en cours...");
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO Note (Date, Contenu, Categorie) VALUES (@Date, @Contenu, @Categorie)", conn))
                {
                    command.Parameters.AddWithValue("Date", DateTime.Now);
                    command.Parameters.AddWithValue("Contenu", content);
                    command.Parameters.AddWithValue("Categorie", category);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
        }
    }
}
