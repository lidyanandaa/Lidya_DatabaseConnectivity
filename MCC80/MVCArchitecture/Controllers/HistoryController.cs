using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    public class HistoryController
    {
        private History _historyModel;
        private VHistories _historyView;

        public HistoryController(History historyModel, VHistories historyView)
        {
            _historyModel = historyModel;
            _historyView = historyView;
        }

        public void GetAll()
        {
            var result = _historyModel.GetAll();
            if (result.Count is 0)
            {
                _historyView.DataEmpty();
            }
            else
            {
                _historyView.GetAll(result);
            }
        }

        public void Insert()
        {
            var history = _historyView.InsertMenu();

            var result = _historyModel.Insert(history);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Update()
        {
            var history = _historyView.UpdateMenu();
            var result = _historyModel.Update(history);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var history = _historyView.DeleteMenu();
            var result = _historyModel.Delete(history);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void GetById(int id)
        {
            var history = _historyModel.GetById(id);

            if (history is null)
            {
                _historyView.Failure();
            }
            else
            {
                _historyView.GetById(history);
            }
        }
    }
}
