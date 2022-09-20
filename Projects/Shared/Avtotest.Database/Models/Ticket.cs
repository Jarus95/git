namespace Avtotest.Database.Models;

public class Ticket
{
    public int Index;
    public int CorrectAnswersCount;
    public List<QuestionEntity> Questions;
    public List<int> SelectedQuestionIndexs;
    public bool TicketCompleted
    {
        get
        {
            return CorrectAnswersCount == QuestionsCount;
        }
    }
    public int QuestionsCount
    {
        get
        {
            return Questions.Count;
        }
    }

    public Ticket(int index, List<QuestionEntity> questions)
    {
        Index = index;
        Questions = questions;
        SelectedQuestionIndexs = new List<int>();
    }
}