namespace Partial.Models;

public partial class User
{
    public string GetName() => Name;

    public User()
    {
        Index = 1;
    }

    protected partial void SetStep()
    {
        Console.WriteLine("12");
    }
}