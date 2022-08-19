//Main
Console.WriteLine("Start");

class User
{
    public string ChatId;
    private string Name;

    public User()
    {
        Name = "Userni ismi";
        var userChatId = GetUserNameWithChatId();
    }

    public string ToText()
    {
        //userChatId = "fa";
        return $"Ismi {Name}";
    }

    public string GetUserName()
    {
        return Name;
    }

    private string GetUserNameWithChatId()
    {
        return Name + ChatId;
    }
}

class Question
{
    User user;

    public Question()
    {
        user = new User();
        user.ChatId = "User ismi";
        var userName = user.GetUserName();
    }
}