namespace Avtotest.Data.Models;

public class User
{
    public string Name { get; set; }

    public User(long chatId, string name)
    {
        Name = name;
    }
}