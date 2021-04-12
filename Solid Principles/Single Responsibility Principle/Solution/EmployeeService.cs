using System.Collections.Generic;
namespace Single_Responsibility_Principle.Solution
{

    public class EmployeeService
    {
        List<Employee> Employees = new List<Employee>();
        public void EmployeeRegistration(Employee employee)
        {
            Employees.Add(employee);
            EmailService.SendEmail(employee.Email, "Subject", "Message Body");
        }
    }

 
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Employee(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}