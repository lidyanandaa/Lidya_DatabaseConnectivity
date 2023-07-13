using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    public class RegionController
    {
        private Region _regionModel;
        private VRegion _regionView;

        public RegionController(Region regionModel, VRegion regionView)
        {
            _regionModel = regionModel;
            _regionView = regionView;
        }

        public void GetAll()
        {
            var result = _regionModel.GetAll();
            if (result.Count is 0)
            {
                _regionView.DataEmpty();
            }
            else
            {
                _regionView.GetAll(result);
            }
        }

        public void Insert()
        {
            var region = _regionView.InsertMenu();

            var result = _regionModel.Insert(region);
            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Update()
        {
            var region = _regionView.UpdateMenu();
            var result = _regionModel.Update(region);

            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Delete()
        {
            int region = _regionView.DeleteMenu();
            int result = _regionModel.Delete(region);
        
            switch (result)
            {
                case -1:
                    _regionView.Error();
                break;
                case 0:
                    _regionView.Failure();
                break;
                default: 
                    _regionView.Success();
                break;
            }
        }

        public void GetById()
        {
            int id = _regionView.SearchByIdMenu();
            var region = _regionModel.GetById(id);

            if (region == null)
            {
                _regionView.Failure();
            }
            else
            {
                _regionView.GetById(region);
            }
        }
    }
}
