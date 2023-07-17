using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VJobs
    {
        public void GetAll(List<Job> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(Job job)
        {
            Console.WriteLine("Id: " + job.id);
            Console.WriteLine("Title: " + job.title);
            Console.WriteLine("Min Salary: " + job.min_salary);
            Console.WriteLine("Max Salary: " + job.max_salary);
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
            Console.WriteLine("==========MENU JOB============");
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

        public Job InsertMenu()
        {
            Console.WriteLine("Tambah Id: ");
            string iid = Console.ReadLine();

            Console.WriteLine("Tambah Title: ");
            string ititle = Console.ReadLine();

            Console.WriteLine("Tambah Min Salary: ");
            int imin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tambah Max Salary: ");
            int imax = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                id = iid,
                title = ititle,
                min_salary = imin,
                max_salary = imax
            };
        }

        public Job UpdateMenu()
        {
            Console.WriteLine("Update Id: ");
            string uid = Console.ReadLine();

            Console.WriteLine("Update Title: ");
            string utitle = Console.ReadLine();

            Console.WriteLine("Update Min Salary: ");
            int umin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Max Salary: ");
            int umax = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                id = uid,
                title = utitle,
                min_salary = umin,
                max_salary = umax
            };
        }

        public string DeleteMenu()
        {
            Console.WriteLine("Id Job yang ingin dihapus: ");
            string id = Console.ReadLine();
            return id;
        }
    }
}
