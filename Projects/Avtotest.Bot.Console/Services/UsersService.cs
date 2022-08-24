using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Models;

namespace Avtotest.Bot.Console.Services;

public class UsersService
{
    private readonly TelegramBotService _telegramBotService;

    public UsersService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    public User AddUser(Telegram.Bot.Types.User user)
    {
        var name = string.IsNullOrEmpty(user.Username) ? user.FirstName : user.Username;
        return Database.UsersDb.AddUser(user.Id, name);
    }
}