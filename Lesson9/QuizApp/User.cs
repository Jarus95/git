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

    // 80% ishlagan
}