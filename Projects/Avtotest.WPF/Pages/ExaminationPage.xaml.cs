using Avtotest.WPF.Databases;
using Avtotest.WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Avtotest.WPF.Pages
{
    public partial class ExaminationPage : Page
    {
        public ExaminationPage()
        {
            InitializeComponent();
            ShowQuestion();
            GenerateQuestionIndexButtons();
        }

        private int currentQuestionIndex = 0;

        private void SetImage(string imageName)
        {
            questionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imageName}.png")));
        }

        private void ShowQuestion()
        {
            var question = Database.Db.QuestionsDb.Questions[currentQuestionIndex];
            SetImage(question.Media.Exist ? question.Media.Name : "car");
            QuestionText.Text = $"{currentQuestionIndex + 1}. {question.Question}";
            AddButtons(question.Choices);
        }

        private void AddButtons(List<Choice> choices)
        {
            ChoicesPanel.Children.Clear();
            for (int i = 0; i < choices.Count; i++)
            {
                var button = new Button();
                button.Style = FindResource("ChoiceButtonStyle") as Style;
                button.Click += ChoiseSelected;
                button.DataContext = choices[i];

                ChoicesPanel.Children.Add(button);
            }
        }

        private void GenerateQuestionIndexButtons()
        {
            for (int i = 0; i < 20; i++)
            {
                var button = new Button();
                button.Style = FindResource("QuestionIndexButtonStyle") as Style;
                button.Content = i + 1;
                button.Tag = i;
                button.Click += QuestionIndexSelected;
                QuestionsIndexPanel.Children.Add(button);
            }
        }

        private void QuestionIndexSelected(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex = (int)(sender as Button)!.Tag;
            ShowQuestion();
        }

        private void ChoiseSelected(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var bag = button.DataContext as Choice;
            if (bag.Answer)
                button.Background = new SolidColorBrush(Colors.LightGreen);
            else
                button.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
