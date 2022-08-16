using System.Diagnostics;

int GetRaqam()
{
    return 12;
}

void Show(string soz)
{
    Console.WriteLine("Show ishga tushdi");
    Console.WriteLine(soz);
}

int QoshibBer(int a, int b)
{
    int yigindi = a + b;
    return yigindi;
}

/*int QoshibBer(string a, string b)
{
    int yigindi = int.Parse(a) + int.Parse(b);
    return yigindi;
}*/

string QoshibBerString(string a, string b)
{
    return a + b;
}

var son = GetRaqam();
string gap = "Fap map";
Show(gap);

var yigindi = QoshibBer(12, 13);
Console.WriteLine(yigindi);

Console.WriteLine(QoshibBerString("Meni ismim ", "Javlon"));

List<int> list1 = new List<int>();

/*
bool isContinue = false;
do
{
    Console.Write("Son kirit : ");
    int son = int.Parse(Console.ReadLine());

    list1.Add(son);
    Console.WriteLine("Yana kiritmoqchi bolsang 'ha' ni kirit");
    isContinue = Console.ReadLine() == "ha";
} while (isContinue);

Console.WriteLine("Siz " + list1.Count + " son kiritdingiz.");
*/

foreach (int i in list1)
{
    Console.WriteLine(i);
}

List<string> sozlar = new List<string>()
{
    "soz edi",
    "gap yozishim mumkin",
    "string nima qabul qilsa"
};

sozlar.Add("soz1");
sozlar.Add("soz2 gap ");

Console.WriteLine(sozlar[4]);

if (sozlar.Contains("soz1") == true)
{
    Console.WriteLine("Sozlar listida soz1 elementi bor ekan");
}

sozlar.Remove("soz1");

if (sozlar.Contains("soz1") == true)
{
    Console.WriteLine("Sozlar listida soz1 yana elementi bor ekan");
}
else
{
    Console.WriteLine("Sozlar listida soz1 elementi yoq ekan");
}

Console.WriteLine("Sozlar.Count = " + sozlar.Count);

for (int i = 0; i < sozlar.Count; i++)
{
    Console.WriteLine(sozlar[i]);
}