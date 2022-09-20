using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf.Pages;

public partial class MenuPage : Page
{
    public MenuPage()
    {
        InitializeComponent();
        var completedQuestionsCount = MainWindow.Instance.CorrectCount;
        var totalQuestionCount = MainWindow.Instance.QuestionsRepository.Questions.Count;
        QuestionStatus.Text = $"{completedQuestionsCount}/{totalQuestionCount}";

        var completedTicketsCount = MainWindow.Instance.TicketsRepository.UserTickets.Count(t => t.TicketCompleted);
        var totalTicketQuestionCount = MainWindow.Instance.QuestionsRepository.GetTicketsCount();
        TicketStatus.Text = $"{completedTicketsCount}/{totalTicketQuestionCount}";
    }

    public void TicketButtonClick(object obj, RoutedEventArgs eventArgs)
    {
        MainWindow.Instance.MainFrame.Navigate(new TicketsPage());
    }

    private void ExaminationButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new ExaminationPage());
    }
}