using Avtotest.WPF.Databases;
using Avtotest.WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            int animTime = 0;
            for (int i = 0; i < choices.Count; i++)
            {
                var button = new Button();
                button.Style = FindResource("ChoiceButtonStyle") as Style;
                button.Click += ChoiseSelected;
                button.DataContext = choices[i];

                ChoicesPanel.Children.Add(button);


                animTime += 300;
                StartQuestionChoiceButtonAnimation(animTime, button);
            }
        }
        private void GenerateQuestionIndexButtons()
        {
            int animTime = 0;
            for (int i = 0; i < 20; i++)
            {
                var button = new Button();
                button.Style = FindResource("QuestionIndexButtonStyle") as Style;
                button.Content = i + 1;
                button.Tag = i;
                button.Click += QuestionIndexSelected;
                QuestionsIndexPanel.Children.Add(button);

                animTime+=100;
                StartQuestionIndexButtonAnimation(animTime, button);
            }
        }

        public void StartQuestionIndexButtonAnimation(int animTime, Button btn)
        {
            DoubleAnimation animOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(100)),
                BeginTime = TimeSpan.FromMilliseconds(animTime)
            };

            btn.BeginAnimation(Button.OpacityProperty, animOpacity);
        }


        public void StartQuestionChoiceButtonAnimation(int animTime, Button btn)
        {
            DoubleAnimation animOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(300)),
                BeginTime = TimeSpan.FromMilliseconds(animTime)
            };

            ThicknessAnimation animLeft = new ThicknessAnimation();
            animLeft.From = new Thickness(10, 20, 10, 10);
            animLeft.To = new Thickness(10, 0, 10, 10);
            animLeft.Duration = new Duration(TimeSpan.FromMilliseconds(100));

            btn.BeginAnimation(Button.OpacityProperty, animOpacity);
            btn.BeginAnimation(Button.MarginProperty, animLeft);
        }

        private void QuestionIndexSelected(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex = (int)(sender as Button)!.Tag;
            ShowQuestion();
        }

        private void ChoiseSelected(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var bag = (Choice)button.DataContext;
            if (bag.Answer)
                button.Background = new SolidColorBrush(Colors.LightGreen);
            else
                button.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
