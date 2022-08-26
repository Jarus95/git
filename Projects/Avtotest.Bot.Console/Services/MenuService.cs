using Avtotest.Bot.Console.Databases;
using Avtotest.Bot.Console.Enums;
using Avtotest.Bot.Console.Models;

namespace Avtotest.Bot.Console.Services
{
    public class MenuService
    {
        private readonly TelegramBotService _telegramBotService;
        private readonly ExaminationsService _examinationsService;
        private readonly TicketService _ticketService;

        public MenuService(TelegramBotService telegramBotService, ExaminationsService examinationsService, TicketService ticketService)
        {
            _telegramBotService = telegramBotService;
            _examinationsService = examinationsService;
            _ticketService = ticketService;
        }

        public void SendMenu(User user)
        {
            var menu = new List<string>() { "Ticket", " Examination" };
            _telegramBotService.SendMessage(user.ChatId, "Choose menu", _telegramBotService.GetKeyboard(menu));
            user.SetStep(EUserStep.Menu);
        }

        public void TextFilter(User user, string message)
        {
            switch (message)
            {
                case "Ticket": _ticketService.DisplayTickets(user); break;
                case "Examination": _examinationsService.StartExam(user); break;
            }
        }

        public void TextFilterExam(User user, string message)
        {
            switch (message)
            {
                case "Menu": SendMenu(user); break;
                case "Start": _examinationsService.SendTicketQuestion(user); break;
            }
        }
    }
}
