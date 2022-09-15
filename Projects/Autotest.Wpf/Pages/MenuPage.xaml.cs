using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf.Pages;

public partial class MenuPage : Page
{
    public MenuPage()
    {
        InitializeComponent();
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