Employee employee = new Employee("Shahzod",1000);
System.Console.WriteLine(employee.GetSalary());

Manager manager = new Manager(2,"Shahzod",1000,"samsung");
System.Console.WriteLine(manager.GetSalary());
public class Employee
{
    public string Phone;
    public int Salary { get; set; }
    public string Name { get; set; }
    public Employee(string name,int salary) // 
    {
        Salary = salary;
        Name  = name;
    }

    public Employee(string name,int salary,string phone) // 
    {
        Salary = salary;
        Name  = name;
        Phone =phone;
    }
    public virtual int GetSalary()
    {
        System.Console.WriteLine("Calculating Salary.......");
        return Salary;
    }
}

public class Manager : Employee
{
    public int Id;

    public Manager(int id,string name, int salary,string phone) 
        : base(name, salary,phone)// bu holatda eng avval Base classdagi constructur ishga tushadi 
        //keyin derived classdagi constructor ishga tushib ketadi.

        // Agar base clasda bir nechta constructor bulsa, drived class da base deb yozib uni 
        // kerakli parametrlar orqali tuldirib foydalanishimiz mumkin.
    {
        Id = id;
        Salary +=200;
        System.Console.WriteLine("Manager Created...");
    }

    public override int GetSalary()
    {
        System.Console.WriteLine("Manager.....");
        Salary +=200;// Base classimizda qaysi amalni bajargan bulsak,derived classda ham shuni 
        //amalga oshirish uchun base kalit shuzidan foydalanamiz,quidagi kabi.Bu base klassdagi kodni
        // derived klassda takror yozishdan qochish uchun basedan foydalanamiz.
        return base.GetSalary();
    }
}