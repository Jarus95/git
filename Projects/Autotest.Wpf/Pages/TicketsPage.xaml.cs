using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf.Pages;

public partial class TicketsPage : Page
{
    public TicketsPage()
    {
        InitializeComponent();
        GenerateTicketButtons();
    }

    private void GenerateTicketButtons()
    {
        var questionsRepository = MainWindow.Instance.QuestionsRepository;
        int ticketsCount = questionsRepository.GetTicketsCount();

        for (int i = 0; i < ticketsCount; i++)
        {
            var button = new Button();
            button.Width = 300;
            button.Height = 40;
            button.Content = "Ticket" + (i + 1);
            button.FontSize = 20;
            button.Click += TicketButtonClick;
            button.Tag = i;

            TicketButtonsPanel.Children.Add(button);
        }
    }

    private void TicketButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var ticketIndex = (int)button.Tag;

        var examPage = new ExaminationPage(ticketIndex);
        MainWindow.Instance.MainFrame.Navigate(examPage);
    }

    private void MenuButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }
}