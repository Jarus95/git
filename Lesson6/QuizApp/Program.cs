List<string[]> questions = new List<string[]>();
var statistics = new List<Tuple<string, int>>() 
{
    new Tuple<string, int>("men",100),
    new Tuple<string, int>("jfa",20),
    new Tuple<string, int>("kimdr",40)
};

string password = "123asd";

AddDefaultQuestions(questions);

File.WriteAllLines("s.txt", new string[] { });
var lines = File.ReadAllLines("s.txt");

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
        case Menu.Close: return;
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
    int togriJavoblarSoni = 0;

    for (var j = 0; j < questions.Count; j++)
    {
        for (var i = 0; i < questions[j].Length; i++)
        {
            if (i == 0) Console.WriteLine($"Savol : {questions[j][i]}");
            else if (i != 1) Console.WriteLine($"{i - 1}. {questions[j][i]}");
        }

        Console.Write("Javobini kiriting : ");
        var answer = int.Parse(Console.ReadLine()!) + 1;

        if (answer.ToString() == questions[j][1])
        {
            togriJavoblarSoni++;
            Console.WriteLine("Javob togri");
        }
        else
        {
            Console.WriteLine("Javob notogri");
        }

        Console.WriteLine(questions.Count - 1 == j
            ? "Natijani korish uchun 'Enter' bosing."
            : "Davom etish uchun 'Enter' bosing.");

        Console.ReadKey();
    }

    Console.WriteLine("Togri javoblar soni : {0}", togriJavoblarSoni);

    var user = new Tuple<string, int>(name, (int)((double)togriJavoblarSoni/questions.Count * 100));
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

    Console.WriteLine("Savolni kiriting");
    var newQuestion = Console.ReadLine()!;

    Console.WriteLine("Variantlarni kiriting.");
    Console.WriteLine("Masalan: 3 5 6 78");
    var choices = Console.ReadLine()!.Split();

    Console.WriteLine("Togri javob indeksi kiriting");
    var correctAnswerIndex = int.Parse(Console.ReadLine()!) + 1;

    var savol = new string[2 + choices.Length];
    savol[0] = newQuestion;
    savol[1] = correctAnswerIndex.ToString();

    for (var i = 0; i < choices.Length; i++)
    {
        savol[i + 2] = choices[i];
    }
    questions.Add(savol);

    Console.WriteLine("Savol qoshildi.");
    Start();
}

void Dashboard()
{
    Console.WriteLine($"Mavjud savollar soni {questions.Count}");

    foreach (var question in questions)
        Console.WriteLine(question[0]);

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
            statistics = statistics.OrderByDescending(element => element.Item2).ToList();
            for (var i = 0; i < statistics.Count; i++)
            {
                var (ism, togriJavoblarFoizi) = statistics[i];
                Console.WriteLine($"{i + 1}. {ism} {togriJavoblarFoizi}%");
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
        statistics.Clear();
        Console.WriteLine("Cleared.");
        Start();
    }
}

void AddDefaultQuestions(List<string[]> questions)
{
    questions.Add(new[] { "2 + 4 = ?", "2", "6", "5", "7" });
    questions.Add(new[] { "2 * 4 = ?", "4", "6", "5", "8" });
    questions.Add(new[] { "8 / 4 = ?", "3", "6", "2", "7" });
    questions.Add(new[] { "5 % 4 = ?", "2", "1", "5", "7" });
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