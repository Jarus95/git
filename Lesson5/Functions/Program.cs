ShowMessage("Msg");

string GetInput()
{
    var input = Console.ReadLine();
    // some logics
    return input;
}

void ShowMessage(string msg)
{
    Console.WriteLine(msg);
}

int a = 5;
int b = 6;

int sum = 0;

// ref yordamida functionga ozgaruvchi manzili korsatiladi
Add(a, b, ref sum);

void Add(int a, int b, ref int sum)
{
    sum = a + b;
}

Console.WriteLine(sum);

Minus(12, 10, out int c);

Console.WriteLine(c);

void Minus(int a, int b, out int c)
{
    c = a - b;
}