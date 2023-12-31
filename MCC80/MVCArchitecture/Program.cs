﻿    
using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics;

namespace MVCArchitecture;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool ulang = true;
        do
        {
            Console.WriteLine("== MENU DATABASE LIDYA ANANDA ==");
            Console.WriteLine("================================");
            Console.WriteLine("1. Regions");
            Console.WriteLine("2. Jobs");
            Console.WriteLine("3. Countries");
            Console.WriteLine("4. Locations");
            Console.WriteLine("5. Departments");
            Console.WriteLine("6. Employees");
            Console.WriteLine("7. Histories");
            Console.WriteLine("8. Linq");
            Console.WriteLine("9. Exit");
            Console.WriteLine("================================");
            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());
                switch (pilihMenu)
                {
                    case 1:
                        RegionMenu();
                        break;
                    case 2:
                        JobMenu();
                        break;
                    case 3:
                        CountryMenu();
                        break;
                    case 4:
                        LocationMenu();
                        break;
                    case 5:
                        DepartmentMenu();
                        break;
                    case 6:
                        EmployeeMenu();
                        break;
                    case 7:
                        HistoryMenu();
                        break;
                    case 8:
                        MenuLinq();
                        break;
                    case 9:
                        ulang = false;
                        break;
                    default:
                        Console.WriteLine("Input :");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e);
                Console.WriteLine("Input Hanya diantara 1-7!");
            }
        } while (ulang);
    }

    public static void MenuLinq()
    {
        var employee = new Employee();
        var department = new Department();
        var region = new Region();
        var country = new Country();
        var location = new Location();
        var linq = new LinqController(employee, department, country, region, location);
        linq.DataEmployee();
    }
    private static void RegionMenu()
    {
        Region region = new Region();
        VRegion vRegion = new VRegion();
        RegionController regionController = new RegionController(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            switch (pilihMenu)
            {
                case 1:
                    regionController.GetAll();
                    PressAnyKey();
                    break; 
                case 2:
                    regionController.Insert();
                    PressAnyKey();
                    break; 
                case 3:
                    regionController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    regionController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    regionController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void JobMenu()
    {
        Job job = new Job();
        VJobs vJobs = new VJobs();
        JobController jobController = new JobController(job, vJobs);

        bool isTrue = true;
        do
        {
            int pilihMenu = vJobs.Menu();
            switch (pilihMenu)
            {
                case 1:
                    jobController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    jobController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    jobController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    jobController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    string id = Console.ReadLine();
                    jobController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void CountryMenu()
    {
        Country country = new Country();
        VCountries vCountry = new VCountries();
        CountryController countryController = new CountryController(country, vCountry);

        bool isTrue = true;
        do
        {
            int pilihMenu = vCountry.Menu();
            switch (pilihMenu)
            {
                case 1:
                    countryController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    countryController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    countryController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    countryController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    countryController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationMenu()
    {
        Location location = new Location();
        VLocations vLocation = new VLocations();
        LocationController locationController = new LocationController(location, vLocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vLocation.Menu();
            switch (pilihMenu)
            {
                case 1:
                    locationController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    locationController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    locationController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    locationController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    locationController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void DepartmentMenu()
    {
        Department department = new Department();
        VDepartments vDepartments = new VDepartments();
        DepartmentController departmentController = new DepartmentController(department, vDepartments);

        bool isTrue = true;
        do
        {
            int pilihMenu = vDepartments.Menu();
            switch (pilihMenu)
            {
                case 1:
                    departmentController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    departmentController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    departmentController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    departmentController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void EmployeeMenu()
    {
        Employee employee = new Employee();
        VEmployees vEmployees = new VEmployees();
        EmployeeController employeeController = new EmployeeController(employee, vEmployees);

        bool isTrue = true;
        do
        {
            int pilihMenu = vEmployees.Menu();
            switch (pilihMenu)
            {
                case 1:
                    employeeController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    employeeController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    employeeController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    employeeController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    employeeController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void HistoryMenu()
    {
        History history = new History();
        VHistories vHistory = new VHistories();
        HistoryController historyController = new HistoryController(history, vHistory);

        bool isTrue = true;
        do
        {
            int pilihMenu = vHistory.Menu();
            switch (pilihMenu)
            {
                case 1:
                    historyController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    historyController.Insert();
                    PressAnyKey();
                    break;
                case 3:
                    historyController.Update();
                    PressAnyKey();
                    break;
                case 4:
                    historyController.Delete();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Write("Masukkan Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    historyController.GetById(id);
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}