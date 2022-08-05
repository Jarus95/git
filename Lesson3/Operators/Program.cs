bool a = true;
bool b = !a;

if(b) // b ni qiymati false
    Console.WriteLine("True");

bool c = a || b;

// 1 || 1 = 1
// 1 || 0 = 1
// 0 || 1 = 1
// 0 || 0 = 0

c = a && b;

// 1 && 1 = 1
// 1 && 0 = 0
// 0 && 1 = 0
// 0 && 0 = 0

c = !c || !a && b || (a && b);

Console.WriteLine(c);

int t = 9;
if(t == 6 && (t == int.Parse(null) && t == 3))
    Console.WriteLine(t);
