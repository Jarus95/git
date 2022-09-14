using Events;

User.UserAddedEvent += Log;
User.UserAddedEvent += Save;

var user = new User("user1");

User.UserAddedEvent -= Save;

var user2 = new User("user2");

void Log(string message)
{
    Console.WriteLine("log: " + message);
}

void Save(string message)
{
    //save message
    Console.WriteLine(message + " saved.");
}


namespace Events
{
    delegate void LogDelegate(string message);
}
