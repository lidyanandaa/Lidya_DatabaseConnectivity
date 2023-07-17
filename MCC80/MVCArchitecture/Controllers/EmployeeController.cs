using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    public class EmployeeController
    {
        private Employee _employeeModel;
        private VEmployees _employeeView;

        public EmployeeController(Employee employeeModel, VEmployees employeeView)
        {
            _employeeModel = employeeModel;
            _employeeView = employeeView;
        }

        public void GetAll()
        {
            var result = _employeeModel.GetAll();
            if (result.Count is 0)
            {
                _employeeView.DataEmpty();
            }
            else
            {
                _employeeView.GetAll(result);
            }
        }

        public void Insert()
        {
            var employee = _employeeView.InsertMenu();

            var result = _employeeModel.Insert(employee);
            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Update()
        {
            var employee = _employeeView.UpdateMenu();
            var result = _employeeModel.Update(employee);

            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var employee = _employeeView.DeleteMenu();
            var result = _employeeModel.Delete(employee);

            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void GetById(int id)
        {
            var employee = _employeeModel.GetById(id);

            if (employee is null)
            {
                _employeeView.Failure();
            }
            else
            {
                _employeeView.GetById(employee);
            }
        }
    }
}
