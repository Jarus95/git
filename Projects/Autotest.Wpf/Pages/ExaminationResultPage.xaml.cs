using Avtotest.Database.Models;
using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf.Pages;

public partial class ExaminationResultPage : Page
{
    public ExaminationResultPage(Ticket ticket)
    {
        InitializeComponent();

        CorrectAnswerdCount.Text = ticket.CorrectAnswersCount.ToString();
        QuestionsCount.Text = ticket.QuestionsCount.ToString();
    }

    private void MenuButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }
}