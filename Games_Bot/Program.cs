using System;
using System.IO;
using Telegram.Bot;
using Newtonsoft.Json;
using Free_Games;

namespace TelegramBot
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
                Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                bot.SendTextMessageAsync(arg.Message.Chat.Id, $"You say: {arg.Message.Text}");
            };

            bot.StartReceiving();

            Console.ReadKey();
        }
    }
}