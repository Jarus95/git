//Animal anim1 = new Animal(); //can not create obj from abstract class
//anim1.Sound();

Cow cow1 = new Cow();
//cow1.Sound();

Dog dog1 = new Dog();
//dog1.Sound();

Animal animDog = dog1;
//animDog.Sound();

List<Animal> animals = new List<Animal>();
animals.Add(dog1);
animals.Add(animDog);
animals.Add(cow1);

CowType cow2 = new CowType();
cow2.Tail = 2;
Cow cowT = cow2;
Console.WriteLine(cowT.Tail);
Animal cowType = cow2;
//Console.WriteLine(cowType.Tail);

Animal cow3 = new CowType();
cow3.Sound();

foreach (var animal in animals)
{
    animal.Sound();
}

class CowType : Cow
{
    public override void Sound()
    {
        Console.WriteLine("Cowtype sound");
    }
}

class Cow : Animal
{
    public int Horn;
    public int Tail;

    public override  void Sound()
    {
        Console.WriteLine("Cow sound");
    }
}

// sealed - can not use as base class
sealed class Dog : Animal
{
    //to change this from base class
    public override void Sound()
    {
        Console.WriteLine("Bark...");
    }
}

// abstract - can not creat obj from abstract class
abstract class Animal
{
    public string Name;
    public int Age;

    //allows to change this in drived class
    public virtual void Sound()
    {
        Console.WriteLine("Animal sound...");
    }

    public void Eat()
    {
        Console.WriteLine("I'm eating...");
    }
}