using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCArchitecture.Views
{
    public class VDepartments
    {
        public void GetAll(List<Department> departments)
        {
            foreach (var department in departments)
            {
                GetById(department);
            }
        }

        public void GetById(Department department)
        {
            Console.WriteLine("Id: " + department.id);
            Console.WriteLine("Nama: " + department.name);
            Console.WriteLine("Location Id: " + department.location_id);
            Console.WriteLine("Manager Id: " + department.manager_id);
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
            Console.WriteLine("==========MENU DEPARTMENT============");
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

        public Department InsertMenu()
        {
            Console.WriteLine("Tambah Id: ");
            int iid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tambah Nama: ");
            string inama = Console.ReadLine();

            Console.WriteLine("Tambah Location Id: ");
            int iloc = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tambah Manager Id: ");
            int iman = Convert.ToInt32(Console.ReadLine());

            return new Department
            {
                id = iid,
                name = inama,
                location_id = iloc,
                manager_id = iman
            };
        }

        public Department UpdateMenu()
        {
            Console.WriteLine("Update Id: ");
            int uid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Nama: ");
            string unama = Console.ReadLine();

            Console.WriteLine("Update Location Id: ");
            int uloc = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Department Id: ");
            int uman = Convert.ToInt32(Console.ReadLine());

            return new Department
            {
                id = uid,
                name = unama,
                location_id = uloc,
                manager_id = uman
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Id Region yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
    }
}
