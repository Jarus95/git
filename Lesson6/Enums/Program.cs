using Enums;

Console.WriteLine("1, Qoshiq");
Console.WriteLine("2, Qoshiq");
Console.WriteLine("3, Qoshiq");
Console.WriteLine("4, Qoshiq");

var a = (Menu)int.Parse(Console.ReadLine()!);

switch (a)
{
    case Menu.StartTest: break;
    case Menu.AddQuestion: break;
    case Menu.Dashboard: break;
    case Menu.Statistics: break;
}

Console.WriteLine(a);

namespace Enums
{
    enum Menu
    {
        StartTest = 1,
        AddQuestion, //2
        Dashboard = 10,  //10
        Statistics = 12
    }
}



