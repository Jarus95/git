using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;
using Avtotest.Bot.Console.Options;
using Telegram.Bot.Types.ReplyMarkups;

namespace Avtotest.Bot.Console.Services;

public class ExaminationsService
{
    private readonly TelegramBotService _telegramBotService;
    private Dictionary<long, Ticket> _exams = new();

    public ExaminationsService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    public void StartExam(User user)
    {
        var ticket = CreateTicket(user.ChatId);
        DisplayTicket(user, ticket);
    }

    private Ticket CreateTicket(long chatId)
    {
        var ticket = new Ticket(chatId, CreateExamTicket());
        _exams.Add(chatId, ticket);
        return ticket;
    }

    public Queue<QuestionEntity> CreateExamTicket()
    {
        int randomNumber = new Random().Next(0, Database.Db.QuestionsDb.Questions.Count / TicketsSettings.TicketQuestionsCount);
        var questions = Database.Db.QuestionsDb.CreateTicket(randomNumber * TicketsSettings.TicketQuestionsCount, TicketsSettings.TicketQuestionsCount);
        return new Queue<QuestionEntity>(questions);
    }

    private void DisplayTicket(User user, Ticket ticket)
    {
        var message = $"Exam started\n Questions count: {ticket.QuestionsCount}";
        var buttons = _telegramBotService.GetInlineKeyboard(new List<string>() { "Start" });
        _telegramBotService.SendMessage(user.ChatId, message, buttons);
        user.SetStep(EUserStep.Exam);
    }

    public void SendTicketQuestion(User user)
    {
        var ticket = _exams[user.ChatId];
        Queue<QuestionEntity> ticketQueue = ticket.Questions;
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

        var ticket = _exams[user.ChatId];
        var questionIndex = $"[{ticket.CurrentQuestion}/{ticket.QuestionsCount}]"; 

        if (question.Media.Exist)
        {
            _telegramBotService.SendMessage(
                chatId: user.ChatId,
                message: $"{questionIndex} {question.Question}",
                image: Database.GetQuestionMedia(question.Media.Name),
                reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex, ticket.CurrentQuestion));
            return;
        }

        _telegramBotService.SendMessage(
            chatId: user.ChatId,
            message: $"{questionIndex} {question.Question}",
            reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex, ticket.CurrentQuestion));
    }

    public void CheckAnswer(User user, string message, int messageId, InlineKeyboardMarkup reply)
    {
        int[] answer;
        try
        {
            answer = message.Split(',').Select(int.Parse).ToArray();
        }
        catch
        {
            return;
        }
        var answerResult = " ❌"; ;

        if (answer[0] == answer[1])
        {
            var ticket = _exams[user.ChatId];
            ticket.CorrectAnswersCount++;
            answerResult = " ✅";
        }

        var _reply = reply.InlineKeyboard.ToArray();
        _reply[ answer[1] ].ToArray()[0].Text += answerResult;
        _telegramBotService.EditMessageButtons(user.ChatId, messageId, new InlineKeyboardMarkup(_reply));

        SendTicketQuestion(user);
    }

    public void TicketFinished(User user)
    {
        var ticket = _exams[user.ChatId];
        _telegramBotService.SendMessage(user.ChatId, $"Exam finished.\n Result: {ticket.CorrectAnswersCount}/{ticket.QuestionsCount}");
        _exams.Remove(user.ChatId);

        user.SetStep(EUserStep.Menu);
    }

}