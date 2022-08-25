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

    public void SendTicketQuestion(User user)
    {
        Queue<QuestionEntity> ticketQueue = _exams[user.ChatId];
        var question = ticketQueue.Dequeue();
        SendQuestion(user, question);
    }

    public void SendQuestion(User user, QuestionEntity question)
    {
        var choices = question.Choices.Select(choice => choice.Text).ToList();
        var correctChoice = question.Choices.First(choice => choice.Answer);
        var correctAnswerIndex = question.Choices.IndexOf(correctChoice);

        if (question.Media.Exist)
        {
            _telegramBotService.SendMessage(
                chatId: user.ChatId,
                message: question.Question,
                image: Database.GetQuestionMedia(question.Media.Name),
                reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex));
            return;
        }

        _telegramBotService.SendMessage(
            chatId: user.ChatId,
            message: question.Question,
            reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex));
    }
}