using User = QuizApp.Bot.Console.Models.User; 
namespace QuizApp.Bot.Console.Services;

public class UsersDatabase
{
    public List<User> Users = new List<User>();
    
    public User AddUser(long chatId, string name)
    {
        //check user exist or not
        if (Users.Any(user => user.ChatId == chatId))
        {
            // user exist, return
            return Users.FirstOrDefault(u => u.ChatId == chatId)!;
        }

        var user = new User(chatId, name);
        Users.Add(user);
        return user;
    }

    public User? GetUser(long chatId)
    {
        //find user
        //return result
        return Users.FirstOrDefault(user => user.ChatId == chatId);
    }

    public string GetUsersText()
    {
        string usersText = "";
        for (int i = 0; i < Users.Count; i++)
        {
            usersText += Users[i].ToText() + "\n";
        }
        return usersText;
    }
}
