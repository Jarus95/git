using Avtotest.WPF.Enums;

namespace Avtotest.WPF.Models;

public class User
{
    public long ChatId { get; set; }
    public string Name { get; set; }
    public EUserStep Step { get; set; }
    public int OldMessageId { get; set; }

    public User(long chatId, string name)
    {
        ChatId = chatId;
        Name = name;
        Step = 0;
    }

    public void SetStep(EUserStep step)
    {
        Step = step;
    }
}