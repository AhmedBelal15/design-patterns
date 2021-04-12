using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

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