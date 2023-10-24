using System;
using System.Threading.Tasks;
using OpenAI_API;
using System.Windows;

namespace Commands
{
    class Correction
    {
        public static async Task Correct()
        {
            string apiKey = Connection.API.GetApiKey();

            var api = new OpenAIAPI(apiKey);

            var chat = api.Chat.CreateConversation();

            Console.Write("\nEntrez la phrase à corriger : ");
            string toCorrect = Console.ReadLine();

            chat.AppendSystemMessage("Je t'envoie un mot ou une phrase, je veux que tu corriges les fautes d'orthographe");
            chat.AppendUserInput(toCorrect);

            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response + "\n");

        }
    }
}
