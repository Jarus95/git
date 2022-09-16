using Avtotest.Database.Models;
using Newtonsoft.Json;

namespace Avtotest.Database;

public class QuestionsRepository
{
    public List<QuestionEntity> Questions { get; set; }

    public QuestionsRepository()
    {
        LoadQuestionsFromJsonFile();
    }

    public void LoadQuestionsFromJsonFile()
    {
        var jsonStringData = File.ReadAllText("JsonData/uzlotin.json");
        
        Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonStringData);
    }
}