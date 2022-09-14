using Avtotest.Data.Databases;
using Avtotest.Data.Models;
using Avtotest.Data.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Avtotest.WPF.Pages
{
    public partial class ExaminationPage : Page
    {
        private Ticket CurrentTicket;
        private int currentQuestionIndex = 0;

        private int timeLimit = 900;
        private DispatcherTimer timer;

        public ExaminationPage(int? ticketIndex = null)
        {
            InitializeComponent();

            //create ticket
            CurrentTicket = ticketIndex == null
                ? Database.Db.TicketDb.CreateTicket()
                : CreateTicketByIndex(ticketIndex.Value);

            TicketLabel.Content = ticketIndex != null ? $"Ticket{ticketIndex + 1}" : "Examination";

            ShowQuestion();
            GenerateQuestionIndexButtons();

            InitTimer();
        }

        private void InitTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            var time = --timeLimit;
            Timer.Content = $"{time/60}:{time%60}";

            if (timeLimit == 0)
            {
                CloseTicket(null,null);
                timer.Stop();
            }
        }

        private void SetImage(string imageName)
        {
            questionImage.Source =
                new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imageName}.png")));
        }

        private Ticket CreateTicketByIndex(int ticketIndex)
        {
            var from = ticketIndex * TicketsSettings.TicketQuestionsCount;
            var questions = Database.Db.QuestionsDb.CreateTicket(from, TicketsSettings.TicketQuestionsCount);
            var ticket = new Ticket(ticketIndex, new List<QuestionEntity>(questions));
            return ticket;
        }

        private void ShowQuestion()
        {
            var question = CurrentTicket.Questions[currentQuestionIndex];
            SetImage(question.Media.Exist ? question.Media.Name : "car");
            QuestionText.Text = $"{currentQuestionIndex + 1}. {question.Question}";
            AddButtons(question);
        }

        private void AddButtons(QuestionEntity question)
        {
            ChoicesPanel.Children.Clear();
            int animTime = 0;
            for (int i = 0; i < question.Choices.Count; i++)
            {
                var button = new Button();
                button.Style = FindResource("ChoiceButtonStyle") as Style;

                if (question.IsCompleted)
                {
                    if (question.Choices[i].IsSelected)
                    {
                        if (question.Choices[i].Answer)
                        {
                            button.Background = new SolidColorBrush(Colors.LightGreen);
                        }
                        else
                        {
                            button.Background = new SolidColorBrush(Colors.Red);
                        }
                    }
                }
                
                button.Click += ChoiseSelected;
                button.DataContext = question.Choices[i];

                ChoicesPanel.Children.Add(button);

                animTime += 300;
                StartQuestionChoiceButtonAnimation(animTime, button);
            }
        }

        private void GenerateQuestionIndexButtons()
        {
            int animTime = 0;
            for (int i = 0; i < CurrentTicket.Questions.Count; i++)
            {
                var button = new Button();
                button.Style = FindResource("QuestionIndexButtonStyle") as Style;
                button.Content = i + 1;
                button.Tag = i;
                button.Click += QuestionIndexSelected;

                if (i==0)
                {
                    button.Background = new SolidColorBrush(Colors.Aqua);
                }

                QuestionsIndexPanel.Children.Add(button);

                animTime += 100;
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
            var button = sender as Button;
            (QuestionsIndexPanel.Children[currentQuestionIndex] as Button)!.Background =
                new SolidColorBrush(Color.FromRgb(221,221,221));

            currentQuestionIndex = (int)button!.Tag;
            ShowQuestion();

            //set this button background = blue
            button.Background = new SolidColorBrush(Colors.Aqua);
        }

        private void ChoiseSelected(object sender, RoutedEventArgs e)
        {
            if (CurrentTicket.Questions[currentQuestionIndex].IsCompleted) return;

            var button = (Button)sender;
            var choice = (Choice)button.DataContext;
            if (choice.Answer)
            {
                button.Background = new SolidColorBrush(Colors.LightGreen);
                CurrentTicket.CorrectAnswersCount++;
                (QuestionsIndexPanel.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.Red);
                (QuestionsIndexPanel.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.Red);
            }
            choice.IsSelected = true;

            CurrentTicket.Questions[currentQuestionIndex].IsCompleted = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPage.Main);
        }

        private void SetVisibility(StackPanel panel, bool isVisible)
        {
            panel.Visibility = isVisible ? Visibility.Visible : Visibility.Hidden;
            panel.IsEnabled = isVisible;
        }

        private void CloseTicket(object sender, RoutedEventArgs e)
        {
            /*var completedCount = CurrentTicket.Questions.Count(q => q.IsCompleted);
            if (completedCount == CurrentTicket.QuestionsCount)
            {
            }*/

            SetVisibility(ExamResultPanel, true);
            SetVisibility(QuestionPanel, false);
            ExamResultPanel.DataContext = CurrentTicket;
            Database.Db.TicketDb.UserTickets.Add(CurrentTicket);
        }
    }
}
