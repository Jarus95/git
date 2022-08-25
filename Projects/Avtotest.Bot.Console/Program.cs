using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Services;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = Avtotest.Bot.Console.Models.User;

var botService = new TelegramBotService();
var examService = new ExaminationsService(botService);
var userService = new UsersService(botService);
var menuService = new MenuService(botService, examService);
botService.GetUpdate((_, update, _) => Task.Run(() => GetUpdate(update)));
Console.ReadKey();

void GetUpdate(Update update)
{
    Telegram.Bot.Types.User From;
    string message;

    if (update.Type == UpdateType.CallbackQuery)
    {
        From = update.CallbackQuery.From;
        message = update.CallbackQuery.Data;
    }
    else if (update.Type == UpdateType.Message)
    {
        From = update.Message.From;
        message = update.Message.Text;
    }
    else return;

    var user = userService.AddUser(From);
    StepFilter(user, message);
}

void StepFilter(User user, string message)
{
    switch (user.Step)
    {
        case EUserStep.NewUser: menuService.SendMenu(user); break;
        case EUserStep.Menu: menuService.TextFilter(user, message); break;
        case EUserStep.Exam: menuService.TextFilterExam(user, message); break;
    }
}
