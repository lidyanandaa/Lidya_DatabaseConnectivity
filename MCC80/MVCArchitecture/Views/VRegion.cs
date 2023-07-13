﻿using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Views
{
    public class VRegion
    {
        public void GetAll(List<Region> regions)
        {
            foreach (var region in regions)
            {
                GetById(region);
            }
        }

        public void GetById(Region region)
        {
            Console.WriteLine("Id: " + region.Id);
            Console.WriteLine("Name: " + region.Name);
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

        public Region InsertMenu()
        {
            Console.WriteLine("Masukan Nama: ");
            string? inputName = Console.ReadLine();

            return new Region
            {
                Id = 0,
                Name = inputName
            };
        }

        public Region UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nama: ");
            string name = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = name
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
