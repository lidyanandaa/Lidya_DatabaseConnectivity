using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VLinq
    {
        public void GetAll(List<Linq> linq)
        {
            foreach (var l in linq) {
            Console.WriteLine("==========================================");
            Console.WriteLine("Id: " + l.Id);
            Console.WriteLine("Full Name: " + l.First_Name + " " + l.Last_Name);
            Console.WriteLine("Email: " + l.Email);
            Console.WriteLine("Phone Number: " + l.Phone_Number);
            Console.WriteLine("Salary: " + l.Salary);
            Console.WriteLine("Department Name: " + l.Department_Name);
            Console.WriteLine("Street Address: " + l.Street_Address);
            Console.WriteLine("Country Name: " + l.Country);
            Console.WriteLine("Region Name: " + l.Region);
            Console.WriteLine("==========================================");
            }
        }
    }
}
