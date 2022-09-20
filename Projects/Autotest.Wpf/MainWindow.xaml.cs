using Autotest.Wpf.Pages;
using System.Windows;
using Avtotest.Database;

namespace Autotest.Wpf;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public QuestionsRepository QuestionsRepository;
    public TicketsRepository TicketsRepository;
    public int CorrectCount;

    public MainWindow()
    {
        InitializeComponent();

        Instance = this;
        QuestionsRepository = new QuestionsRepository();
        TicketsRepository = new TicketsRepository();
        var menuPage = new MenuPage();
        MainFrame.Navigate(menuPage);
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        TicketsRepository.WriteToJson();
    }
}