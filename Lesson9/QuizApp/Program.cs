/*
 * QuizApp with struct
 */
User user1 = new User()
{
    Name = "Ismi",
    QuestionsCount = 4,
    CorrectAnswersCount = 3
};

Console.WriteLine(user1.ToStringPercent());
Console.WriteLine(user1.ToStringPercent("ieshlagan"));
Console.WriteLine(user1.ToStringPercent("ishlagan", 2));
Console.WriteLine(user1.ToStringPercent(1));

Change(user1);

Console.WriteLine(user1.Name); // Ismi

void Change(User user)
{
    user.Name = "Changed";
}

List<Question> questions = new List<Question>();
List<User> statistics = new List<User>()
{
    new User("men", 4, 5),
    new User("jfa",5,5),
    new User("kimdr",4,6)
};

Dictionary<string, string> appLang = GetLanguage();
string password = "123asd";

AddDefaultQuestions(questions);

Console.WriteLine(appLang["key"]);
Start();

void ChooseMenu()
{
    var input = (EMenu)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case EMenu.StartQuiz: StartQuiz(); break;
        case EMenu.AddQuestion: AddQuestion(); break;
        case EMenu.Dashboard: Dashboard(); break;
        case EMenu.Statistics: Statistics(); break;
        case EMenu.Close: Environment.Exit(0); break;
        default:
            {
                Console.WriteLine("Mavjud bolmagan EMenu tanlandi.");
                Start();
            }
            break;
    }
}

void StartQuiz()
{
    Console.Write("Ismingizni kiriting : ");
    var name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.Write("Notogri kiritingiz!");
        Start();
    }

    int togriJavoblarSoni = 0;
    var wrongList = new List<Tuple<string, string, string>>();

    for (var j = 0; j < questions.Count; j++)
    {
        Console.WriteLine($"Savol : {questions[j].QuestionText}");
        for (var i = 0; i < questions[j].Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[j].Choices[i]}");
        }

        Console.Write("Javobini kiriting : ");
        var answer = int.Parse(Console.ReadLine()!) - 1;

        if (answer == questions[j].CorrectAnswerIndex)
        {
            togriJavoblarSoni++;
            Console.WriteLine("Javob togri");
        }
        else
        {
            var wrong = new Tuple<string, string, string>(questions[j].QuestionText, questions[j].GetCorrectAnswer(), questions[j].Choices[answer]);
            wrongList.Add(wrong);

            Console.WriteLine("Javob notogri");
        }

        Console.WriteLine(questions.Count - 1 == j
            ? "Natijani korish uchun 'Enter' bosing."
            : "Davom etish uchun 'Enter' bosing.");

        Console.ReadKey();
    }

    Console.WriteLine("Togri javoblar soni : {0}", togriJavoblarSoni);

    foreach (var wrong in wrongList)
    {
        Console.WriteLine($"Savol :{wrong.Item1}, " +
                          $"Togri javob: {wrong.Item2}, " +
                          $"Siz kiritgan javob: {wrong.Item3}");
    }

    var user = new User(name!, togriJavoblarSoni, questions.Count);
    statistics.Add(user);

    Console.WriteLine("EMenu uchun 'Enter' bosing.");
    Console.ReadKey();
    Start();
}

void AddQuestion()
{
    Console.Write("Parolni kiriting : ");
    var parol = Console.ReadLine();

    if (password != parol)
    {
        Console.WriteLine("Parol notogri");
        Start();
    }

    var question = new Question();

    Console.WriteLine("Savolni kiriting");
    question.QuestionText = Console.ReadLine()!;

    Console.WriteLine("Variantlarni kiriting.");
    Console.WriteLine("Masalan: javob 3, 5 variant, olti, 78");
    question.Choices = Console.ReadLine()!.Split(',').ToList();

    Console.WriteLine("Togri javob indeksi kiriting");
    question.CorrectAnswerIndex = int.Parse(Console.ReadLine()!) + 1;

    questions.Add(question);
    Console.WriteLine("Savol qoshildi.");
    Start();
}

void Dashboard()
{
    Console.WriteLine($"Mavjud savollar soni {questions.Count}");

    foreach (var question in questions)
        Console.WriteLine((questions.IndexOf(question) + 1) + ". " + question.QuestionText);

    Start();
}

void Statistics()
{
    Console.WriteLine("Statistics : ");
    ShowMenuStatistics();

    var input = (EMenu)(int.Parse(Console.ReadLine()!) + 5);
    switch (input)
    {
        case EMenu.Show: ShowStatistics(); break;
        case EMenu.Clear: ClearStatistics(); break;
    }

    void ShowStatistics()
    {
        if (statistics!.Count > 0)
        {
            statistics = statistics.OrderByDescending(element => element.ToPercent()).ToList();
            for (var i = 0; i < statistics.Count; i++)
            {
                var user = statistics[i];
                Console.WriteLine($"{i + 1}. {user.Name} {user.ToStringPercent()}");
            }
        }
        else
            Console.WriteLine("Hich kim ishlamadi.");

        Console.WriteLine("EMenu uchun 'Enter' bosing.");
        Console.ReadKey();
        Start();
    }

    void ClearStatistics()
    {
        statistics!.Clear();
        Console.WriteLine("Cleared.");
        Start();
    }
}

void AddDefaultQuestions(List<Question> questions)
{
    var choices = new List<string>() { "5", "6", "7", "12" };
    var question = new Question("2 + 4 = ?", 1, choices);
    questions.Add(question);
}

void Start()
{
    Console.WriteLine();
    ShowMenu(EMenu.StartQuiz);
    ShowMenu(EMenu.AddQuestion);
    ShowMenu(EMenu.Dashboard);
    ShowMenu(EMenu.Statistics);
    ShowMenu(EMenu.Close);

    ChooseMenu();
}

void ShowMenuStatistics()
{
    Console.WriteLine();
    ShowMenu(EMenu.Show, 5);
    ShowMenu(EMenu.Clear, 5);
}

void ShowMenu(EMenu menu, int i = 0)
{
    Console.WriteLine($"{(int)menu - i}. {menu}");
}

Dictionary<string, string> GetLanguage()
{
    Console.WriteLine("Tilni tanla");
    Console.WriteLine("1. Uzbek \n2. Russian \n3. English");

    Dictionary<string, string> uzbek = new Dictionary<string, string>()
    {
        {"key","Value"},
        {"menu","Mundarija"},
    };

    Dictionary<string, string> english = new Dictionary<string, string>()
    {
        {"key","Value"},
        {"menu","EMenu"},
    };

    Dictionary<string, string> russian = new Dictionary<string, string>()
    {
        {"key","Qiymat rus tilida"},
        {"menu","EMenu"},
    };

    int input = int.Parse(Console.ReadLine()!);
    if (input == 1) return uzbek;
    if (input == 3) return english;
    if (input == 2) return russian;
    return uzbek;
}