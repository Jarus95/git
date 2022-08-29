using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace Avtotest.WPF
{
    public partial class MainWindow : Window
    {
        private List<Question> Questions = new List<Question>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri(@"/2.png", UriKind.Relative));
            textbox.Text = "Changed 2from button";
        }

        private void textbox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            textbox.FontSize = 20;
            textbox.Text = "Mouse on me";
            panel.Visibility = Visibility.Hidden;
        }

        private void textbox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            textbox.Text = "Mouse leave";
            AddButtons();
            panel.Visibility = Visibility.Visible;

        }

        public void AddButtons()
        {
            for (int i = 0; i < 4; i++)
            {
                var button = new Button();
                button.Content = "Variant" + i;
                button.Width = 80;
                button.Height = 40;
                button.Margin = new Thickness(0, 0, 0, 20);
                button.Click += ButtonBase_OnClick;
                panel.Children.Add(button);
            }
        }
    }
}
