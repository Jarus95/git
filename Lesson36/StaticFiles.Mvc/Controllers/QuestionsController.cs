using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using StaticFiles.Mvc.Models;
using StaticFiles.Mvc.Services;

namespace StaticFiles.Mvc.Controllers;

public class QuestionsController : Controller
{
    public IActionResult Index(int? id, int? choiceIndex = null)
    {
        var questionsData = new QuestionsRepository();
        var question = questionsData.Questions.Find(q => q.Id == id);
        if (question == null)
        {
            return View();
        }

        if (choiceIndex != null)
        {
            ViewBag.ChoiceIndex = choiceIndex.Value;
            ViewBag.ChoiceResult = Answer(question, choiceIndex.Value);
        }

        return View(question);
    }

    private bool Answer(QuestionEntity question, int choiceIndex)
    {
        var choice = question.Choices[choiceIndex];
        return choice.Answer;
    }
}