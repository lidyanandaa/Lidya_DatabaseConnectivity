using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VHistories
    {
        public void GetAll(List<History> histories)
        {
            foreach (var history in histories)
            {
                GetById(history);
            }
        }

        public void GetById(History history)
        {
            Console.WriteLine("Start Date: " + history.start_date);
            Console.WriteLine("Employee Id: " + history.employee_id);
            Console.WriteLine("End Date: " + history.end_date);
            Console.WriteLine("Department Id: " + history.department_id);
            Console.WriteLine("Job Id: " + history.job_id);
            Console.WriteLine("==========================");
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
            Console.WriteLine("==========MENU REGION============");
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

        public History InsertMenu()
        {
            Console.Write("Tambah Start Date (YYYY-MM-DD): ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Tambah Employee Id: ");
            int inEmpID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tambah End Date (YYYY-MM-DD): ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Tambah Department Id: ");
            int inputDepID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tambah Job Id: ");
            string inJobID = Console.ReadLine();

            return new History
            {
                start_date = startDate,
                employee_id = inEmpID,
                end_date = endDate,
                department_id = inputDepID,
                job_id = inJobID

            };
        }

        public History UpdateMenu()
        {
            Console.Write("Update Start Date (YYYY-MM-DD): ");
            DateTime ustartDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Update Employee Id: ");
            int uEmpID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Update End Date (YYYY-MM-DD): ");
            DateTime uendDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Update Department Id: ");
            int uDepID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Update Job Id: ");
            string unJobID = Console.ReadLine();

            return new History
            {
                start_date = ustartDate,
                employee_id = uEmpID,
                end_date = uendDate,
                department_id = uDepID,
                job_id = unJobID
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
