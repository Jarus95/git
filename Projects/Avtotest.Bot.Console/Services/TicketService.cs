using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;
using Avtotest.Bot.Console.Options;
using Telegram.Bot.Types.ReplyMarkups;

namespace Avtotest.Bot.Console.Services;

public class TicketService
{
    private readonly TelegramBotService _telegramBotService;

    public TicketService(TelegramBotService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }

    public void DisplayTickets(User user)
    {
        var ticketsCount = Database.Db.TicketDb.GetTicketsCount();
        var ticketsButtons = new List<string>();


        //get users ticket list from dic
        var tickets = Database.Db.TicketDb.GetOrAddUserTickets(user);

        for (var i = 0; i < ticketsCount; i++)
        {
            var ticketText = $"Ticket{i + 1}";
            //any ticket index == i
            //iscompleted = ✅
            // - [8/10]
            if (tickets.Any(t => t.Index == i))
            {
                var ticket = tickets.First(t => t.Index == i);
                if (ticket.IsCompleted)
                {
                    ticketText += " ✅";
                }
                else
                {
                    ticketText += $" - [{ticket.CorrectAnswersCount}/{ticket.QuestionsCount}]";
                }
            }

            ticketsButtons.Add(ticketText);
        }

        _telegramBotService.SendMessage(
            chatId: user.ChatId,
            message: "Tickets list",
            _telegramBotService.GetInlineTicketsKeyboard(ticketsButtons));
        user.SetStep(EUserStep.TicketList);
    }

    public void FilterText(User user, string message, int messageId)
    {
        //700, 35, 30 - 600:620
        //opennewticketslist
        //opennewticket
        //wait to start
        Database.Db.TicketDb.GetOrAddUserTickets(user);

        var from = int.Parse(message) * TicketsSettings.TicketQuestionsCount;
        var questions = Database.Db.QuestionsDb.CreateTicket(from, TicketsSettings.TicketQuestionsCount);

        var ticket = new Ticket(user.ChatId, int.Parse(message), new Queue<QuestionEntity>(questions));

        Database.Db.TicketDb.AddTicket(user.ChatId, ticket);

        //show ticket
        DisplayTicket(user, ticket);

        //set step to ticketStarting
        user.SetStep(EUserStep.TicketStarting);
    }

    public void DisplayTicket(User user, Ticket ticket)
    {
        string message = $"Ticket{ticket.Index + 1}\n Question count: {ticket.QuestionsCount}";
        var buttons = _telegramBotService.GetInlineTicketsKeyboard(new List<string>() { "Start" }, ticket.Index);
        _telegramBotService.SendMessage(user.ChatId, message, buttons);
    }

    public void StartTicket(User user, string message, int messageId)
    {
        SendTicketQuestion(user, int.Parse(message));
    }

    public void SendTicketQuestion(User user, int ticketIndex)
    {
        //get ticket list from dic
        var tickets = Database.Db.TicketDb.GetOrAddUserTickets(user);

        //get ticket from list
        var ticket = tickets.First(t => t.Index == ticketIndex);

        //dequeue question from ticket questions
        //todo check queue count
        if (ticket.Questions.Count == 0)
        {
            //quesitons ended
            string message = $"Questions ended\n Result: [{ticket.CorrectAnswersCount}/{ticket.QuestionsCount}]";
            _telegramBotService.SendMessage(user.ChatId, message);
            user.SetStep(EUserStep.Menu);
            return;
        }

        var question = ticket.Questions.Dequeue();

        //display question
        DisplayQuestion(user, question, ticket);

        //set step ticketStarted
        user.SetStep(EUserStep.TicketStarted);
    }

    public void DisplayQuestion(User user, QuestionEntity question, Ticket ticket)
    {
        var choices = question.Choices.Select(choice => choice.Text).ToList();
        var correctChoice = question.Choices.First(choice => choice.Answer);
        var correctAnswerIndex = question.Choices.IndexOf(correctChoice);

        var questionIndex = $"[{ticket.CurrentQuestion}/{ticket.QuestionsCount}]";

        if (question.Media.Exist)
        {
            _telegramBotService.SendMessage(
                chatId: user.ChatId,
                message: $"{questionIndex} {question.Question}",
                image: Database.GetQuestionMedia(question.Media.Name),
                reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex, ticket.CurrentQuestion, ticket.Index));
            return;
        }

        _telegramBotService.SendMessage(
            chatId: user.ChatId,
            message: $"{questionIndex} {question.Question}",
            reply: _telegramBotService.GetInlineKeyboard(choices, correctAnswerIndex, ticket.CurrentQuestion, ticket.Index));
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
        var ticketIndex = answer[3];

        if (answer[0] == answer[1])
        {
            var tickets = Database.Db.TicketDb.GetOrAddUserTickets(user);
            var ticket = tickets.First(t => t.Index == ticketIndex);
            ticket.CorrectAnswersCount++;
            answerResult = " ✅";
        }

        var _reply = reply.InlineKeyboard.ToArray();
        _reply[answer[1]].ToArray()[0].Text += answerResult;
        _telegramBotService.EditMessageButtons(user.ChatId, messageId, new InlineKeyboardMarkup(_reply));

        System.Threading.Thread.Sleep(1000);
        SendTicketQuestion(user, ticketIndex);
    }
}