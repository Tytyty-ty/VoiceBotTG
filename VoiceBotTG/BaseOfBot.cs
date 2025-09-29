using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VoiceBotTG
{
    class BaseOfBot
    {
        static async Task Main()
        {
            // Sync with Telegram
            using var cts = new CancellationTokenSource();
            var bot = new TelegramBotClient("8432190983:AAHQAuCCI7dnbirqkzKkHWfgXYCkad65XdM", cancellationToken: cts.Token);
            var me = await bot.GetMe();
            bot.OnMessage += OnMessage;

            // Modules
            var History = new HistoryOfMessages();
            var SpeechToText = new SpeechToText();
            var TextToSpeech = new TextToSpeech();

            // Log
            Console.WriteLine($"@{me.Username} запущено... Нажми Enter, чтобы завершить");
            Console.ReadLine();
            cts.Cancel();

            async Task OnMessage(Message msg, UpdateType type)
            {
                if (msg.Text is null) return;
                Console.WriteLine($"Получено {type} '{msg.Text}' в {msg.Chat}");
                await bot.SendMessage(msg.Chat, $"{msg.From.FirstName}: {msg.Text}");
            }

            
            
        }
    }
}