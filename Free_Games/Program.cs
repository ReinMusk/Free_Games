// Gavrilov Daniil 220p
// Free_Games API
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Telegram.Bot;

namespace Free_Games
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            TelegramBotClient bot = new TelegramBotClient("1814776711:AAFjfToliQ7UJ_CVHvxoawW_cNKxGc98NI4");
            //var bot = new TelegramBotClient(File.ReadAllText("C:\\Work\\token.txt"));

            bot.OnMessage += (s, arg) =>
            {
                var game = GetGame();

                Random rnd = new Random();
                int value = rnd.Next(0, game.Count);

                Console.WriteLine(game[value].id.ToString());
                Console.WriteLine(game[value].title);
                Console.WriteLine(game[value].genre);
                Console.WriteLine(game[value].developer);
                Console.WriteLine(game[value].thumbnail);
                Console.WriteLine(game[value].short_description);
                Console.WriteLine(game[value].game_url);

                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].id.ToString());
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].title);
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].genre);
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].developer);
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].thumbnail);
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].short_description);
                bot.SendTextMessageAsync(arg.Message.Chat.Id, game[value].game_url);  
            };

            bot.StartReceiving();

            Console.ReadKey();
        }

        public static List<Free_Games.Root> GetGame()
        {
            var platform = "pc";

            var url = $"https://www.freetogame.com/api/games?platform={platform}";

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string tmp = streamReader.ReadToEnd();

                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(tmp);

                Random rnd = new Random();
                int value = rnd.Next(0, myDeserializedClass.Count);

                return myDeserializedClass;
            }
        }
    }
    public class Root
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string game_url { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string release_date { get; set; }
        public string freetogame_profile_url { get; set; }
    }
}
