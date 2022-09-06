namespace Classes;

class WriteReadDatabase
{
    private string usersFile = "users.txt";
    private string questionsFile = "questions.txt";

    public void Write(List<User> users)
    {
        //write
        string[] usersLine = new string[users.Count];
        for (int i = 0; i < users.Count; i++)
        {
            usersLine[i] = users[i].ToText(true);
        }

        File.WriteAllLines(usersFile, usersLine);
    }

    public void Write(List<Question> questions)
    {

    }

    public List<User> ReadUsers()
    {
        var users = new List<User>();
        if (File.Exists(usersFile))
        {
            string[] usersLine = File.ReadAllLines(usersFile);
            foreach (var userText in usersLine)
            {
                var uData = userText.Split(',');
                var user = new User(long.Parse(uData[0]), uData[1], int.Parse(uData[2]));
                users.Add(user);
            }
        }

        return users;
    }

    public List<Question> ReadQuestions()
    {

        return new List<Question>();
    }

}