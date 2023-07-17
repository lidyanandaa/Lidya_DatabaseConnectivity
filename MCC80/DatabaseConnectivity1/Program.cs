using DatabaseConnectivity1;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity;

class Program
{
    private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";
    
    //penamaan private harus ada _ nya didepannya
    private static SqlConnection _connection;
    public static void Main()
    {
        //--REGIONS--DONE
        //GetRegions();
        //InsertRegions("Jawa Barat");
        //UpdateRegions(14, "Jawa Timur");
        //DeleteRegions(1015);
        //GetRegionById(id: 14);

        //--JOBS--DONE
        //GetJobs();
        //InsertJobs("31", "Admin", 5000, 8000); 
        //UpdateJobs("1", "General", 3000, 5000);
        //DeleteJobs("31");
        //GetJobsById(id: 1);

        //--COUNTRIES--DONE
        //GetCountries();
        //InsertCountries(21, "Libya", 2); 
        //UpdateCountries(21, "Korean", 5);
        //DeleteCountries(21);
        //GetCountriesById(id: 1);

        //--LOCATIONS--DONE
        //GetLocations();
        //InsertLocations(31, "Jambangan", 1287, "Suroboyo", "Alaska", 2);
        //UpdateLocations(31, "Indah", 1284897, "Surabaya", "Omnia", 5);
        //DeleteLocations(31);
        //GetLocationsById(id: 1);

        //--DEPARTMENTS--DONE
        //GetDepartments();
        //InsertDepartments(31, "IT Support", 2, 2);
        //UpdateDepartments(31, "IT", 1,4);
        //DeleteDepartments(31);
        //GetDepartmentsById(id: 1);

        //--EMPLOYEES
        //GetEmployees();
        //InsertEmployees(31, "Lidya", "Ananda", "Lidya@gmail.com", "7782781", 23/07/2022, 22000, 71000.07, 2, "5", 3);
        //UpdateEmployees(31, "Indah", 1284897, "Surabaya", "Omnia", 5);
        //DeleteEmployees(31);
        //GetEmployeesById(id: 1);

        //--HISTORIES 
        //GetHistories();
        //InsertHistories(31, "Jambangan", 1287, "Suroboyo", "Alaska", 2);
        //UpdateHistories(31, "Indah", 1284897, "Surabaya", "Omnia", 5);
        //DeleteHistories(31);
        //GetHistoriesById("23/07/2022") ;
        //..............................................................................................
        //---------------CLASS
        //CLASS REGIONS
        //Regions.GetRegions();
        //Regions.InsertRegions("Jawa Barat");
        //Regions.UpdateRegions(14, "Jawa Timur");
        //Regions.DeleteRegions(1015);
        //Regions.GetRegionById(id: 14);

        //CLASS JOBS
        //Jobs.GetJobs();
        //Jobs.InsertJobs("31", "Admin", 5000, 8000); 
        //Jobs.UpdateJobs("1", "General", 3000, 5000);
        //Jobs.DeleteJobs("31");
        //Jobs.GetJobsById(id: 1);

        //CLASS COUNTRIES
        //Countries.GetCountries();
        //Countries.InsertCountries(21, "Libya", 2); 
        //Countries.UpdateCountries(21, "Korean", 5);
        //Countries.DeleteCountries(21);
        //Countries.GetCountriesById(id: 1);

        //CLASS LOCATIONS
        //Locations.GetLocations();
        //Locations.InsertLocations(31, "Jambangan", 1287, "Suroboyo", "Alaska", 2);
        //Locations.UpdateLocations(31, "Indah", 1284897, "Surabaya", "Omnia", 5);
        //Locations.DeleteLocations(31);
        //Locations.GetLocationsById(id: 1);

        Program p = new Program();
        while (true)
        {
            Menu();
            Console.WriteLine("Input:");
            int pilih = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (pilih)
            {
                case 1:
                    MenuRegions();
                    break;

                case 2:
                    MenuJobs();
                    break;

                case 3:
                    MenuCountries();
                    break;

                case 4:
                    MenuLocations();
                    break;

                case 5:
                    MenuDepartments();
                    break;

                case 6:
                    MenuEmployees();
                    break;

                case 7:
                    MenuHistories();
                    break;

                case 8:
                    Console.WriteLine("Anda sudah keluar.");
                    return;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.Clear();
        }
    }

    public static void Menu()
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
    }

