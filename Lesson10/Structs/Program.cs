User user = new User();
user.name = "ism";
user.son = 2;

var user2 = user.Copy();
Console.WriteLine(user2.son);

user2.son = 8;
Console.WriteLine(user.son);




Question question = new Question("s", 2);
question.QuestionText = "Sa";
question.Index = 2;
question.Percent = 10;

Console.WriteLine(question.PercentString);

question.Index = 15;            // set
var ind = question.Index;   // get
Console.WriteLine(ind);

question.QuestionText = "Savol1";
Console.WriteLine(question.QuestionText);



/*bool isSet = question.SetQuestionText("Yangi savol");
var questionText = question.GetQuestionText(); // Yangi savol

question.SetIndex(10);
var index = question.GetIndex();

Console.WriteLine(index);


Console.WriteLine(question.Index);
Console.WriteLine(question.GetQuestionText());*/