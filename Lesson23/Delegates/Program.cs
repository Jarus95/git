User user = new User(Log);
var question = new User.Question(Log);

void Log(string msg)
{
    Console.WriteLine(msg);
}

void Logv2(string message)
{
    Console.WriteLine("Log_v2 : " + message);
}

class User
{
    public delegate void LogDelegate(string message);

    public User(LogDelegate log)
    {
        log("User added");
    }

    public class Question
    {
        public Question(User.LogDelegate log)
        {
            log("question added");
        }
    }
}