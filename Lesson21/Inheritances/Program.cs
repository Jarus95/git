using Inheritances;

Dog dog1 = new Dog();
dog1.Name = "Name1";

Cow cow1 = new Cow();
cow1.Name = "Cow1";
cow1.Tail = 2;

Animal hayvon = new Dog();
Animal hayvon1 = new Cow();

//Dog dog2 = new Animal();

Animal animCow = cow1;
Console.WriteLine(animCow.Name);

List<Animal> animals = new List<Animal>();
animals.Add(hayvon);
animals.Add(dog1);
animals.Add(cow1);

namespace Inheritances
{
    class Cow : Animal
    {
        public int Horn;
        public int Tail;
    }

    class Dog : Animal
    {
    
    }

    class Animal
    {
        public string Name;
        public int Age;

        public void Sound()
        {
        }

        public void Eat()
        {
        }
    }
}