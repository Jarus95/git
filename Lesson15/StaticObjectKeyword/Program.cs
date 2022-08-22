using Models;
using StaticObjectKeyword;

Objects.Main();

Console.WriteLine("\n\n\n");


User user1 = new User();

//Methods method = new Methods();

Methods.BotToken = "ada";

User.Group = "New";
User user2 = new User();

Question question = new Question();

Console.WriteLine(question.ToStringQuestion());
Console.WriteLine(Methods.ToText(new []{"Ads","asd"}));

User.Group = "Ism";
Console.WriteLine(User.Group);


namespace Models
{
    public class User
    {
        public static string Group = "Class_003";

        public string Name { get; set; }

        public User()
        {
            string[] str = new string[4];
            var r = Methods.ToText(str);
        }

    }

    public class Question
    {
        public string ToStringQuestion()
        {
            Methods.ToText(new string[5]);
            return "Text";
        }
    }

    public static class Methods
    {
        public static string BotToken = "afafafwrg2g424g";

        public static string ToText(string[] ms)
        {
            string r = "";
            foreach (var s in ms)
            {
                r += s;
            }
            return r;
        }
    }
}

