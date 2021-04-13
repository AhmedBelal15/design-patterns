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