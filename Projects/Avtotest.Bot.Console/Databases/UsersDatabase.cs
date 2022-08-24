using Avtotest.Bot.Console.Models;

namespace Avtotest.Bot.Console.Databases;

public class UsersDatabase
{
    public List<User> Users { get; set; }

    public UsersDatabase(List<User> users)
    {
        Users = users;
    }

    public User AddUser(long chatId, string name)
    {
        if (Users.Any(user => user.ChatId == chatId))
        {
            return Users.First(user => user.ChatId == chatId);
        }

        var user = new User(chatId, name);
        Users.Add(user);
        return user;
    }
}