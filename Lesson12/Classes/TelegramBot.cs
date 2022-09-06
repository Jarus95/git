using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Classes;

class TelegramBot
{
    public TelegramBotClient Bot;
    private readonly string _token = "5370553846:AAHOhXhasQ5V9s1nt4tjl7aTPjr6tloqSAs";

    public TelegramBot()
    {
        Bot = new TelegramBotClient(_token);

    }

    public void GetUpdate(Func<ITelegramBotClient, Update, CancellationToken, Task> update)
    {
        Bot.StartReceiving(
            updateHandler: update,
            errorHandler: (_, ex, _) =>
            {
                Console.WriteLine(ex.Message); return Task.CompletedTask;
            });
    }
    public void SendMessage(long chatId, string message, IReplyMarkup? reply = null)
    {
        Bot.SendTextMessageAsync(chatId, message, replyMarkup: reply);
    }
}