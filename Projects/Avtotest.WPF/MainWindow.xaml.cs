using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Avtotest.WPF.Databases;
using Avtotest.WPF.Models;

namespace Avtotest.WPF
{
    public partial class MainWindow : Window
    {
        private int currentQuestionIndex = 0;
        private Button correctAnswer;

        public MainWindow()
        {
            InitializeComponent();
            ShowQuestion();


            question.Visibility = Visibility.Hidden;
            question.IsEnabled = false;
        }

        private void SetImage(string imageName)
        {
            questionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imageName}.png")));
        }

        private void ShowQuestion()
        {
            var question = Database.Db.QuestionsDb.Questions[currentQuestionIndex];
            nextBtn.Visibility = Visibility.Hidden;

            SetImage(question.Media.Exist ? question.Media.Name : "car");
            questionText.Text = $"{currentQuestionIndex+1}. {question.Question}";
            var corectAnswetIndex = question.Choices.IndexOf(question.Choices.First(ch => ch.Answer));
            AddButtons(question.Choices.Select(q => q.Text).ToList(), corectAnswetIndex);
        }

        private void AddButtons(List<string> choices, int correctAnswerIndex)
        {
            panel.Children.Clear();
            for (int i = 0; i < choices.Count; i++)
            {
                var button = new Button();
                button.Margin = new Thickness(10, 0, 10, 10);
                button.FontSize = 16;
                button.Height = 30;
                button.Content = choices[i];
                button.Click += Button_Click;
                panel.Children.Add(button);
                
                if (i == correctAnswerIndex)
                {
                    correctAnswer = button;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (correctAnswer == button) 
                button.Background = new SolidColorBrush(Colors.Green);
            else
                button.Background = new SolidColorBrush(Colors.Red);
            nextBtn.Visibility = Visibility.Visible;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            ShowQuestion();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                currentQuestionIndex++;
                ShowQuestion();
            }
            if (e.Key == Key.Left)
            {
                currentQuestionIndex--;
                ShowQuestion();
            }
        }

        private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
        {
            menu.IsEnabled = false;
            menu.Visibility = Visibility.Hidden;
            question.Visibility = Visibility.Visible;
            question.IsEnabled = true;
        }
    }
}
