using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Avtotest.Bot.Console.Services;

public class TelegramBotService
{
    private const string BotToken = "5481889693:AAH1-Wu_cRciv6_vLju-ULX7LvCaX33tIPA";
    private TelegramBotClient bot;

    public TelegramBotService()
    {
        bot = new TelegramBotClient(BotToken);
    }

    public void GetUpdate(Func<ITelegramBotClient, Update, CancellationToken, Task> update)
    {
        bot.StartReceiving(
            updateHandler: update,
            errorHandler: (_, ex, _) =>
            {
                System.Console.WriteLine(ex.Message);
                return Task.CompletedTask;
            });
    }

    public void SendMessage(long chatId, string message, IReplyMarkup reply = null)
    {
        bot.SendTextMessageAsync(chatId, message, replyMarkup: reply);
    }

    public void SendMessage(long chatId, string message, Stream image, IReplyMarkup reply = null)
    {
        bot.SendPhotoAsync(chatId, new InputOnlineFile(image), message, replyMarkup: reply);
    }

    public ReplyKeyboardMarkup GetKeyboard(List<string> buttonsText)
    {
        KeyboardButton[][] buttons = new KeyboardButton[buttonsText.Count][];

        for (int i = 0; i < buttonsText.Count; i++)
        {
            buttons[i] = new KeyboardButton[] { new(buttonsText[i]) };
        }

        return new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
    }

    public InlineKeyboardMarkup GetInlineKeyboard(List<string> buttonsText, int? correctAnswerIndex = null)
    {
        InlineKeyboardButton[][] buttons = new InlineKeyboardButton[buttonsText.Count][];

        for (var i = 0; i < buttonsText.Count; i++)
        {
            buttons[i] = new InlineKeyboardButton[] { InlineKeyboardButton.WithCallbackData(
                text: buttonsText[i],
                callbackData: correctAnswerIndex == null ? buttonsText[i] : $"{correctAnswerIndex},{i}"),  };
        }

        return new InlineKeyboardMarkup(buttons);
    }
}