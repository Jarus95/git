using QuizApp.Bot.Console.Services;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var db = new QuestionsDataService();
var bot = new TelegramBotService();
bot.GetUpdate((_, update, _) => Task.Run(() => GetUpdate(update)));

Console.ReadKey();

void GetUpdate(Update update)
{
    if (update.Type != UpdateType.Message) return;

    var chatId = update.Message!.Chat.Id;

    var (message, buttons) = GetQuestionMessage(3);
    bot.SendPhoto(chatId, db.GetQuestionImageStream(3));
    bot.SendMessage(chatId, message, buttons);
}

Tuple<string, InlineKeyboardMarkup> GetQuestionMessage(int index)
{
    var question = db.Questions![index];
    var choicesText = question.Choices.Select(c => c.Text).ToList();
    return new (question.Question, GetInlineButtons(choicesText));
}

InlineKeyboardMarkup GetInlineButtons(List<string> buttonsText, int? questionIndex = null)
{
    var buttons = new InlineKeyboardButton[buttonsText.Count][];

    for (int i = 0; i < buttons.Length; i++)
    {
        var callBackData = questionIndex == null ? null : questionIndex + ",";
        buttons[i] = new[] { InlineKeyboardButton.WithCallbackData(text: buttonsText[i], callbackData: $"{callBackData}{i}") };
    }

    return new InlineKeyboardMarkup(buttons);
}
