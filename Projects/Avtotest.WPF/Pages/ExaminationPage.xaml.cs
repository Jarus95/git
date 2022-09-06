using System.Collections.Generic;
using System.Windows;
using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Avtotest.WPF.Databases;

namespace Avtotest.WPF.Pages
{
    public partial class ExaminationPage : Page
    {
        public ExaminationPage()
        {
            InitializeComponent();
            ShowQuestion();
        }

        private int currentQuestionIndex = 0;
        private Button correctAnswer;
        
        private void SetImage(string imageName)
        {
            questionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imageName}.png")));
        }

        private void ShowQuestion()
        {
            var question = Database.Db.QuestionsDb.Questions[currentQuestionIndex];
            nextBtn.Visibility = Visibility.Hidden;

            SetImage(question.Media.Exist ? question.Media.Name : "car");
            questionText.Text = $"{currentQuestionIndex + 1}. {question.Question}";
            var correctAnswetIndex = question.Choices.IndexOf(question.Choices.First(ch => ch.Answer));
            AddButtons(question.Choices.Select(q => q.Text).ToList(), correctAnswetIndex);
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
    }
}
