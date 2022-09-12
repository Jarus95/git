using Avtotest.Api.Data;
using Avtotest.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avtotest.Api.Controllers;

[Route("questions")]
public class QuestionsController : ControllerBase
{
    [HttpGet]
    public List<Question> GetQuestions()
    {

        return QuestionsDatabase.Instance.Questions;
    }

    [HttpGet("{index}")]
    public Question GetQuestionByIndex(int index)
    {
        return QuestionsDatabase.Instance.Questions[index];
    }

    [HttpPost]
    public string AddQuestion([FromBody] Question question)
    {
        QuestionsDatabase.Instance.Questions.Add(question);
        return "Question added";
    }

    [HttpPut]
    public string UpdateQuestion(int index, string questionText)
    {
        QuestionsDatabase.Instance.Questions[index] = new Question()
        {
            QuestionText = questionText
        };

        return "Question updated";
    }

    [HttpDelete]
    public string DeleteQuestion(int index)
    {
        QuestionsDatabase.Instance.Questions.RemoveAt(index);
        return "Question deleted";
    }

    [HttpGet("count")]
    public int GetQuestionsCount()
    {
        return QuestionsDatabase.Instance.Questions.Count;
    }
}