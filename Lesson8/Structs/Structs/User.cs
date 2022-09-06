namespace Structs.Structs;

struct User
{
    public string Name;
    public int Answers;

    public User(string name, int answers)
    {
        Name = name;
        Answers = answers;
    }
}