using Avtotest.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Autotest.Wpf.Pages;

public partial class ExaminationPage : Page
{
    private int currentQuestionIndex = 0;
    private Ticket currentTicket;

    public ExaminationPage(int currentTicketIndex = -1)
    {
        InitializeComponent();

        //set random ticket
        if (currentTicketIndex <= -1)
        {
            var random = new Random();

            //0 dan 35gacha bolgan ixtiyoriy soni qaytaradi
            currentTicketIndex = random.Next(0, MainWindow.Instance.QuestionsRepository.GetTicketsCount());
        }

        Title.Content = $"Ticket{currentTicketIndex + 1}";
        CreateTicket(currentTicketIndex);

        //generate ticket question buttons 
        GenerateTicketQuestionIndexButtons();

        ShowQuestion();
    }

    private void CreateTicket(int ticketIndex)
    {
        var ticketQuestionsCount = MainWindow.Instance.QuestionsRepository.TicketQuestionsCount;
        var from = ticketIndex * ticketQuestionsCount;
        var ticketQuestions = MainWindow.Instance.QuestionsRepository.GetQuestionsRange(from, ticketQuestionsCount);
        currentTicket = new Ticket(ticketIndex, ticketQuestions);
    }

    private void GenerateTicketQuestionIndexButtons()
    {
        for (int i = 0; i < currentTicket.QuestionsCount; i++)
        {
            var button = new Button();
            button.Width = 30;
            button.Height = 30;
            button.Content = i + 1;
            button.Click += TicketQuestionIndexButtonClick;
            button.Tag = i;

            TicketQuestionIndexButtonPanel.Children.Add(button);
        }
    }

    private void TicketQuestionIndexButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        currentQuestionIndex = (int)button.Tag;
        ShowQuestion();
    }

    private void MenuButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }

    private void ShowQuestion()
    {
        var question = currentTicket.Questions[currentQuestionIndex];

        QuesitonText.Text = $"{currentQuestionIndex + 1}. {question.Question}";

        LoadQuestionImage(question.Media);

        GenerateChoiceButtons(question.Choices);
    }

    private void LoadQuestionImage(Media questionMedia)
    {
        string imagePath;

        if (questionMedia.Exist)
            imagePath = Path.Combine(Environment.CurrentDirectory, "Images", $"{questionMedia.Name}.png");
        else
            imagePath = Path.Combine(Environment.CurrentDirectory, "Images", "car.png");

        QuestionImage.Source = new BitmapImage(new Uri(imagePath));
    }

    private void GenerateChoiceButtons(List<Choice> choices)
    {
        ChoicePanel.Children.Clear();
        for (int i = 0; i < choices.Count; i++)
        {
            var choice = choices[i];

            var button = new Button();

            button.Width = 300;
            button.MinHeight = 30;
            button.FontSize = 14;
            button.Click += ChoiceButtonClick;
            button.Tag = choice;

            //button.Content = choice.Text;

            var textBlock = new TextBlock();
            textBlock.Text = choice.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            button.Content = textBlock;

            ChoicePanel.Children.Add(button);
        }
    }

    private void ChoiceButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var choice = (Choice)button.Tag;

        //set button bachground red or green

        if (choice.Answer)
        {
            button.Background = new SolidColorBrush(Colors.LightGreen);
            currentTicket.CorrectAnswersCount++;
        }
        else
        {
            button.Background = new SolidColorBrush(Colors.Red);
        }

        currentTicket.SelectedQuestionIndexs.Add(currentQuestionIndex);

        if (currentTicket.SelectedQuestionIndexs.Count == currentTicket.QuestionsCount)
        {
            MainWindow.Instance.MainFrame.Navigate(new ExaminationResultPage(currentTicket));
        }
    }
}