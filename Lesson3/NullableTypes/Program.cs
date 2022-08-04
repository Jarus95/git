int? son = default; // null
int raqam = default; // 0

Console.WriteLine("Son kirit : ");

string? input = null;
string str = input ?? "1"; // ?? agar null bolsa

son = int.Parse(str);
Console.WriteLine($"Son = {son}");

string str2 = string.Empty;
if (input == null)
    str2 = "1";
else
    str2 = input;

Console.WriteLine(str2);

Console.WriteLine("\n");

input = "12";
input ??= "true"; // agar nullga teng bolsa qiymatini 1 ga tengla

Console.WriteLine(input);

// Savollar - Natija nima chiqadi?

// 1
int? a = default;
int? b = 4;
Console.WriteLine(a ?? b);

// 2
int? c = 2;
Console.WriteLine(c ?? b ?? a);

// 3
a = a ?? b ?? c;
Console.WriteLine(a);

// 4
a ??= c;
Console.WriteLine(a);

// 5
b = b ?? c;
Console.WriteLine(b);

// 6 
int? d = default;
b = default;
a = d ?? (b ?? c);
Console.WriteLine(a);