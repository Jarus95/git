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
    if (update.Type == UpdateType.CallbackQuery)
    {
        var data = update.CallbackQuery!.Data!.Split(',').Select(int.Parse).ToArray();
        var answer = db.CheckAnswer(data[0], data[1]);

        var msgId = update.CallbackQuery.Message.MessageId;
        var chatID = update.CallbackQuery.Message.Chat.Id;
        var reply = update.CallbackQuery.Message.ReplyMarkup;
        
        bot.EditMessageReplyMarkup(chatID, msgId, SetResultToButton(reply, data[1], answer));
        SendQuestion(chatID, data[0] + 1);
    }

    if (update.Type != UpdateType.Message) return;

    var chatId = update.Message!.Chat.Id;
    SendQuestion(chatId, 0);
}

void SendQuestion(long chatId, int questionIndex)
{
    var (message, buttons) = GetQuestionMessage(questionIndex);
    bot.SendPhoto(chatId, db.GetQuestionImageStream(questionIndex), message, buttons);
}

Tuple<string, InlineKeyboardMarkup> GetQuestionMessage(int index)
{
    var question = db.Questions![index];
    var choicesText = question.Choices.Select(c => c.Text).ToList();
    return new(question.Question, GetInlineButtons(choicesText, index));
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

InlineKeyboardMarkup SetResultToButton(InlineKeyboardMarkup  buttons, int choiceIndex, bool answer)
{
    var buttonsList = buttons.InlineKeyboard.ToList();
    buttonsList[choiceIndex].ToList()[0].Text += answer ? " ✅" : " ❌";

    return buttons;
}
