using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    public class CountryController
    {
        private Country _countryModel;
        private VCountries _countryView;

        public CountryController(Country countryModel, VCountries countryView)
        {
            _countryModel = countryModel;
            _countryView = countryView;
        }

        public void GetAll()
        {
            var result = _countryModel.GetAll();
            if (result.Count is 0)
            {
                _countryView.DataEmpty();
            }
            else
            {
                _countryView.GetAll(result);
            }
        }

        public void Insert()
        {
            var country = _countryView.InsertMenu();

            var result = _countryModel.Insert(country);
            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void Update()
        {
            var country = _countryView.UpdateMenu();
            var result = _countryModel.Update(country);

            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var country = _countryView.DeleteMenu();
            var result = _countryModel.Delete(country);

            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void GetById(int id)
        {
            var country = _countryModel.GetById(id);

            if (country is null)
            {
                _countryView.Failure();
            }
            else
            {
                _countryView.GetById(country);
            }
        }
    }
}
