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
