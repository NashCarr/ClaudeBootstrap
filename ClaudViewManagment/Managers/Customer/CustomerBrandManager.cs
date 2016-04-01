using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using CommonData.Models.Customer;
using DataManagement.DataRepository.CustomerRepository;
using DataManagement.DataRepository.ReorderRepository;

namespace ViewManagement.Managers.Customer
{
    public class CustomerBrandManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<CustomerBrand> GetList(int customerId)
        {
            using (DbCustomerBrandGet data = new DbCustomerBrandGet())
            {
                return data.GetViewModel(customerId);
            }
        }

        public ReturnBase SaveRecord(CustomerBrand entity)
        {
            using (DbCustomerBrandSave data = new DbCustomerBrandSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.CustomerBrandReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbCustomerBrandSave data = new DbCustomerBrandSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}