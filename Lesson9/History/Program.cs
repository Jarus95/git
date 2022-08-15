int son2 = 4;
float haqiqiy = 4.5F;
string satr = "ismi adads";
//int a = "adsa";
char belgi = '$';
char belgi2;
belgi2 = '3';
bool isTrue2 = true; //false

string uzgaruvchi = Console.ReadLine();

int men = 2;
int Ismim = 3;

int gap = men + Ismim;

Console.WriteLine(gap);

int[] massiv = new int[4];
massiv[0] = 3;
massiv[1] = 4;
massiv[2] = 5;
massiv[3] = 6;
//massiv[4] = 7;
//massiv[5] = 8;

string[] sozlar = new string[3]
{
    "adas",
    "adad",
    "asd"
};

sozlar = new string[]
{
    "men",
    "sen",
    "ular"
};

for (int i = 0; i < sozlar.Length; i++)
{
    Console.WriteLine(sozlar[i]);
}

int k = 0;
while (k < sozlar.Length)
{
    Console.WriteLine(sozlar[k]);
    k++;
}

k = 0;
do
{
    Console.WriteLine(sozlar[k]);
} while (k < sozlar.Length);


int[] ms = new int[4];

for (int i = 0; i < ms.Length; i++)
{
    ms[i] = int.Parse(Console.ReadLine()!);
}

foreach (int s1 in massiv)
{
    Console.WriteLine(s1);
}

int a = 0;
string s = default;
Console.WriteLine(s);
int? ad = null;

int t = 0;

switch (t)
{
    case 0:
        {
            Console.WriteLine("0 ga teng");
            Console.WriteLine("0 ga teng");
        }
        break;
    case 1:
        Console.WriteLine("1ga teng");
        break;
}


List<string> nomlar = new List<string>();
nomlar.Add("asd");

int[] massiv4 = new int[4];

List<int> list = new List<int>();
list.Add(2);
list.Add(4);
list.Add(52);

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

var son = GetSon();

string GetSon()
{
    string a = "8";
    return a;
}

Show("Salom");

void Show(string soz)
{
    Console.WriteLine(soz);
    return;
}