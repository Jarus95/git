using System.Windows;
using System.Windows.Controls;

namespace Avtotest.WPF.Pages
{
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        public void StartExamination(object? sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPage.Examination);
        }
    }
}
