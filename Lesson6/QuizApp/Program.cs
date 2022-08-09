Start();

void Start()
{
    Console.WriteLine("Son kiriting : ");
    var son = int.Parse(Console.ReadLine()!);
    Multiply(son);
}

void Multiply(int a)
{
    Console.WriteLine(a * a);
    Start();
}