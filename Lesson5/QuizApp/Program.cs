var menu = new string[]
{
    "Tesni boshlash",
    "Savol qoshish",
    "Malumot",
    "Statistika"
};

void Show(string[] ms)
{
    foreach (var m in ms) Console.WriteLine(m);
}

int currentIndex = 0;
string currentUserName = string.Empty;
var statistika = new string[10][];

string GetUserName()
{
    currentUserName = Console.ReadLine()!;
    return currentUserName;
}

void AddUser(string name, string count)
{
    statistika[currentIndex] = new string[] { name, count };

    QoshibBor();

    void QoshibBor()
    {
        currentIndex++;
    }
}

Show(menu);

