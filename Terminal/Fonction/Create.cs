using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Commands
{
    class Create
    {
        public static async Task Creator()
        {
            Console.Write("Entrez le nom de votre projet : ");
            string appName = Console.ReadLine();

            string dir = "C:\\Users\\cocor\\Documents";

            bool isExist = Check.Dir(dir, appName);

            bool isValid = Check.IsValid(appName);

            if (!isExist && isValid)
            {
                string command = $"cd {dir} && npx create-react-app {appName} && code .\\{appName}\\";

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Utilise le cmd pour exécuter les commandes
                    RedirectStandardInput = true, //autorise l'envoi de donnée
                    RedirectStandardOutput = true, //autorise la reception des données
                    UseShellExecute = false, //on execute pas le shell
                    CreateNoWindow = true, //on exécute le cmd en arrière plan
                };

                process.StartInfo = startInfo;
                process.Start();

                Console.WriteLine("Création du projet, cela risque de prendre du temps...\n");

                process.StandardInput.WriteLine(command); //envoi de la commande
                process.StandardInput.Close(); // Fermez l'entrée standard pour indiquer que la commande est terminée

                process.WaitForExit();
                process.Close();

                Console.WriteLine("Projet créé avec succès dans le répertoire Documents !\n");
            }
            else if (!isValid)
            {
                Console.WriteLine($"Le nom {appName} est invalide pour la création du projet !\n");
            }
            else
            {
                Console.WriteLine($"Ce projet ou un dossier existe déjà à l'emplacement {dir} !\n");
            }
        }
    }
}
