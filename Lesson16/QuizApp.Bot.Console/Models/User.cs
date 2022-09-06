namespace QuizApp.Bot.Console.Models;

public class User
{
    public long ChatId;
    public string Name;
    public int Step;

    public User(long id, string name)
    {
        ChatId = id;
        Name = name;
        Step = 0;
    }

    public User(long id, string name, int step)
    {
        ChatId = id;
        Name = name;
        Step = step;
    }

    public void SetStep(int step)
    {
        Step = step;
    }

    public string ToText()
    {
        return $"{ChatId}, Ismi: {Name}, step: {Step}";
    }
}