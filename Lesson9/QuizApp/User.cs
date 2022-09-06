namespace QuizApp;

struct User
{
    public string Name;
    public int CorrectAnswersCount;
    public int QuestionsCount;

    public User(string name, int correctAnswers, int questionsCount)
    {
        Name = name;
        CorrectAnswersCount = correctAnswers;
        QuestionsCount = questionsCount;
    }

    public int ToPercent()
    {
        return (int)((double)CorrectAnswersCount / QuestionsCount * 100);
    }

    public string ToStringPercent()
    {
        return ToPercent() + "%";
    }

    public string ToStringPercent(string text)
    {
        return ToPercent() + $"% {text}.";
    }

    public string ToStringPercent(string text, int index)
    {
        return ToPercent() + $"% {text}.";
    }

    public string ToStringPercent(int index = 0)
    {
        return ToPercent() + $"% {index}.";
    }

    public User Copy()
    {
        /*var copy = new User();
    copy.Name = Name;
    copy.CorrectAnswersCount = CorrectAnswersCount;
    copy.QuestionsCount = QuestionsCount;*/

        return this;
    }
    
    // 80% ishlagan
}