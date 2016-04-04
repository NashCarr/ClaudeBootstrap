using System;
using System.Collections.Generic;
using DataLayerRetrieval.Customer;
using ViewDataCommon.Customer;

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
            using (DbCustomerBrandGet data = new DbCustomerBrandGet())
            {
                return data.GetViewModel(customerId);
            }
        }
    }
}