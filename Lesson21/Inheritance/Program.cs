//Employee employee = new Employee("Kimdir", 1000);
//Console.WriteLine(employee.GetSalary());

Manager manager = new Manager("Kimdir", "998",1000, 1);
Console.WriteLine(manager.GetSalary());

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
}

public class Employee
{
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
}