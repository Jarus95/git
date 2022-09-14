Dog dog1 = new Dog();
dog1.Name = "Name1";

Cow cow1 = new Cow();
cow1.Name = "Cow1";
cow1.Tail =2;

//Dog va Cow ning zamiridagi class animal bulgani uchun biz uni quidagi holatda yozishimiz mumkin.
//YA'ni Animal class Dog va Cow classlari uchun Base classi bulganligi sababli ham shu kurinishda yozish mumkin
//IEnumerable<string> animal = new List<string>();---- ning  yozilishining sababi ham shundan iborat

//Derived classdan obyekt olib Base class ga beraolmaymiz.Ammmo aksi mumkin.Ya'ni
//Dog dog = new Animal(); kurinishda yozaolmaymiz

Animal animal = new Dog();
Animal animal2 = new Cow();

Animal animal1 = cow1;
System.Console.WriteLine(animal1.Name);


// Bu class bir nechta elementlari Animal bilan bir xil bugani uchun 
// bu elementlarni biz Animaldan olishimiz mumkin.
//bunda Animal classi asosiy class bulgani uchun bu class -- Base class deb yuritiladi
// Cow va Dog classi Base class(Animal classdan) meros olgani ya'ni ma'lum bir elementlari undan hosil bulgani uchun
//  bu class Derived Class deb yuritiladi
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
        System.Console.WriteLine("Animal Sound.....");
    }

    public void Eat()
    {
        System.Console.WriteLine("I am eating.....");
    }
}
