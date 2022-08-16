struct User
{
    public long Id;
    public string Name;
    public int Step;

    public void SetStep(int step)
    {
        Step = step;
    }

    public string ToText()
    {
        return $"{Id}, Ismi: {Name}, step: {Step}";
    }
}