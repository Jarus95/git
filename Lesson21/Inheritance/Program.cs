Employee employee = new Employee("Shahzod", 1000);
System.Console.WriteLine(employee.GetSalary());

<<<<<<< HEAD
using Inheritance;

Manager manager = new Manager("Kimdir", "998",1000, 1);
Console.WriteLine(manager.GetSalary());
=======
Manager manager = new Manager(2, "Shahzod", 1000, "samsung");
System.Console.WriteLine(manager.GetSalary());
public class Employee
{
    public string Phone;
    public int Salary { get; set; }
    public string Name { get; set; }
    public Employee(string name, int salary) // 
    {
        Salary = salary;
        Name = name;
    }

    public Employee(string name, int salary, string phone) // 
    {
        Salary = salary;
        Name = name;
        Phone = phone;
    }
    public virtual int GetSalary()
    {
        System.Console.WriteLine("Calculating Salary.......");
        return Salary;
    }
}
>>>>>>> 895c5eb3f6813203dc489fd63f7575c4aee6870e

namespace Inheritance
{
<<<<<<< HEAD
    public class Manager : Employee
    {
        public int Id { get; set; }

        public Manager(string name, string phone, int salary, int id) : base(name, phone, salary)
        {
            Id = id;
            Salary += 200;
            Console.WriteLine("Manager created.");
        }

        public override int GetSalary()
        {
            Console.WriteLine("Manager...");
            Salary += 200;
            var salary = base.GetSalary();
            return salary;
        }
=======
    public int Id;

    public Manager(int id, string name, int salary, string phone)
        : base(name, salary, phone)// bu holatda eng avval Base classdagi constructur ishga tushadi 
                                   //keyin derived classdagi constructor ishga tushib ketadi.

    // Agar base clasda bir nechta constructor bulsa, drived class da base deb yozib uni 
    // kerakli parametrlar orqali tuldirib foydalanishimiz mumkin.
    {
        Id = id;
        Salary += 200;
        System.Console.WriteLine("Manager Created...");
>>>>>>> 895c5eb3f6813203dc489fd63f7575c4aee6870e
    }

    public class Employee
    {
<<<<<<< HEAD
        public string Name;
        public string Phone;
        public int Salary;

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
            Console.WriteLine("Employee created.");
        }

        public Employee(string name, string phone, int salary)
        {
            Name = name;
            Phone = phone;
            Salary = salary;
        }

        public virtual int GetSalary()
        {
            Console.WriteLine("Calculating salary...");
            return Salary;
        }
=======
        System.Console.WriteLine("Manager.....");
        Salary += 200;// Base classimizda qaysi amalni bajargan bulsak,derived classda ham shuni 
        //amalga oshirish uchun base kalit shuzidan foydalanamiz,quidagi kabi.Bu base klassdagi kodni
        // derived klassda takror yozishdan qochish uchun basedan foydalanamiz.
        return base.GetSalary();
>>>>>>> 895c5eb3f6813203dc489fd63f7575c4aee6870e
    }
}