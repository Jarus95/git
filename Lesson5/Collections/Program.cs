List<int> sonlar = new List<int>();
List<string> sozlar = new List<string>()
{
    "sd",
    "ds"
};

List<char> letters = new List<char>() { 'a', 'f' , '3'};

var belgi = letters[1]; // belgi = 'f';

var sonlarCount = sonlar.Count; // 0

sonlar.Add(3);
sozlar.Add("Soz1");

sonlar.Add(2);
sonlar.Remove(2);

var index = sonlar.IndexOf(2);

var belgilar = letters.Skip(1).Take(1); // { 'f' }

if (!sonlar.Contains(2))
{
    Console.WriteLine("2 mavud emas");
}