    public static void MenuRegions()
    {
        Console.WriteLine("==========MENU REGION============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("======================");

        Console.WriteLine("Masukkan no 1-6: ");
        int pilihregion = Convert.ToInt32(Console.ReadLine());

        switch (pilihregion)
        {
            case 1:
                Regions.GetRegions();

                Console.WriteLine();
                MenuRegions();
                break; 

            case 2:
                Console.WriteLine("Tambah Nama Region: ");
                string insertr = Console.ReadLine();
                Regions.InsertRegions(insertr);

                Console.WriteLine();
                MenuRegions();
                break; 

            case 3:
                Console.WriteLine("Update Id Region: ");
                int updateidr = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Nama Region: ");
                string updatenamer = Console.ReadLine();
                Regions.UpdateRegions(updateidr, updatenamer);

                Console.WriteLine();
                MenuRegions();
                break; 

            case 4:
                Console.WriteLine("Id Region yang ingin dihapus: ");
                int deleter = Convert.ToInt32(Console.ReadLine());
                Regions.DeleteRegions(deleter);

                Console.WriteLine();
                MenuRegions();
                break;

            case 5:
                Console.Write("Region Id: ");
                int Byidr = Convert.ToInt32(Console.ReadLine());
                Regions.GetRegionById(Byidr);

                Console.WriteLine();
                MenuRegions();
                break;

            case 6:
                Menu();
                return;
        }
    }
    public static void MenuJobs()
    {
        Console.WriteLine("==========MENU JOB============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihjobs = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihjobs)
        {
            case 1:
                Jobs.GetJobs();

                Console.WriteLine();
                MenuJobs();
                break;

            case 2:
                Console.WriteLine("Tambah Id: ");
                string iid = Console.ReadLine();

                Console.WriteLine("Tambah Title: ");
                string ititle = Console.ReadLine();

                Console.WriteLine("Tambah Min Salary: ");
                int imin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah Max Salary: ");
                int imax = Convert.ToInt32(Console.ReadLine());
                Jobs.InsertJobs(iid, ititle, imin, imax);

                Console.WriteLine();
                MenuJobs();
                break;

            case 3:
                Console.WriteLine("Update Id: ");
                string uid = Console.ReadLine();

                Console.WriteLine("Update Title: ");
                string utitle = Console.ReadLine();

                Console.WriteLine("Update Min Salary: ");
                int umin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Max Salary: ");
                int umax = Convert.ToInt32(Console.ReadLine());
                Jobs.UpdateJobs(uid, utitle, umin, umax);

                Console.WriteLine();
                MenuJobs();
                break;

            case 4:
                Console.WriteLine("Id Jobs yang ingin dihapus: ");
                string did = Console.ReadLine();
                Jobs.DeleteJobs(did);

                Console.WriteLine();
                MenuJobs();
                break;

            case 5:
                Console.Write("Jobs Id: ");
                String bid = Console.ReadLine();
                Jobs.GetJobsById(bid);

                Console.WriteLine();
                MenuJobs();
                break;

            case 6:
                Menu();
                return;
        }
    }

    public static void MenuCountries()
    {
        Console.WriteLine("==========MENU COUNTRIES============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihcountries = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihcountries)
        {
            case 1:
                Countries.GetCountries();

                Console.WriteLine();
                MenuCountries();
                break;

            case 2:
                Console.WriteLine("Tambah Id: ");
                int cid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah Name: ");
                string cname = Console.ReadLine();

                Console.WriteLine("Tambah Region Id: ");
                int cregid = Convert.ToInt32(Console.ReadLine());
                Countries.InsertCountries(cid, cname, cregid);

                Console.WriteLine();
                MenuCountries();
                break;

            case 3:
                Console.WriteLine("Update Id: ");
                int uid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Name: ");
                string uname = Console.ReadLine();

                Console.WriteLine("Update Region Id: ");
                int uregid = Convert.ToInt32(Console.ReadLine());
                Countries.UpdateCountries(uid, uname, uregid);

                Console.WriteLine();
                MenuCountries();
                break;

            case 4:
                Console.WriteLine("Id Countries yang ingin dihapus: ");
                int countryid = Convert.ToInt32(Console.ReadLine());
                Countries.DeleteCountries(countryid);

                Console.WriteLine();
                MenuCountries();
                break;

            case 5:
                Console.Write("Countries Id: ");
                int gid = Convert.ToInt32(Console.ReadLine());
                Countries.GetCountriesById(gid);

                Console.WriteLine();
                MenuCountries();
                break;

            case 6:
                Menu();
                return;
        }
    }

    public static void MenuLocations()
    {
        Console.WriteLine("==========MENU JOB============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihlocations = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihlocations)
        {
            case 1:
                Locations.GetLocations();

                Console.WriteLine();
                MenuLocations();
                break;

            case 2:
                Console.WriteLine("Tambah Id: ");
                int iid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah Street Address: ");
                string isa = Console.ReadLine();

                Console.WriteLine("Tambah Postal Code: ");
                int ipc = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah City: ");
                string icity = Console.ReadLine();

                Console.WriteLine("Tambah State Province: ");
                string isp = Console.ReadLine();

                Console.WriteLine("Tambah Country Id: ");
                int ici = Convert.ToInt32(Console.ReadLine());
                Locations.InsertLocations(iid, isa, ipc, icity, isp, ici);

                Console.WriteLine();
                MenuLocations();
                break;

            case 3:
                Console.WriteLine("Update Id: ");
                int uid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Street Address: ");
                string usa = Console.ReadLine();

                Console.WriteLine("Update Postal Code: ");
                int upc = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update City: ");
                string ucity = Console.ReadLine();

                Console.WriteLine("Update State Province: ");
                string usp = Console.ReadLine();

                Console.WriteLine("Update Country Id: ");
                int uci = Convert.ToInt32(Console.ReadLine());
                Locations.UpdateLocations(uid,usa, upc, ucity, usp, uci);

                Console.WriteLine();
                MenuLocations();
                break;

            case 4:
                Console.WriteLine("Id Locations yang ingin dihapus: ");
                int did = Convert.ToInt32(Console.ReadLine());
                Locations.DeleteLocations(did);

                Console.WriteLine();
                MenuLocations();
                break;

            case 5:
                Console.Write("Location Id: ");
                int lid = Convert.ToInt32(Console.ReadLine());
                Locations.GetLocationsById(lid);

                Console.WriteLine();
                MenuLocations();
                break;

            case 6:
                Menu();
                return;
        }
    }

    public static void MenuDepartments()
    {
        Console.WriteLine("==========MENU DEPARTMENTS============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihdepartments = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihdepartments)
        {
            case 1:
                Departments.GetDepartments();

                Console.WriteLine();
                MenuDepartments();
                break;

            case 2:
                Console.WriteLine("Tambah Id: ");
                int iid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah Nama: ");
                string inama = Console.ReadLine();

                Console.WriteLine("Tambah Location Id: ");
                int iloc = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Tambah Department Id: ");
                int idep = Convert.ToInt32(Console.ReadLine());
                Departments.InsertDepartments(iid, inama, iloc, idep);

                Console.WriteLine();
                MenuDepartments();
                break;

            case 3:
                Console.WriteLine("Update Id: ");
                int uid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Nama: ");
                string unama = Console.ReadLine();

                Console.WriteLine("Update Location Id: ");
                int uloc = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update Department Id: ");
                int udep = Convert.ToInt32(Console.ReadLine());
                Departments.UpdateDepartments(uid, unama, uloc, udep);

                Console.WriteLine();
                MenuDepartments();
                break;

            case 4:
                Console.WriteLine("Id Department yang ingin dihapus: ");
                int did = Convert.ToInt32(Console.ReadLine());
                Departments.DeleteDepartments(did);

                Console.WriteLine();
                MenuDepartments();
                break;

            case 5:
                Console.Write("Department Id: ");
                int bid = Convert.ToInt32(Console.ReadLine());
                Departments.GetDepartmentsById(bid);

                Console.WriteLine();
                MenuDepartments();
                break;

            case 6:
                Menu();
                return;
        }
    }

    public static void MenuEmployees()
    {
        Console.WriteLine("==========MENU EMPLOYEE============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihemployee = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihemployee)
        {
            case 1:
                Employees.GetEmployees();

                Console.WriteLine();
                MenuEmployees();
                break;

            case 2:
                Console.Write("Tambah Id: ");
                int iid = Convert.ToInt32(Console.ReadLine());

                Console.Write("Tambah First Name: ");
                string ifn = Console.ReadLine();

                Console.Write("Tambah Last Name: ");
                string iln = Console.ReadLine();

                Console.Write("Tambah Email: ");
                string iemail = Console.ReadLine();

                Console.Write("Tambah Phone Number: ");
                string ipn = Console.ReadLine();

                Console.Write("Tambah Hire Date (YYYY-MM-DD): ");
                string ihd = Console.ReadLine();

                Console.Write("Tambah Salary: ");
                int isalary = Convert.ToInt32(Console.ReadLine());

                Console.Write("Tambah Commission PCT: ");
                decimal icp = Decimal.Parse(Console.ReadLine());

                Console.Write("Tambah Manager Id: ");
                int imi = Convert.ToInt32(Console.ReadLine());

                Console.Write("Tambah Job Id: ");
                string iji = Console.ReadLine();

                Console.Write("Tambah Department Id: ");
                int idi = Convert.ToInt32(Console.ReadLine());

                DateTime hireDate;
                if (DateTime.TryParse(ihd, out hireDate))
                {
                    Employees.InsertEmployees(iid, ifn, iln, iemail, ipn, hireDate, isalary,
                        icp, imi, iji, idi);
                }
                else
                {
                    Console.WriteLine("Invalid Hire Date format. Please enter a valid date (YYYY-MM-DD).");
                }

                Console.WriteLine();
                MenuEmployees();
                break;

            case 3:
                Console.Write("Update Id: ");
                int uid = Int32.Parse(Console.ReadLine());

                Console.Write("Update First Name: ");
                string ufn = Console.ReadLine();

                Console.Write("Update Last Name: ");
                string uln = Console.ReadLine();

                Console.Write("Update Email: ");
                string uemail = Console.ReadLine();

                Console.Write("Update Phone Number: ");
                string upn = Console.ReadLine();

                Console.Write("Update Hire Date (YYYY-MM-DD): ");
                string uhd = Console.ReadLine();

                Console.Write("Update Salary: ");
                int usalary = Int32.Parse(Console.ReadLine());

                Console.Write("Update Commission PCT: ");
                decimal ucp = Decimal.Parse(Console.ReadLine());

                Console.Write("Update Manager Id: ");
                int umi = Int32.Parse(Console.ReadLine());

                Console.Write("Update Job Id: ");
                string uji = Console.ReadLine();

                Console.Write("Update Department Id: ");
                int udi = Int32.Parse(Console.ReadLine());

                DateTime uhireDate;
                if (DateTime.TryParse(uhd, out uhireDate))
                {
                    Employees.UpdateEmployees(uid, ufn, uln, uemail, upn, uhireDate, usalary,
                        ucp, umi, uji, udi);
                }
                else
                {
                    Console.WriteLine("Invalid Hire Date format. Please enter a valid date (YYYY-MM-DD).");
                }

                    Console.WriteLine();
                MenuEmployees();
                break;

            case 4:
                Console.WriteLine("Id Employee yang ingin dihapus: ");
                int did = Convert.ToInt32(Console.ReadLine());
                Employees.DeleteEmployees(did);

                Console.WriteLine();
                MenuEmployees();
                break;

            case 5:
                Console.Write("Employee Id: ");
                int bid = Convert.ToInt32(Console.ReadLine());
                Employees.GetEmployeesById(bid);

                Console.WriteLine();
                MenuEmployees();
                break;

            case 6:
                Menu();
                return;
        }
    }

    public static void MenuHistories()
    {
        Console.WriteLine("==========MENU HISTORIES============");
        Console.WriteLine("1. Get All");
        Console.WriteLine("2. Insert");
        Console.WriteLine("3. Update ");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Get By Id");
        Console.WriteLine("6. Back");
        Console.WriteLine("==============================");
        Console.WriteLine("Input:");
        int pilihhistories = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (pilihhistories)
        {
            case 1:
                Histories.GetHistories();

                Console.WriteLine();
                MenuHistories();
                break;

            case 2:
                Console.Write("Tambah Start Date (YYYY-MM-DD): ");
                string inStart = Console.ReadLine();

                DateTime startDate;
                if (DateTime.TryParse(inStart, out startDate))
                {
                    Console.WriteLine("Start Date: " + startDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    Console.WriteLine("Invalid Start Date format. Please enter a valid date (YYYY-MM-DD).");
                    return;
                }

                Console.Write("Tambah Employee Id: ");
                int inEmpID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Tambah End Date (YYYY-MM-DD): ");
                string inEnd = Console.ReadLine();
                DateTime endDate;
                if (DateTime.TryParse(inEnd, out endDate))
                {
                    Console.WriteLine("End Date: " + endDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    // Invalid DateTime value
                    Console.WriteLine("Invalid End Date format. Please enter a valid date (YYYY-MM-DD).");
                    return; // Exit the method if the date is invalid
                }

                Console.Write("Tambah Department Id: ");
                int inputDepID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Tambah Job Id: ");
                string inJobID = Console.ReadLine();
                Histories.InsertHistories(startDate, inEmpID, endDate, inputDepID, inJobID);

                Console.WriteLine();
                MenuHistories();
                break;

            case 3:
                Console.Write("Update Start Date (YYYY-MM-DD): ");
                string usd = Console.ReadLine();

                DateTime ustartDate;
                if (DateTime.TryParse(usd, out ustartDate))
                {
                    // Valid DateTime value
                    Console.WriteLine("Start Date: " + ustartDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    // Invalid DateTime value
                    Console.WriteLine("Invalid Start Date format. Please enter a valid date (YYYY-MM-DD).");
                    return;
                }

                Console.Write("Update Employee ID: ");
                int ueid = int.Parse(Console.ReadLine());

                Console.Write("Update End Date (YYYY-MM-DD): ");
                string ued = Console.ReadLine();

                DateTime uendDate;
                if (DateTime.TryParse(ued, out uendDate))
                {
                    // Valid DateTime value
                    Console.WriteLine("End Date: " + uendDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    // Invalid DateTime value
                    Console.WriteLine("Invalid End Date format. Please enter a valid date (YYYY-MM-DD).");
                    return;
                }

                Console.Write("Update Department ID: ");
                int udid = int.Parse(Console.ReadLine());

                Console.Write("Update Job ID: ");
                string ujid = Console.ReadLine();

                Histories.UpdateHistories(ustartDate, ueid, uendDate, udid, ujid);

                Console.WriteLine();
                MenuHistories();
                break;

            case 4:
                Console.WriteLine("Id Employee yang ingin dihapus: ");
                int heid = Convert.ToInt32(Console.ReadLine());
                Histories.DeleteHistories(heid);

                Console.WriteLine();
                MenuHistories();
                break;

            case 5:
                Console.Write("Employee Id: ");
                int hid = Convert.ToInt32(Console.ReadLine());
                Histories.GetHistoriesById(hid);

                Console.WriteLine();
                MenuHistories();
                break;

            case 6:
                Menu();
                return;
        }
    }
}