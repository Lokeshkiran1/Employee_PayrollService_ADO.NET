using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Services_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll service");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();
            model.EmployeeName = "John";
            model.PhoneNumber = 9876543210;
            model.Address = "Banglore";
            model.Department = "HR";
            model.Gender = 'M';
            model.BasicPay = 27500;
            model.Deduction = 2500;
            model.TaxablePay = 5000;
            model.Tax = 1000;
            model.NetPay = 19000;
            //model.StartDate= DateTime.Now;
            model.City = "Hassan";
            model.Country = "India";
            
           // repo.AddEmployee(model);
            repo.GetAllEmployee();
            Console.ReadLine();



        }
    }
}
