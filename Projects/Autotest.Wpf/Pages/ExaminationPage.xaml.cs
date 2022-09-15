using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf.Pages;

public partial class ExaminationPage : Page
{
    public ExaminationPage(int? currentTicketIndex = null)
    {
        InitializeComponent();
        GenerateChoiceButtons();

        if (currentTicketIndex != null)
        {
            Title.Content = $"Ticket{currentTicketIndex}";
        }
    }

    private void GenerateChoiceButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            var button = new Button();
            button.Width = 300;
            button.Height = 30;
            button.FontSize = 14;
            button.Content = "Variant" + i;
            button.Click += ChoiceButtonClick;
            button.Tag = i;

            ChoicePanel.Children.Add(button);
        }
    }

    private void ChoiceButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var choiceIndex = (int)button.Tag;
        MessageBox.Show(choiceIndex + " indexi tanlandi");
    }

    private void MenuButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }
}