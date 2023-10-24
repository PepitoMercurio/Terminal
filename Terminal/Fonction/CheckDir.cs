using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Commands
{
    class Check
    {
        public static bool Dir(string directoryPath, string folderToFind)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] subDirectories = Directory.GetDirectories(directoryPath);

                foreach (string subDirectory in subDirectories)
                {
                    string directoryName = new DirectoryInfo(subDirectory).Name;

                    if (directoryName.Equals(folderToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Dossier trouvé : {directoryName}");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Console.WriteLine($"Le répertoire {directoryPath} n'existe pas.");
                return true;
            }
        }

        public static bool IsValid(string input)
        {
            // Utilise une expression régulière pour vérifier si la chaîne est en kebab case
            return Regex.IsMatch(input, "^[a-z0-9]+(-[a-z0-9]+)*$");
        }
    }
}