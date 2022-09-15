using Autotest.Wpf.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Autotest.Wpf;

public partial class MainWindow : Window
{
    public static MainWindow Instance;

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;

        var menuPage = new MenuPage();
        MainFrame.Navigate(menuPage);
    }

}