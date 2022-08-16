using Telegram.Bot;
using Telegram.Bot.Types;

List<Question> questions = new List<Question>();
AddDefaultQuestion();

Dictionary<long, User> users = new Dictionary<long, User>();

string botToken = "5370553846:AAHOhXhasQ5V9s1nt4tjl7aTPjr6tloqSAs";
TelegramBotClient bot = new TelegramBotClient(botToken);
bot.StartReceiving(
    updateHandler: (client, update, token) => GetUpdate(update),
    errorHandler: (client, exception, token) => Task.CompletedTask);
Console.ReadKey();

async Task GetUpdate(Update update)
{
    Console.WriteLine(update.Message.Text);
    var text = update.Message.Text;
    var chatId = update.Message.Chat.Id;

    var user = new User();
    user.Id = chatId;
    user.Name = string.IsNullOrEmpty(update.Message.From.Username)
        ? update.Message.From.FirstName
        : update.Message.From.Username;
    users.Add(chatId, user);

    switch (text)
    {
        case "menu": ShowMenu(chatId); break;
        case "2": AddQuestion(chatId); break;
        case "3": ShowDashboard(chatId); break;
    }
}

void SendMessage(long chatId, string messageText)
{
    bot.SendTextMessageAsync(chatId, messageText);
}

void ShowMenu(long chatId)
{
    var menu = new List<EMenu>()
    {
        EMenu.StartQuiz,
        EMenu.AddQuestion,
        EMenu.Dashboard,
        EMenu.Statistics,
        EMenu.Close
    };

    string menuText = "";
    foreach (var eMenu in menu)
    {
        menuText += $"{(int)eMenu}. {eMenu}\n";
    }

    SendMessage(chatId, menuText);
}

void AddDefaultQuestion()
{
    questions.Add(new Question("1 + 2 = ?", 1, new List<string>() { "2", "3", "12", "32" }));
    questions.Add(new Question("1 * 2 = ?", 2, new List<string>() { "21", "34", "2", "32" }));
    questions.Add(new Question("4 / 2 = ?", 0, new List<string>() { "2", "13", "12", "32" }));
}

void ShowDashboard(long chatId)
{
    string message = "Savollar " + questions.Count + " ta.\n";
    string questionsText = "";

    for (int i = 0; i < questions.Count; i++)
    {
        questionsText += $"{i+1}. {questions[i].QuestionText}\n";
    }

    message += questionsText;
    message += "\nMenuga qaytish uchun 'menu' deb kiriting";
    SendMessage(chatId, message);
}

void AddQuestion(long chatId)
{
    string addQuestionText = "Savolni quyidagi tartibda kiriting : ";
    addQuestionText += "1 + 4 = ?, 2, 12, 14, 5, 6";
    SendMessage(chatId, addQuestionText);
}