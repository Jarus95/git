using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;

namespace Avtotest.Bot.Console.Services;

public class ExaminationsService
{
    private readonly TelegramBotService _telegramBotService;
    private Dictionary<long, Queue<QuestionEntity>> _exams = new();

    public ExaminationsService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    public void StartExam(User user)
    {
        var ticket = CreateTicket(user.ChatId);
        DisplayTicket(user, ticket);
    }

    private Queue<QuestionEntity> CreateTicket(long chatId)
    {
        var questions = Database.QuestionsDb.CreateTicket();
        var questionsQueue = new Queue<QuestionEntity>(questions);
        _exams.Add(chatId, questionsQueue);
        return questionsQueue;
    }

    private void DisplayTicket(User user, Queue<QuestionEntity> ticket)
    {
        var message = $"Exam started\n Questions count: {ticket.Count}";
        var buttons = _telegramBotService.GetInlineKeyboard(new List<string>() { "Start" });
        _telegramBotService.SendMessage(user.ChatId, message, buttons);
        user.SetStep(EUserStep.Exam);
    }
}