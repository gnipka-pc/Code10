using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Collections.Generic;
using GTranslatorAPI;
// using static Handlers.BotMethods;

string[] hello = {"Привет", "привет", "hello", "Hello"};


// Dictionary<string, Tuple<string, string>> dict = new Dictionary<string, Tuple<string, string>>();

// dict["Привет"] = Tuple.Create("Hi", "Hola");
// dict["Автомобиль"] = Tuple.Create("Car", "Auto");
// dict["Кухня"] = Tuple.Create("Kitchen", "Cocina");

using var cts = new CancellationTokenSource();

const string token = "7537280750:AAFPjs3eBO-WZ4dbgNxHkO4_fscWb96HwQc"; 

var bot = new TelegramBotClient(token);
var me = await bot.GetMe();
System.Console.WriteLine(me.Username);
bot.OnMessage += OnMessage;
bot.OnMessage += HandleUpdateAsync;

var translator = new Translator();

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot

async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text is null) return;
    System.Console.WriteLine($"{type}: {msg.Text}\n{msg.Contact}");
    // await bot.SendMessage(msg.Chat, $"{dict[msg.Text].Item1}, {dict[msg.Text].Item2}");
    var result = await translator.TranslateAsync(Languages.ru, Languages.en, msg.Text);
    await bot.SendMessage(msg.Chat, result);
}

async Task HandleUpdateAsync(Message msg, UpdateType type)
{
    var username = msg.From.Username;

    if (msg.Text == "/start")
    {
        await bot.SendMessage(msg.Chat, $"Привет, {username}! Этот бот позволяет переводить сообщения");
    }
}