using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using DataManagement.DataRepository.CustomerRepository;
using DataManagement.DataRepository.PlaceRepository;
using DataManagement.DataRepository.ReorderRepository;
using DataManagement.ViewModels;

namespace ViewManagement.Managers.Customer
{
    public class CustomerManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public CustomerView GetCustomer(int recordId)
        {
            using (DbCustomerViewGet data = new DbCustomerViewGet())
            {
                return data.GetCustomer(recordId);
            }
        }

        public void SaveDisplayOrder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.CustomerReorderSave(data);
            }
        }

        public ReturnBase DeleteCustomer(int id)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                return data.SetCustomerInactive(id);
            }
        }
    }
}