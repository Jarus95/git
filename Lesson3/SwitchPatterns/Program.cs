int a = int.Parse(Console.ReadLine()!); //! qiymat kiritishimiz aniq, null qiymatga ega bolmaydi

int b = 8;

switch (a)
{
    case 1: b = b * b; break;
    case 2: b = b / 2; break;
    default: b = 0; break;
}

b = a switch
{
    1 => b * b,
    2 => b / 2,
    _ => 0
};

Console.WriteLine(b);

string str = "so";

switch (a, b, str)
{
    case (1, 8, "so"): Console.WriteLine(1); break;
    case (2, 4, "soz"): Console.WriteLine(2); break;
    case (3, 4, "s"): Console.WriteLine(3); break;
    default: Console.WriteLine(0); break;
}

const string d = "as";

int i = (a, b, str) switch
{
    (1, 8, "so") => 1,
    (2, 4, "soz") => 2,
    (3, 4, d) => (a, b, str) switch
    {
        (1, 8, "so") => 1,
        (2, 4, "soz") => 2,
        (3, 4, d) => 3,
        _ => 0
    },
    _ => 0
};

Console.WriteLine(i);

switch (a)
{
    case > 4: Console.WriteLine(1); break;
    case < 2: Console.WriteLine(2); break;
    default: Console.WriteLine(0); break;
}

switch (a, b)
{
    case ( > 4, < 5): Console.WriteLine(1); break;
    case (3, 6): Console.WriteLine(2); break;
    default: Console.WriteLine(0); break;
}

// shart - a katta bolsa 1dan va kichik bolsa 5dan
// b teng bolsa 4
// a katta bolsa 1dan yoki a kichik bolsa 5dan, b teng bolsa 3

switch (a, b)
{
    case ( > 1 and < 5, 4): Console.WriteLine(1); break;
    case ( > 1 or < 5, 4): Console.WriteLine(2); break;
}

// a > 1 yoki a < 5 bo'lsa va 4 ga teng bo'lsa,b qiymati 4 ga teng bolsa

switch (a, b)
{
    case ( > 1 or (< 5 and 4), 4): Console.WriteLine(1); break;
}

