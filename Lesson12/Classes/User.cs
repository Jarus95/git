class User
{
    //field, method, property, ...
    public string Name;
    public int Step;
    public long ChatId;
    
    public User(long chatId, string name)
    {
        Name = name;
        ChatId = chatId;
        Step = 0;
    }

    public User(long chatId, string name, int step)
    {
        Name = name;
        Step = step;
        ChatId = chatId;
    }

    public string ToText()
    {
        return $"Id: {ChatId}, Name: {Name}, step: {Step}";
    }
}