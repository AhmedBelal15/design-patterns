# Open / Closed Principle
## Classes should be open for extension but closed for modification.

**Wikipedia's Definition:**
open–closed principle states "software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification"; that is, such an entity can allow its behaviour to be extended without modifying its source code. 

## Example
```csharp
namespace Open_Closed_Princible.Problem
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }

        public decimal CalculateHoursBonus(decimal hours)
        {
            return ((BasicSalary/30) / 8) * hours;
        }

        public override string ToString()
        {
            return $"Employee id: {Id}, Name: {Name}";
        }
    }
}

using System;

namespace Open_Closed_Princible.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Emp1 = new Employee();
            Emp1.Name = "Ahmed";
            Emp1.Id = "123";
            Emp1.BasicSalary = 2700;

            Console.WriteLine(Emp1.ToString()
            +Environment.NewLine
            +"Bonus "
            +Emp1.CalculateHoursBonus(5).ToString()
            );
        }
    }
}
```

Now let's see the problems introduced in this example:
- Now our program calculates the bonus for every employee with the same method, say that we want managers to have it's bonus hour multiplied by 2 and the regular employee as it is
- We have to add employee type in the Employee class

```csharp
namespace Open_Closed_Princible.Problem
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }
        public string EmployeeType { get; set; }
        public decimal CalculateHoursBonus(decimal hours, string employeeType)
        {
            if(EmployeeType == "manager"){
                return ((BasicSalary/30) / 8) * 2 * hours;
            } else{
                return ((BasicSalary/30) / 8) * hours;
            }
        }

        public override string ToString()
        {
            return $"Employee id: {Id}, Name: {Name}";
        }
    }
}
```

Now our program won't work because our CalculateHoursBonus Method expects 2 arguments (hours, employeeType) while we only passing 1 (hours) so we need to edit the program class

```csharp
using System;

namespace Open_Closed_Princible.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Emp1 = new Employee();
            Emp1.Name = "Ahmed";
            Emp1.Id = "123";
            Emp1.BasicSalary = 2700;
            Emp1.EmployeeType = "manager";
            Console.WriteLine(Emp1.ToString()
            +Environment.NewLine
            +"Bonus "
            +Emp1.CalculateHoursBonus(5, Emp1.EmployeeType).ToString()
            );
        }
    }
}
```
We are violating the Open/Close Principle as our program class isn't closed for modification

## How can we solve the problem?

One method is using Abstract Classes
- Change Employee class to Abstract Class
- Change CalculateBonusHours Methon to Abstract Method
- Adding new Class for every Employee type and make that class implement the CalculateBonusHours method

```csharp
namespace Open_Closed_Princible.Solution.Abstract_Class
{
    public abstract class Employee
    {
        public class Employee
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal BasicSalary { get; set; }
            public string EmployeeType { get; set; }
            public abstract decimal CalculateHoursBonus(decimal hours);


            public override string ToString()
            {
                return $"Employee id: {Id}, Name: {Name}";
            }
        }
    }

    public class Manager : Employee
    {
        public override decimal CalculateHoursBonus(decimal hours)
        {
            return ((BasicSalary / 30) / 8) * 2 * hours;
        }
    }

    public class RegularEmployee : Employee
    {
        public override decimal CalculateHoursBonus(decimal hours)
        {
            return ((BasicSalary / 30) / 8) * hours;
        }
    }
}
```

Now we don't need to modify the program class

```csharp
using System;

namespace Open_Closed_Princible.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager Emp1 = new Manager();
            Emp1.Name = "Ahmed";
            Emp1.Id = "123";
            Emp1.BasicSalary = 2700;

            RegularEmployee Emp2 = new RegularEmployee();
            Emp2.Name = "Ahmed 2";
            Emp2.Id = "1234";
            Emp2.BasicSalary = 2700;


            Console.WriteLine(Emp1.ToString()
            +Environment.NewLine
            +"Bonus "
            +Emp1.CalculateHoursBonus(5).ToString()
            );

            
            Console.WriteLine(Emp2.ToString()
            +Environment.NewLine
            +"Bonus "
            +Emp1.CalculateHoursBonus(5).ToString()
            );
        }
    }
}
```

Passing the same number of hours to the program will give us different values as the methods are different from one class to another
Now if I want to add a new grade of employee say a middle grade with 1.5 bonus I can add a new class, implement the method without the need to change the program class
We can implement the principle using interfaces but now I'm too lazy to do it maybe in the future xD