using System.Threading.Tasks.Dataflow;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

string[] hello = {"Привет", "привет", "hello", "Hello"};

Dictionary<string, string> dict = new Dictionary<string, string>();
dict["Автомобиль"] = "Car";
dict["Практика"] = "Practice";
dict["Телефон"] = "Phone";

using var cts = new CancellationTokenSource();

const string token = "7969844039:AAGnyhjFx1sMhHK_RGJ1Jwc3iysGTQVCcAY"; 

var bot = new TelegramBotClient(token);
var me = await bot.GetMe();
System.Console.WriteLine(me.Username);
bot.OnMessage += OnMessage;
bot.OnMessage += OnCommand;
bot.OnMessage += TranslateMessage;
bot.OnUpdate += OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot

async Task TranslateMessage(Message msg, UpdateType type)
{
    if (msg.Text is null) return;
    if (dict.ContainsKey(msg.Text))
    {
        await bot.SendMessage(msg.Chat, dict[msg.Text]);
    }
    else
    {
        await bot.SendMessage(msg.Chat, "Я не понял");
    }
}

async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text is null) return;
    System.Console.WriteLine($"{type}: {msg.Text}\n{msg.Contact}");
    foreach (var hi in hello)
    {
        if (msg.Text == hi)
        {
            await using var stream = File.OpenRead("images.jpg");
            await bot.SendPhoto(msg.Chat, stream, "", replyMarkup: new InlineKeyboardButton[] { "Ok" });
        }
    }
}

async Task OnCommand(Message msg, UpdateType type)
{
    if (msg.Text is null) return;
    if (msg.Text == "/start")
    {
        await bot.SendMessage(msg.Chat, "Привет! Я бот, который умеет переводить текст!");
    }
}

async Task OnUpdate(Update update)
{
    if (update is { CallbackQuery: { } query }) // non-null CallbackQuery
    {
        await bot.AnswerCallbackQuery(query.Id, $"You picked {query.Data}");
        await bot.SendMessage(query.Message!.Chat, $"User {query.From} clicked on {query.Data}");
    }
}