using Interfaces;
using Interfaces.Models;

Bird bird = new Bird();
bird.Eat();

WildAnimal wild = new WildAnimal();
wild.Eat();
wild.GetName();

IEat ieat = bird;
ieat.Eat();

IEat iwild = new WildAnimal();
iwild.Eat();

iwild = bird;
iwild.Eat();

Sound(bird);
Sound(wild);

void Sound(ISound animal)
{
    animal.Sound();
}

MyCollection col = new MyCollection();
Console.WriteLine(col.Max());
Console.WriteLine(col.GetFirstElement());