namespace Interfaces.Models;

public class WildAnimal : Animal, IEat, ISound
{
    public override string GetName()
    {
        return Name;
    }

    public override void Eat()
    {
        Console.WriteLine("Meal");
    }

    public void EatFinish()
    {
        Console.WriteLine("Finished");
    }

    public void Sound()
    {
        Console.WriteLine("Wild animal sound..");
    }
}