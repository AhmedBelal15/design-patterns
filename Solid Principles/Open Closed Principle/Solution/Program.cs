namespace Open_Closed_Princible.Solution.Abstract_Class
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