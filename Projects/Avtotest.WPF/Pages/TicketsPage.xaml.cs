using System.Windows;
using System.Windows.Controls;

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
        for (int i = 0; i < 35; i++)
        {
            var button = new Button();
            button.Template = FindResource("TicketButtonTemplate") as ControlTemplate;
            button.DataContext = new { Ticket = new { Text = $"Ticket{i + 1}" } };
            if (i == 2) button.DataContext = new { Ticket = new { Text = $"Ticket{i + 1} 10/20" } };
            if (i == 3) button.DataContext = new { Ticket = new { Text = $"Ticket{i + 1} ✅" } };
            TicketButtonsPanel.Children.Add(button);
        }
    }

    private void MainMenu(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Main);
    }
}