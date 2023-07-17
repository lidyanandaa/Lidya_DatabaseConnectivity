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
    public class VCountries
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                GetById(country);
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Id: " + country.id);
            Console.WriteLine("Name: " + country.name);
            Console.WriteLine("Region Id: " + country.region_id);
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
            Console.WriteLine("==========MENU COUNTRY============");
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

        public Country InsertMenu()
        {
            Console.WriteLine("Tambah Id: ");
            int cid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tambah Name: ");
            string cname = Console.ReadLine();

            Console.WriteLine("Tambah Region Id: ");
            int cregid = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                id = cid,
                name = cname,
                region_id = cregid
            };
        }

        public Country UpdateMenu()
        {
            Console.WriteLine("Update Id: ");
            int uid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Name: ");
            string uname = Console.ReadLine();

            Console.WriteLine("Update Region Id: ");
            int uregid = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                id = uid,
                name = uname,
                region_id =  uregid
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Id Country yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
    }
}
