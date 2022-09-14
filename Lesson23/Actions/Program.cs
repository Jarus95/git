Action logMethod = Log;
logMethod();

List<Action> logMethods = new List<Action>();
logMethods.Add(Log);
logMethods.Add(Logv2);

logMethods[0]();

foreach (var method in logMethods)
{
    method();
}

void Log()
{
    Console.WriteLine("msg");
}

void Logv2()
{
    Console.WriteLine("msg2");
}


//action with params

Action<int, string> action = GetInt;

action(2, "msg");

void GetInt(int a, string msg)
{

}