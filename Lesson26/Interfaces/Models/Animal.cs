namespace Interfaces.Models;

public abstract class Animal
{
    public string Name;
    public abstract string GetName();
    public abstract void Eat();
}