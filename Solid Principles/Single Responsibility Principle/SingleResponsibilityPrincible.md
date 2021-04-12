# Single Responsibility Princible
## A class should have just one reason to change.

**Wikipedia's Definition:**
Every module, class, or function should have responsibility for a single part of the functionality provided by the software, and that responsibility should be entirely encapsulated by the class.

## Example

```csharp
namespace Single_Responsibility_Principle.Problem
{
    public class EmployeeService
    {
        List<Employee> Employees = new List<Employee>();
        public void EmployeeRegistration(Employee employee)
        {
            Employees.Add(employee);
            SendEmail(employee.Email, "Subject", "Message Body");
        }

        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Ahmed", "ahmbelal95@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.LocalDomain = "sample.com";
                smtpClient.Connect("smtp.relay.uri", 25, SecureSocketOptions.None);
                smtpClient.Send(emailMessage);
                smtpClient.Disconnect(true);
            }
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
```

Now let's see the problems introduced in this example:
 - The class **EmployeeService** is responsible for Registering an Employee.
 - The class **EmployeeService** is responsible for Sending an Email to the registerd employee.
There is more than one reason to modify the EmployeeService class

## Solution

By Separating the logic for sending email into another class so that EmployeeService class will be responsible for handling employees and the new class will handle email things.

```csharp
// Employee Service Class
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

//Email Service class
namespace Single_Responsibility_Principle.Solution
{
    public class EmailService
    {
        public static void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Ahmed", "ahmbelal95@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.LocalDomain = "sample.com";
                smtpClient.Connect("smtp.relay.uri", 25, SecureSocketOptions.None);
                smtpClient.Send(emailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
```
