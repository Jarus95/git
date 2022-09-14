using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Avtotest.Data.Databases;

namespace Avtotest.WPF.Pages;

public partial class MainMenuPage : Page
{
    public MainMenuPage()
    {
        InitializeComponent();

        var allTicketsCount = Database.Db.TicketDb.GetTicketsCount();
        var completedTicketsCount = Database.Db.TicketDb.UserTickets.Count(t => t.IsCompleted);

        TicketStatus.Text = $"{completedTicketsCount}/{allTicketsCount}";


        var allQuestionsCount = Database.Db.QuestionsDb.Questions.Count();
        var completedQuestionsCount = Database.Db.TicketDb.UserTickets.Sum(t=> t.CorrectAnswersCount);

        QuestionsStatus.Text = $"{completedQuestionsCount}/{allQuestionsCount}";
    }

    public void StartExamination(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Examination);
    }

    private void ShowTickets(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Tickets);
    }
}