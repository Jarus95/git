Dictionary<string, string> uzbek;
uzbek = new Dictionary<string, string>();
uzbek.Add("menu", "Mundarija");
uzbek.Add("correct", "Togri");

Dictionary<string, string> russian = new Dictionary<string, string>();
russian.Add("menu", "Menu");
russian.Add("correct", "Pravilna");
russian.Add("answer", "Atvet");

string b = string.Empty;
string a = default;
string? s = default;



Dictionary<string, string> english = new Dictionary<string, string>()
{
    {"menu", "Menu"},
    {"correct", "Correct"},
    //{"correct", "Correct"} - key bir xil bo'lishi mumkin emas
};

Dictionary<string, string> appLang;

var input = (Langs)int.Parse(Console.ReadLine()!);

switch (input)
{
    case Langs.Russain: appLang = russian; break;
    case Langs.Uzbek: appLang = uzbek; break;
    case Langs.English: appLang = english; break;
    default: appLang = english; break;
}

Console.WriteLine(appLang["menu"]);
Console.WriteLine(appLang["correct"]);

if (appLang.ContainsKey("answer"))
    Console.WriteLine(appLang["answer"]);

if (appLang.TryGetValue("answer", out string? answer))
    Console.WriteLine(answer);

var ms = appLang.ToArray();

foreach (var m in ms)
{
    Console.WriteLine(m.Key);
}

enum Langs
{
    Uzbek,
    Russain,
    English
}

