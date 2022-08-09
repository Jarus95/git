int a = 7;
int b = 8;

int Add(int a, int b)
{
    return a + b;
}

Tuple<int, string> addResult = 
    new Tuple<int, string>(1, "Add");

Tuple<int, int, string> result;
result = new Tuple<int, int, string>(1, 5, "Str");

var add = result.Item3;

Console.WriteLine(add);

Tuple<int, int> Calculate(int a, int b)
{
    var add = a + b;
    var divide = a / b;

    var result = new Tuple<int, int>(add, divide);

    return result;
}

Tuple<int, int> Result = Calculate(4, 2);
var Result2 = Calculate(4, 2);

var (add2, divide) = Calculate(9, 3);

Console.WriteLine(add2 +" " + divide);


