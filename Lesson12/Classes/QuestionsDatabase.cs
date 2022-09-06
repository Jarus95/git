namespace Classes;

class QuestionsDatabase
{
    public List<Question> Questions = new List<Question>();

    public QuestionsDatabase()
    {
        AddDefaultQuestion();
    }

    public Question? AddQuestion(string questionText)
    {
        string[] questionMassiv = questionText.Split(',');
        if (questionMassiv.Length <= 4) return null;

        Question question = new Question(
            question: questionMassiv[0],
            index: int.Parse(questionMassiv[1]),
            choices: questionMassiv.Skip(2).ToList()
        );
        Questions.Add(question);
        return question;
    }

    public Question GetQuestion(int index)
    {
        return Questions[index];
    }

    public string GetQuestionText()
    {
        string questionsText = "";
        for (int i = 0; i < Questions.Count; i++)
        {
            questionsText += $"{i + 1}, {Questions[i].QuestionText}\n";
        }
        return questionsText;
    }

    public void RemoveQuestion(int index)
    {
        Questions.RemoveAt(index);
    }


    void AddDefaultQuestion()
    {
        Questions.Add(new Question("1 + 2 = ?", 1, new List<string>() { "2", "3", "12", "32" }));
        Questions.Add(new Question("1 * 2 = ?", 2, new List<string>() { "21", "34", "2", "32" }));
        Questions.Add(new Question("4 / 2 = ?", 0, new List<string>() { "2", "13", "12", "32" }));
    }

}