namespace Partial;

internal class Question
{
    public int Index { get; set; }
    public string Text { get; set; }

    public int CorrectAnswerIndex { get; set; }

    //method
    public int GetIndex() => Index;

    public string GetText()
    {
        return Text;
    }
}
