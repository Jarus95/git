namespace Avtotest.Bot.Console.Models;

public class Ticket
{
    public long ChatId { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }

    public Ticket(long chatId)
    {
        ChatId = chatId;
        QuestionsCount = 0;
        CorrectAnswersCount = 0;
    }
}