﻿using Autotest.Wpf.Pages;
using System.Windows;
using Avtotest.Database;

namespace Autotest.Wpf;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public QuestionsRepository QuestionsRepository;

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;

        var menuPage = new MenuPage();
        MainFrame.Navigate(menuPage);

        QuestionsRepository = new QuestionsRepository();
    }
}