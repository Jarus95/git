using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizApp.Bot.Console.Services
{
    public class TelegramBotService
    {
        private string Token = "5370553846:AAHOhXhasQ5V9s1nt4tjl7aTPjr6tloqSAs";
        private TelegramBotClient Bot;

        public TelegramBotService()
        {
            Bot = new TelegramBotClient(Token);
        }

        public void GetUpdate(Func<ITelegramBotClient,Update,CancellationToken,Task> update)
        {
            Bot.StartReceiving(
                updateHandler: update,
                errorHandler: (_, ex, _) =>
                {
                    System.Console.WriteLine(ex.Message);
                    return Task.CompletedTask;;
                });
        }

        public void SendMessage(long chatId, string messageText, IReplyMarkup? reply = null)
        {
            Bot.SendTextMessageAsync(chatId, messageText, replyMarkup: reply);
        }

        public void SendPhoto(long chatId, Stream? stream)
        {
            if(stream == null) return;
            Bot.SendPhotoAsync(chatId, new InputOnlineFile(stream));
        }
    }
}
