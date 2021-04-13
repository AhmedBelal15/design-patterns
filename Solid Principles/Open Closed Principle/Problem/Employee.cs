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
            if(employeeType == "manager"){
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