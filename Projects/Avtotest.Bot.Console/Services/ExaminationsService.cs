using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace Avtotest.Bot.Console.Services;

public class ExaminationsService
{
    private readonly TelegramBotService _telegramBotService;
    private readonly int ticketQuestionsCount = 10;
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
        Random rand = new Random();
        int randomNumber = rand.Next(0, Database.QuestionsDb.Questions.Count / ticketQuestionsCount);
        var questions = Database.QuestionsDb.CreateTicket(randomNumber * ticketQuestionsCount, ticketQuestionsCount);
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
        if(ticketQueue == null || ticketQueue.Count == 0)
        {
            TicketFinished(user);
            return;
        }
        var question = ticketQueue.Dequeue();
        SendQuestion(user, question);
        user.SetStep(EUserStep.ExamStarted);
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

    public void CheckAnswer(User user, string message, int messageId, InlineKeyboardMarkup reply)
    {
        var answer = message.Split(',').Select(int.Parse).ToArray();
        var answerResult = answer[0] == answer[1] ? " ✅" : " ❌";
        var _reply = reply.InlineKeyboard.ToArray();
        _reply[ answer[1] ].ToArray()[0].Text += answerResult;
        _telegramBotService.EditMessageButtons(user.ChatId, messageId, new InlineKeyboardMarkup(_reply));

        SendTicketQuestion(user);
    }

    public void TicketFinished(User user)
    {
        user.SetStep(EUserStep.Menu);
        _telegramBotService.SendMessage(user.ChatId, "Exam finished.");
        _exams.Remove(user.ChatId);
    }
}