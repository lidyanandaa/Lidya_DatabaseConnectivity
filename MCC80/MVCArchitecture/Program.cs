
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
            Console.WriteLine("8. Exit");
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

    }

    private static void CountryMenu()
    {

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

    }

    private static void EmployeeMenu()
    {

    }

    private static void HistoryMenu()
    {

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