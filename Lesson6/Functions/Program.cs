var a = 8;
var b = 5;

int Add(int x, int y, int z = 0)
{
    return x + y + z;
}

var c = Add(a, b);

var sum = Add(a, b, 6);

Console.WriteLine(c);

int[] ms = {1, 2, 3, 4, 5};

ShowMs(ms, ",");
ShowMs(ms, " ", y: 4);

void ShowMs(int[] ms, string s = "", int a = 0, int b = 0, int y =0)
{
    foreach (var i in ms)
    {
        Console.Write(i + s);
    }

    Console.WriteLine();
}

