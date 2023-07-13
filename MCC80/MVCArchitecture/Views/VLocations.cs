using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VLocations
    {
        public void GetAll(List<Location> locations)
        {
            foreach (var location in locations)
            {
                GetById(location);
            }
        }

        public void GetById(Location location)
        {
            Console.WriteLine("Id: " + location.id);
            Console.WriteLine("Street Address: " + location.street_address);
            Console.WriteLine("Postal Code: " + location.postal_code);
            Console.WriteLine("City: " + location.city);
            Console.WriteLine("State Province: " + location.state_province);
            Console.WriteLine("Country Id: " + location.country_id);
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
            Console.WriteLine("==========MENU LOCATION============");
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

        public Location InsertMenu()
        {
            Console.WriteLine("Tambah Id: ");
            int iid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tambah Street Address: ");
            string isa = Console.ReadLine();

            Console.WriteLine("Tambah Postal Code: ");
            string ipc = Console.ReadLine();

            Console.WriteLine("Tambah City: ");
            string icity = Console.ReadLine();

            Console.WriteLine("Tambah State Province: ");
            string isp = Console.ReadLine();

            Console.WriteLine("Tambah Country Id: ");
            int ici = Convert.ToInt32(Console.ReadLine());

            return new Location
            {
                id = iid,
                street_address = isa,
                postal_code = ipc,
                city = icity,
                state_province = isp,
                country_id = ici
            };
        }

        public Location UpdateMenu()
        {
            Console.WriteLine("Update Id: ");
            int uid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Street Address: ");
            string usa = Console.ReadLine();

            Console.WriteLine("Update Postal Code: ");
            string upc = Console.ReadLine();

            Console.WriteLine("Update City: ");
            string ucity = Console.ReadLine();

            Console.WriteLine("Update State Province: ");
            string usp = Console.ReadLine();

            Console.WriteLine("Update Country Id: ");
            int uci = Convert.ToInt32(Console.ReadLine());

            return new Location
            {
                id = uid,
                street_address = usa,
                postal_code = upc,
                city = ucity,
                state_province = usp,
                country_id = uci
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Id Locatioin yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public int SearchByIdMenu()
        {
            Console.WriteLine("Search Data");
            Console.WriteLine("===========");
            Console.Write("Id : ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            return id;
        }
    }
}
