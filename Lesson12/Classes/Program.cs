using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var db = new Database();
var bot = new TelegramBot();
bot.GetUpdate((_, update, _) => GetUpdate(update));

Console.ReadKey();

async Task GetUpdate(Update update)
{
    if (update.Type != UpdateType.Message) return;

    bot.SendMessage(update.Message.Chat.Id, "a", new InlineKeyboardMarkup(new[] { new []{new InlineKeyboardButton("sd")}}));

    var user = GetUser(update);

    var message = update.Message!.Text!;

    if (message == "Menu") { ShowMenu(user); return; }

    switch (user.Step)
    {
        case 0: ShowMenu(user); break;
        case 1: SwitchTextMessage(user, message); break;
        case 2: AddQuestion(user, message); break;
        case 5: SwichtUsersMenu(user, message); break;
    }
}

void SwichtUsersMenu(User user, string message)
{
    switch (message)
    {
        case "Show": ShowUsers(user); break;
        case "Clear": ClearUsers(user); break;
        default:bot.SendMessage(user.ChatId,"Menu tanlang.");break;
    }
}

void ClearUsers(User user)
{
    db.usersDb.Users.Clear();
    user = db.usersDb.AddUser(user.ChatId, user.Name);
    user.SetStep(5);
    bot.SendMessage(user.ChatId, "Users list cleared.");
}

void SwitchTextMessage(User user, string? message)
{
    switch (message)
    {
        case "AddQuestion": ShowAddQuestion(user); break;
        case "Dashboard": ShowDashboard(user.ChatId); break;
        case "Users": ShowUsersMenu(user); break;
        default: bot.SendMessage(user.ChatId, "Menuni tanlang."); break;
    }
}

void ShowAddQuestion(User user)
{
    user.SetStep(2);
    var message = "Savolni quyidagi tartibda kiriting : \n 1 + 4 = ?, 2, 12, 14, 5, 6";

    var menuButtons = new ReplyKeyboardMarkup(new[]
    {
        new[] { new KeyboardButton("Menu") }
    })
    {
        ResizeKeyboard = true
    };

    bot.SendMessage(user.ChatId, message, menuButtons);
}

void AddQuestion(User user, string message)
{
    var question = db.questionDb.AddQuestion(message);
    if (question == null)
    {
        ShowAddQuestion(user); 
        return;
    }
    user.SetStep(2);
    bot.SendMessage(user.ChatId, "Savol qoshildi.");
}

User GetUser(Update update)
{
    var chatId = update.Message!.Chat.Id;

    var name = string.IsNullOrEmpty(update.Message.From.Username)
        ? update.Message.From.FirstName
        : "@"+update.Message.From.Username;

    var user = db.usersDb.AddUser(chatId, name);
    return user;
}

void ShowMenu(User user)
{
    var menu = new List<EMenu>()
    {
        EMenu.StartQuiz,
        EMenu.AddQuestion,
        EMenu.Dashboard,
        EMenu.Statistics,
        EMenu.Users,
        EMenu.Close
    };

    var menuButtons = new KeyboardButton[menu.Count][];
    for (int i = 0; i < menu.Count; i++)
    {
        menuButtons[i] = new[]
        {
            new KeyboardButton(menu[i].ToString())
        };
    }

    var buttons = new ReplyKeyboardMarkup(menuButtons)
    {
        ResizeKeyboard = true
    };
    user.SetStep(1);   
    bot.SendMessage(user.ChatId, "Menuni tanlang 👇", buttons);
}

void ShowDashboard(long chatId)
{
    string message = $"Savollar soni: {db.questionDb.Questions.Count}";
    message += "\n" + db.questionDb.GetQuestionText();
    bot.SendMessage(chatId, message);
}

void ShowUsers(User user)
{
    string message = $"Users count: {db.usersDb.Users.Count}";
    message += "\n" + db.usersDb.GetUsersText();
    bot.SendMessage(user.ChatId, message);
}

void ShowUsersMenu(User user)
{
    var message = "Tanlang";
    var buttons = new KeyboardButton[3][];
    buttons[0] = new[] { new KeyboardButton("Show") };
    buttons[1] = new[] { new KeyboardButton("Clear") };
    buttons[2] = new[] { new KeyboardButton("Menu") };
    user.SetStep(5);
    bot.SendMessage(user.ChatId, message, new ReplyKeyboardMarkup(buttons){ResizeKeyboard = true});
}