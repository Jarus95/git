using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Avtotest.Data.Databases;
using Avtotest.Data.Models;

namespace Avtotest.WPF.Pages;

public partial class TicketsPage : Page
{
    public TicketsPage()
    {
        InitializeComponent();
        GenerateTicketButtons();
    }

    private void GenerateTicketButtons()
    {
        TicketButtonsPanel.Children.Clear();
        for (int i = 0; i < Database.Db.TicketDb.GetTicketsCount(); i++)
        {
            var button = new Button();
            button.Template = FindResource("TicketButtonTemplate") as ControlTemplate;
            button.Click += StartTicket;

            //if ticket exist show result
            if (Database.Db.TicketDb.UserTickets.Any(t => t.Index == i))
            {
                var ticket = Database.Db.TicketDb.UserTickets.First(t=>t.Index == i);
                ticket.Text = ticket.IsCompleted ? $"Ticket{i + 1} ✅" 
                    : $"Ticket{i + 1} {ticket.CorrectAnswersCount}/{ticket.QuestionsCount}";

                button.DataContext = ticket;
            }
            //else default value
            else
            {
                button.DataContext = new Ticket(i, $"Ticket{i + 1}");
            }

            TicketButtonsPanel.Children.Add(button);
        }
    }

    private void StartTicket(object sender, RoutedEventArgs e)
    {
        var data = (Ticket)(sender as Button)!.DataContext;
        MainWindow.Instance.DisplayTicketPage(data.Index);
    }

    private void MainMenu(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Main);
    }
}