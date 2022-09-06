using ReadonlyConst;

string a = "9";
object aObj = a;

try
{
    int son = (int)aObj;
    Console.WriteLine(son);
}
catch
{
    Console.WriteLine("aObj int emas");
}









User user = new User();
user.SetName("NewName");

//user.Age = 8; //error
Console.WriteLine(user.Name);

Console.WriteLine();


namespace ReadonlyConst
{
    class User
    {
        public string Name;
        public readonly int Age; // = 18;
        public const int AgeLimit = 16;
        public static int Id = 0;

        public User()
        {
            //AgeLimit = 0;
            Id = 1;
        }

        public User(int age)
        {
            Age = age;
        }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAge(int age)
        {
            //Age = age; error
            //AgeLimit = 12; error
            Id = 3;
        }
    }
}