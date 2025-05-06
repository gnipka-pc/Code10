using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Handlers
{
    public class BotMethods
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient bot, Message msg, UpdateType type)
        {
            var username = msg.From.Username;

            if (msg.Text == "/start")
            {
                await bot.SendMessage(msg.Chat, $"Привет, {username}! Этот бот позволяет переводить сообщения");
            }
        }
    }
}