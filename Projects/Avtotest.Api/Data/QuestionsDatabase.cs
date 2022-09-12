using Avtotest.Api.Models;

namespace Avtotest.Api.Data;

public class QuestionsDatabase
{
    private static QuestionsDatabase _instance;

    public static QuestionsDatabase Instance
    {
        get
        {
            if( _instance == null )
                _instance = new QuestionsDatabase();
            return _instance;
        }
    }

    public List<Question> Questions = new List<Question>();
}