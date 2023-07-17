using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VEmployees
    {
        public void GetAll(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                GetById(employee);
            }
        }

        public void GetById(Employee employee)
        {
            Console.WriteLine("Id: " + employee.id);
            Console.WriteLine("First Name: " + employee.first_name);
            Console.WriteLine("Last Name: " + employee.last_name);
            Console.WriteLine("Email: " + employee.email);
            Console.WriteLine("Phone Number: " + employee.phone_number);
            Console.WriteLine("Hire Date: " + employee.hire_date);
            Console.WriteLine("Salary: " + employee.salary);
            Console.WriteLine("Comission PCT: " + employee.commission_pct);
            Console.WriteLine("Manager ID: " + employee.manager_id);
            Console.WriteLine("Job ID: " + employee.job_id);
            Console.WriteLine("Department ID: " + employee.department_id);
            Console.WriteLine("=====================================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("Data Not Found!");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Fail, Id not found!");
        }

        public void Error()
        {
            Console.WriteLine("Error retrieving from database!");
        }

        public int Menu()
        {
            Console.WriteLine("==========MENU EMPLOYEE============");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update ");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Get By Id");
            Console.WriteLine("6. Back");
            Console.WriteLine("======================");
            Console.WriteLine("Input:");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Employee InsertMenu()
        {
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string first_name = Console.ReadLine();
            Console.Write("Last Name : ");
            string last_name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Hire Date (MM//DD/YYYY) : ");
            DateTime hire_date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Comission PCT : ");
            decimal comission = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Job ID : ");
            string job_id = Console.ReadLine();
            Console.Write("Department ID : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                id = id,
                first_name = first_name,
                last_name = last_name,
                email = email,
                phone_number = phone,
                hire_date = hire_date,
                salary = salary,
                commission_pct = comission,
                manager_id = id,
                job_id = job_id,
                department_id = department_id
            };
        }

        public Employee UpdateMenu()
        {
            Console.Write("Id yang ingin diupdate : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string first_name = Console.ReadLine();
            Console.Write("Last Name : ");
            string last_name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Hire Date (MM//DD/YYYY) : ");
            DateTime hire_date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Comission PCT : ");
            decimal comission = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Job ID : ");
            string job_id = Console.ReadLine();
            Console.Write("Department ID : ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                id = id,
                first_name = first_name,
                last_name = last_name,
                email = email,
                phone_number = phone,
                hire_date = hire_date,
                salary = salary,
                commission_pct = comission,
                manager_id = id,
                job_id = job_id,
                department_id = department_id
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Id Employee yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

    }
}
