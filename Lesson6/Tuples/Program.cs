var a = 7;
var b = 8;

int Add(int a, int b)
{
    return a + b;
}

var addResult =
    new Tuple<int, string>(1, "Add");

Tuple<int, int, string> result;
result = new Tuple<int, int, string>(1, 5, "Str");

var add = result.Item3;

Console.WriteLine(add);

Tuple<int, int> Calculate(int a, int b)
{
    return new Tuple<int, int>(a + b, a / b);
}

var result2 = Calculate(4, 2);
var result3 = Calculate(4, 2);

var (add2, divide) = Calculate(9, 3);

Console.WriteLine(add2 + " " + divide);
