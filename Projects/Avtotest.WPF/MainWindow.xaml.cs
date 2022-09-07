using System;
using System.Windows;
using Avtotest.WPF.Pages;

namespace Avtotest.WPF
{
    public partial class MainWindow : Window
    {
        private static MainWindow? _instance;
        public static MainWindow Instance
        {
            get
            {
                if( _instance == null )
                    _instance = new MainWindow();
                return _instance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;

            //Frame.Source = new Uri(@"Pages/MainMenuPage.xaml", UriKind.Relative);
            MainFrame.Navigate(new MainMenuPage());
        }

        public void DisplayPage(EPage page)
        {
            switch (page)
            {
                case EPage.Examination:
                    MainFrame.Navigate(new ExaminationPage());
                    break;
            }
        }
    }
}
