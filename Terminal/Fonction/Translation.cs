using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace Commands
{
    class Translation
    {
        public static async Task Translate()
        {
            string apiKey = Connection.API.GetApiKey();

            var api = new OpenAIAPI(apiKey);

            var chat = api.Chat.CreateConversation();

            Console.Write("Entrez la phrase à traduire : ");
            string toTranslate = Console.ReadLine();

            chat.AppendSystemMessage("Je t'envoie une phrase, je veux que tu la en traduises en anglais");
            chat.AppendUserInput(toTranslate);

            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response + "\n");
        }
    }
}

