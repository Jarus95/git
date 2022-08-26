namespace Avtotest.Bot.Console.Models;

public class Ticket
{
    public long ChatId { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }
    public Queue<QuestionEntity> Questions { get; set; }

    public int CurrentQuestion
    {
        get
        {
            return QuestionsCount - Questions.Count;
        }
    }

    public Ticket(long chatId, Queue<QuestionEntity> questions)
    {
        ChatId = chatId;
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
    }
}