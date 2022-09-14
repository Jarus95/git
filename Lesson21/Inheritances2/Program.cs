// Animal animal = new Animal();//cannot create obj from abstact class
// animal.Sound();

Cow cow = new Cow();
cow.Sound();

Dog dog = new Dog();
dog.Sound();

List<Animal> animalList = new List<Animal>();
animalList.Add(dog);
animalList.Add(cow);

/*CowType cowType = new CowType();
cowType.Tail = 2;
cowType.Name ="sigir";
Cow cowT = cowType;
System.Console.WriteLine(cowT.Tail);*/

foreach(var anim in animalList)
System.Console.WriteLine(anim);
//hoz bu yerda yana animal classidagi sound kelib qolyabdi.Dogning soundini ignore qilyabdi.
//Buning yechimi uchun esa Animal class idagi elementga virtual suzini qushib yozishimiz kk
//shunda biz undan hosil qilingan classga override keyini qushib yozsak yuqoridagi muammo ketadi
Animal animDog = dog;
animDog.Sound();

//sealed class --> bu classni Base class sifatida foydalana olmaysan.
//Ya'ni undan voris ololmaysan
sealed class Cow : Animal

{
    public int Horn;
    public int Tail;
    public override void Sound()
    {
        System.Console.WriteLine("Mu.....");
    }
}
// hoz bu yerda Cow classi sealed key idan foydalangani uchun undan voris olib bulmagani uchun xatolik kursatadi
// class CowType:Cow
// {

// }

class Dog : Animal
{
    public override void Sound()//override -- base classda virtual key orqali yozilgan functionlarni o'zgartirish imkonini beradi
    {
        System.Console.WriteLine("Bark");
    }
}
abstract class Animal// bu classdan obyekt olishimiz mumkin emas.Bu mantiqqa va sxemetik jihatdan
// xato hisoblanadi. Biz faqat Derived classlardangina obyekt olib ishlatishimiz kk.
// Classdan obekt olinishini hohlamasak classlar bilan abstract keywordsdan foydalanishimiz kk.
// Ammo undan hosil qilingan classlardan(vorislaridan) obyekt olishimiz mumkin
{
    public string Name;
    public int Age;
    public  virtual void Sound()//virtuala key --> dericed class larda override key orqali o'zgartirish uchun foydalanamiz
    //allows to change the field of base class in derived class
    {
        System.Console.WriteLine("Animal Sound.....");
    }

    public void Eat()
    {
        System.Console.WriteLine("I am eating.....");
    }
}