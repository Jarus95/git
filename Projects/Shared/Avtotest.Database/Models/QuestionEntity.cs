namespace Avtotest.Database.Models;

public class QuestionEntity
{
    public int Id;
    public string Question;
    public string Description;
    public List<Choice> Choices;
    public Media Media;
    public bool IsCompleted;
    public bool IsCorrected;
}

public class Choice
{
    public string Text;
    public bool Answer;
    public bool IsSelected;
}

public class Media
{
    public bool Exist;
    public string Name;
}