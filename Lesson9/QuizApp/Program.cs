/*
 * QuizApp with struct
 */

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
    var input = (Menu)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case Menu.StartQuiz: StartQuiz(); break;
        case Menu.AddQuestion: AddQuestion(); break;
        case Menu.Dashboard: Dashboard(); break;
        case Menu.Statistics: Statistics(); break;
        case Menu.Close: Environment.Exit(0); break;
        default:
            {
                Console.WriteLine("Mavjud bolmagan Menu tanlandi.");
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

    Console.WriteLine("Menu uchun 'Enter' bosing.");
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

    var input = (Menu)(int.Parse(Console.ReadLine()!) + 5);
    switch (input)
    {
        case Menu.Show: ShowStatistics(); break;
        case Menu.Clear: ClearStatistics(); break;
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

        Console.WriteLine("Menu uchun 'Enter' bosing.");
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
    ShowMenu(Menu.StartQuiz);
    ShowMenu(Menu.AddQuestion);
    ShowMenu(Menu.Dashboard);
    ShowMenu(Menu.Statistics);
    ShowMenu(Menu.Close);

    ChooseMenu();
}

void ShowMenuStatistics()
{
    Console.WriteLine();
    ShowMenu(Menu.Show, 5);
    ShowMenu(Menu.Clear, 5);
}

void ShowMenu(Menu menu, int i = 0)
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
        {"menu","Menu"},
    };

    Dictionary<string, string> russian = new Dictionary<string, string>()
    {
        {"key","Qiymat rus tilida"},
        {"menu","Menu"},
    };

    int input = int.Parse(Console.ReadLine()!);
    if (input == 1) return uzbek;
    if (input == 3) return english;
    if (input == 2) return russian;
    return uzbek;
}

enum Menu
{
    StartQuiz = 1,
    AddQuestion,
    Dashboard,
    Statistics,
    Close,
    Show,
    Clear
}