
public abstract class User
{
    public int Age;
    public string Name;

    public abstract int GetAge();

    public abstract string GetName();

    public string GetNameAndAge()
    {
        return GetName();
    }
    public virtual string GetNameOnly()
    {
        return Name;
    }
}

public abstract class Employee : User
{
    public override int GetAge()
    {
        return 10;
    }

    public abstract override string GetName();

    public sealed override string GetNameOnly()
    {
        return "Name";
    }
}

class SubEmployee : Employee
{
    public override string GetName()
    {
        return "Oldik";
    }

    /*public override string GetNameOnly()
    {
        return "Name";
    }*/
}