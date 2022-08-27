using Avtotest.Bot.Console.Models;
using Avtotest.Bot.Console.Options;

namespace Avtotest.Bot.Console.Databases;

public class TicketDatabase
{
    public Dictionary<long, List<Ticket>> UserTickets { get; set; }

    public TicketDatabase()
    {
        UserTickets = new Dictionary<long, List<Ticket>>();
    }

    public List<Ticket> GetOrAddUserTickets(User user)
    {
        if (UserTickets.ContainsKey(user.ChatId))
        {
            return UserTickets[user.ChatId];
        }

        var tickets = new List<Ticket>();
        UserTickets.Add(user.ChatId, tickets);
        return tickets;
    }

    public int GetTicketsCount()
    {
        return Database.Db.QuestionsDb.Questions.Count / TicketsSettings.TicketQuestionsCount;
    }

    public void AddTicket(long chatId, Ticket ticket)
    {
        var tickets = UserTickets[chatId];
        if (tickets.Any(t => t.Index == ticket.Index))
        {

        }
        tickets.Add(ticket);
    }
}