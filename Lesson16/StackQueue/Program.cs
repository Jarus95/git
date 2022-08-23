int[] arr = new int[] { 1, 2, 3, 4, 5 };

Stack<int> navbat = new Stack<int>(arr);

Console.WriteLine("peek: " + navbat.Peek());
Console.WriteLine("count: " + navbat.Count);

Console.WriteLine("pop: " + navbat.Pop());
Console.WriteLine("count: " + navbat.Count);

Queue<string> queue = new Queue<string>();
queue.Enqueue("navbat1");
queue.Enqueue("navbat2");
queue.Enqueue("navbat3");

var current = queue.Peek();
Console.WriteLine(current);
Console.WriteLine(queue.Count);

Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Count);

Console.WriteLine("Questions");

Queue<Question> questions = new Queue<Question>();
questions.Enqueue(new Question("savol1"));
questions.Enqueue(new Question("savol2"));
questions.Enqueue(new Question("savol3"));

Console.WriteLine(questions.Count);
var question = questions.Dequeue();
Console.WriteLine(question.QuestionText + $"\n count:{questions.Count}");

for (int i = 0; i < questions.Count; i++)
{
    Console.WriteLine(questions.Dequeue().QuestionText);
}

Console.WriteLine(questions.Count);

class Question
{
    public string QuestionText;
    public Question(string questionText)
    {
        QuestionText = questionText;
    }
}