int[] sonlar = new int[] { 1, 2, 3, 4, 5 };

for (int i = 0; i < sonlar.Length; i++)
{
    Console.Write(sonlar[i]);
}

Console.WriteLine();

int j = 0;
while (j < sonlar.Length)
{
    Console.Write(sonlar[j]);
    j++;
}

Console.WriteLine();

j = 0;
do
{
    Console.Write(sonlar[j]);
    j++;
}
while (j < sonlar.Length);

Console.WriteLine();

foreach (var son in sonlar)
{
    Console.Write(son);
}

Console.WriteLine();
var a = 5;

if (a == 5)
    Console.WriteLine(a);
else Console.WriteLine(a * 2);

// type variableName = condition ? value1 : value2;

var b = a == 5 ? a : a * 2;

Console.WriteLine(b);

Console.WriteLine("\n\n\n\n");

var c = 7;

switch (c)
{
    case 5:
        {
            Console.WriteLine("Son 5ga teng");
        }
        break;
    case 6: Console.WriteLine(c); break;
    default: Console.WriteLine($"{c} hech bir shartga togri kelmadi"); break;
}


Console.WriteLine("Son kiriting");
var str = "34";

Console.WriteLine(string.Format("Siz {0} ni kiritingiz {1}", str, "."));

//int number = Convert.ToInt32(str);

//string soz = number.ToString();
//string soz = Convert.ToString(number);
//string soz = "" + number;

int number = 5;

bool isInt = int.TryParse("0", out int n);
if (n == default)
    number = n;
Console.WriteLine(number);

Console.WriteLine("\n\nNullable types\n\n");

string s = default;
bool t = default;
int f = default;

// Nullable<type> name = default; // null;'

int? regionId = null; // Nullable<int>

var input = "0";
if (!string.IsNullOrEmpty(input))
    regionId = int.Parse(input);

if (regionId == null)
    Console.WriteLine("Siz regionId kiritmadingiz");

var regionName = "";
switch (regionId)
{
    case 0: regionName = "Toshkent"; break;
    case 1: regionName = "Samarqand"; break;
}

Console.WriteLine("Siz " + regionName + "ni tanladingiz");


Console.WriteLine("\nBoolen type \n");

bool? isTrue = default;
Console.WriteLine(isTrue);


string v1 = string.Empty;
string? v2 = default;

// ? bu har qanday type ni default qiymatini null ga ozgartiradi
// agar "nullable type" har qanday holatda qiymatga ega bolishiga ishonchimiz komil bolsa 
// ! belgi aniq qiymatga (null bolmagan) ega bolishini anglatadi

Model? model = null;

if (Console.ReadLine() == "t")
    model = new Model();

var age = model!.Entity!.Age;

Console.WriteLine(age);

class Model
{
    public Entity? Entity { get; set; }
}

class Entity
{
    public int Age { get; set; } = 12;
}