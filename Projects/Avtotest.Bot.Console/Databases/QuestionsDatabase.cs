﻿using Avtotest.Bot.Console.Models;

namespace Avtotest.Bot.Console.Databases;

public class QuestionsDatabase
{
    public List<QuestionEntity> Questions { get; set; }

    public QuestionsDatabase(List<QuestionEntity> questions)
    {
        Questions = questions;
    }

    public List<QuestionEntity> CreateTicket(int from = 0, int questionsCount = 20)
    {
        return Questions.Skip(from).Take(questionsCount).ToList();
    }
}