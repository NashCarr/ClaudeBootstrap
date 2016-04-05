using System;
using System.Collections.Generic;
using CommonDataRetrieval.Customer;
using DataLayerRetrieval.Customer;

namespace ManagementRetrieval.Customer
{
    public class CustomerBrandGetManager : IDisposable
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
            using (DbCustomerBrandGet db = new DbCustomerBrandGet())
            {
                return db.GetViewModel(customerId);
            }
        }
    }
}