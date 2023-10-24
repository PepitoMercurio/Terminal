using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    class Inputs
    {
        public static int ValidNumber()
        {
            Console.Write("Entrez l'id de la note : ");
            string input = Console.ReadLine();

            int id;

            while (!int.TryParse(input, out id))
            {
                Console.WriteLine("Entrez un id valide");
                input = Console.ReadLine();
            }

            return id;
        }
    }
}
