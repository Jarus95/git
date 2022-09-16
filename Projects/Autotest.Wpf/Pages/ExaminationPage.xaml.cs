using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Avtotest.Database;
using Avtotest.Database.Models;

namespace Autotest.Wpf.Pages;

public partial class ExaminationPage : Page
{
    public ExaminationPage(int? currentTicketIndex = null)
    {
        InitializeComponent();

        if (currentTicketIndex != null)
        {
            Title.Content = $"Ticket{currentTicketIndex}";
        }

        ShowQuestion();
    }

    private void MenuButtonClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }

    private void ShowQuestion()
    {
        var questionsRepository = new QuestionsRepository();
        var question = questionsRepository.Questions[2];

        QuesitonText.Content = question.Question;

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
        for (int i = 0; i < choices.Count; i++)
        {
            var choice = choices[i];

            var button = new Button();

            button.Width = 300;
            button.Height = 30;
            button.FontSize = 14;
            button.Content = choice.Text;
            button.Click += ChoiceButtonClick;
            button.Tag = choice;

            ChoicePanel.Children.Add(button);
        }
    }

    private void ChoiceButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var choice = (Choice)button.Tag;

        if (choice.Answer)
        {
            MessageBox.Show("Togri");
        }
        else
        {
            MessageBox.Show("Togri emas");
        }
    }
}