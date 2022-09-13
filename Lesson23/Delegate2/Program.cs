using Delegate2;

Calculate cal = Sum;

var sum = cal(2, 4);

cal = Divide;
var d = cal(10, 2);

Console.WriteLine(sum);
Console.WriteLine(d);

int Sum(int a, int b)
{
    return a + b;
}

int Divide(int a, int b)
{
    return a / b;
}

namespace Delegate2
{
    delegate int Calculate(int a, int b);
}
