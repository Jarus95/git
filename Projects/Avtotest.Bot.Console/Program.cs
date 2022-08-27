using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Services;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using User = Avtotest.Bot.Console.Models.User;

var botService = new TelegramBotService();
var examService = new ExaminationsService(botService);
var userService = new UsersService(botService);
var ticketService = new TicketService(botService);
var menuService = new MenuService(botService, examService, ticketService);

botService.GetUpdate((_, update, _) => Task.Run(() => GetUpdate(update)));
Console.ReadKey();

void GetUpdate(Update update)
{
    var (from, messageId, message, reply, isSuccess) = GetValues(update);
    if (!isSuccess) return;
    
    var user = userService.AddUser(from);
    if(messageId == user.OldMessageId)return;
    user.OldMessageId = messageId;
    StepFilter(user, message, messageId, reply);
}

void StepFilter(User user, string message, int messageId, InlineKeyboardMarkup reply)
{
    switch (user.Step)
    {
        case EUserStep.NewUser: menuService.SendMenu(user); break;
        case EUserStep.Menu: menuService.TextFilter(user, message); break;
        case EUserStep.Exam: menuService.TextFilterExam(user, message); break;
        case EUserStep.ExamStarted: examService.CheckAnswer(user, message, messageId, reply); break;
        case EUserStep.TicketList: ticketService.FilterText(user, message, messageId); break;
        case EUserStep.TicketStarting: menuService.FilterTicketStarting(user, message, messageId); break;
        case EUserStep.TicketStarted: ticketService.CheckAnswer(user, message, messageId, reply); break;
    }
}

Tuple<Telegram.Bot.Types.User, int, string, InlineKeyboardMarkup, bool> GetValues(Update update)
{
    Telegram.Bot.Types.User From;
    string message;
    int messageId;
    InlineKeyboardMarkup messageMarkup = null;

    if (update.Type == UpdateType.CallbackQuery)
    {
        From = update.CallbackQuery.From;
        message = update.CallbackQuery.Data;
        messageId = update.CallbackQuery.Message.MessageId;
        messageMarkup = update.CallbackQuery.Message.ReplyMarkup;
    }
    else if (update.Type == UpdateType.Message)
    {
        From = update.Message.From;
        message = update.Message.Text;
        messageId = update.Message.MessageId;
    }
    else return new(null, 0, null, null, false);

    return new (From, messageId, message, messageMarkup, true);
}
