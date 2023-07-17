using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    public class LinqController
    {
        private Employee _employee;
        private Department _department;
        private Country _country;
        private Region _region;
        private Location _location;

        public LinqController(Employee employee, Department department, Country country, Region region, Location location)
        {
            _employee = employee;
            _department = department;
            _country = country;
            _region = region;
            _location = location;
        }

        public void DataEmployee()
        {
            var getEmployee = _employee.GetAll();
            var getDepartment = _department.GetAll();
            var getRegion = _region.GetAll();
            var getCountry = _country.GetAll();
            var getLocation = _location.GetAll();

            var dataEmployeeByQuery = (from e in getEmployee
                                       join d in getDepartment on e.id equals d.id
                                       join l in getLocation on d.id equals l.id
                                       join c in getCountry on l.id equals c.id
                                       join r in getRegion on c.id equals r.Id
                                       select new Linq
                                       {
                                           Id = e.id,
                                           First_Name = e.first_name,
                                           Last_Name = e.last_name,
                                           Email = e.email,
                                           Phone_Number = e.phone_number,
                                           Salary = e.salary,
                                           Department_Name = d.name,
                                           Street_Address = l.street_address,
                                           Country = c.name,
                                           Region = r.Name
                                       }).ToList();

            //class variabel = new class();
            VLinq VL = new VLinq();
            VL.GetAll(dataEmployeeByQuery);

            //foreach (var employee in dataEmployeeByQuery)
            //{
              //  Console.WriteLine($"{employee.Id} {employee.First_Name} {employee.Last_Name} {employee.Email} {employee.Phone_Number} {employee.Salary} {employee.Department_Name} {employee.Street_Address} {employee.Country} {employee.Region}");
            //}
        }
    }
}
