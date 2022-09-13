using Avtotest.Data.Models;
using Newtonsoft.Json;

namespace Avtotest.Data.Databases;

public class Database
{
    private const string UsersJsonPath = "JsonData/users.json";
    private const string QuestionsJsonPath = "JsonData/uzlotin.json";
    private const string ImagesPath = "Images";

    private static Database _database;
    public static Database Db
    {
        get
        {
            if (_database == null)
            {
                _database = new Database();
            }

            return _database;
        }
    }

    public Database()
    {
        UsersDb = new UsersDatabase(ReadUsersJson());
        QuestionsDb = new QuestionsDatabase(ReadQuestionsJson());
        TicketDb = new TicketDatabase();
    }

    public UsersDatabase UsersDb;
    public QuestionsDatabase QuestionsDb;
    public TicketDatabase TicketDb;


    private List<User> ReadUsersJson()
    {
        if (!File.Exists(UsersJsonPath)) return new List<User>();
        var json = File.ReadAllText(UsersJsonPath);

        try
        {
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize users json.");
            return new List<User>();
        }
    }

    private List<QuestionEntity> ReadQuestionsJson()
    {
        if (!File.Exists(QuestionsJsonPath)) return new List<QuestionEntity>();
        var json = File.ReadAllText(QuestionsJsonPath);

        try
        {
            return JsonConvert.DeserializeObject<List<QuestionEntity>>(json);
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize questions json.");
            return new List<QuestionEntity>();
        }
    }

    public void SaveUsers()
    {
        var json = JsonConvert.SerializeObject(UsersDb.Users);
        File.WriteAllText(UsersJsonPath, json);
    }

    public static Stream GetQuestionMedia(string imageName)
    {
        var path = Path.Combine(ImagesPath, $"{imageName}.png");
        if (File.Exists(path))
        {
            var bytes = File.ReadAllBytes(path);
            return new MemoryStream(bytes);
        }
        return null;
    }
}