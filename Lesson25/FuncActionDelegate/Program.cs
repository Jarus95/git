List<int> list = new List<int>();
list.Add(0);
list.Add(1);
list.Add(4);
list.Add(6);

Func<int, bool> filterFunc = Select;

List<int> list2 = list.Where(filterFunc).ToList();

foreach (var i in list2)
{
    Console.WriteLine(i);
}

bool Select(int element)
{
    return element > 3;
}

//return type bool bo'lgan methodlar
Predicate<int> filter = Select;

var result = filter(5);
Console.WriteLine(result);