using Avtotest.Bot.Console.Models;
using System.Text.Json;

namespace Avtotest.Bot.Console.Databases;

public class Database
{
    private const string UsersJsonPath = "JsonData/users.json";
    private const string QuestionsJsonPath = "JsonData/uzlotin.json";

    private static UsersDatabase _usersDatabase;
    public static UsersDatabase UsersDb
    {
        get
        {
            if (_usersDatabase == null)
            {
                _usersDatabase = new UsersDatabase(ReadUsersJson());
            }

            return _usersDatabase;
        }
    }

    private static QuestionsDatabase _questionsDatabase;
    public static QuestionsDatabase QuestionsDb
    {
        get
        {
            if (_questionsDatabase == null)
            {
                _questionsDatabase = new QuestionsDatabase(ReadQuestionsJson());
            }

            return _questionsDatabase;
        }
    }

    private static List<User> ReadUsersJson()
    {
        if (!File.Exists(UsersJsonPath)) return new List<User>();
        var json = File.ReadAllText(UsersJsonPath);

        try
        {
            return JsonSerializer.Deserialize<List<User>>(json);
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize users json.");
            return new List<User>();
        }
    }

    private static List<QuestionEntity> ReadQuestionsJson()
    {
        if (!File.Exists(QuestionsJsonPath)) return new List<QuestionEntity>();
        var json = File.ReadAllText(QuestionsJsonPath);

        try
        {
            return JsonSerializer.Deserialize<List<QuestionEntity>>(json);
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize questions json.");
            return new List<QuestionEntity>();
        }
    }

    public void SaveUsers()
    {
        var json = JsonSerializer.Serialize(UsersDb.Users);
        File.WriteAllText(UsersJsonPath, json);
    }
}