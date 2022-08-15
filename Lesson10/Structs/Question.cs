using System.Text;

struct Question
{
    private string _questionText;
    private int _index;

    public int Percent
    {
        get;
        set;
    }

    public int Index
    {
        get { return _index; }
        set
        {
            if (value < 10)
            {
                _index = value;
            }
        }
    }

    public string QuestionText
    {
        get
        {
            return _questionText;
        }
        set
        {
            if(value.Length < 5)
                _questionText = value;
        }
    }

    public Question(string question, int index)
    {
        _questionText = question;
        _index = index;
        Percent = 0;
    }

    public string PercentString
    {
        get
        {
            return Percent.ToString() + "%";
        }
    }
}