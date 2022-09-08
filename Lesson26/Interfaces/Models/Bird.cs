namespace Interfaces.Models;

public class Bird : Animal, IEat, ISound
{
    public override string GetName()
    {
        return Name;
    }

    public override void Eat()
    {
        Console.WriteLine("Corn");
    }

    public void EatFinish()
    {

    }
    public void Sound()
    {
        Console.WriteLine("Bird sound..");
    }
}