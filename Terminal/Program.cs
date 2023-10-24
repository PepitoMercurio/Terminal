using System;
using System.Collections.Generic;
using CliWrap;
using Commands;

namespace TEST
{
    class Program
    {
        static async Task Main()
        {
            Dictionary<string, Action> openWith = new Dictionary<string, Action>();

            openWith.Add("-c", () =>
            {
                Func<Task> correctAsync = async () => await Correction.Correct(); //crée une variable de type Func<Task> et qui renvoie une fonction async
                correctAsync().GetAwaiter().GetResult(); //bloque l'execution du programme jusqu'à que ce soit terminé
            });
            openWith.Add("-t", () =>
            {
                Func<Task> translateAsync = async () => await Translation.Translate();
                translateAsync().GetAwaiter().GetResult();
            });
            openWith.Add("create", () =>
            {
                Func<Task> createAsync = async () => await Create.Creator();
                createAsync().GetAwaiter().GetResult();
            });
            openWith.Add("-l", () =>
            {
                Func<Task> getNoteAsync = async () => await Get.GetNote();
                getNoteAsync().GetAwaiter().GetResult();
            });
            openWith.Add("-n", () =>
            {
                Func<Task> getNoteAsync = async () => await GetThis.GetNote();
                getNoteAsync().GetAwaiter().GetResult();
            });
            openWith.Add("-a", () =>
            {
                Func<Task> getNoteAsync = async () => await Add.AddNote();
                getNoteAsync().GetAwaiter().GetResult();
            });


            string param = "";

            Console.WriteLine("Bonjour, je suis Marlène, votre assistante virtuelle !");

            while (param != "stop")
            {
                Console.WriteLine("Que voulez vous faire ?");
                param = Console.ReadLine();
                string[] command = param.Split(' ');

                if (openWith.ContainsKey(command[0]))
                {
                    openWith[command[0]]();

                    bool end = false;

                    while (!end)
                    {
                        Console.WriteLine("Voulez vous faire autre chose ? yes | no");
                        string ask = Console.ReadLine();

                        if (ask == "no" || ask == "n")
                        {
                            Console.WriteLine("D'accord, bonne journée");
                            end = true;
                            param = "stop";
                        }
                        else if (ask == "y" || ask == "yes")
                        {
                            end = true;
                        }
                        else
                        {
                            Console.WriteLine("Reponse invalide\n");
                        }
                    }
                    

                }
                else
                {
                    Console.WriteLine("Option invalide !");
                }
            }

            
        }
    }
}
