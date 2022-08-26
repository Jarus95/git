using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;

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

        for (var i = 1; i <= ticketsCount; i++)
        {
            ticketsButtons.Add($"Ticket{i}");
        }

        _telegramBotService.SendMessage(
            chatId: user.ChatId,
            message: "Tickets list",
            _telegramBotService.GetInlineKeyboard(ticketsButtons));
        user.SetStep(EUserStep.TicketList);
    }

    public void FilterText(User user, string message, int messageId)
    {

    }
}