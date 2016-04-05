using System;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.Customer;

namespace ManagementRetrieval.Customer
{
    public class CustomerGetManager : IDisposable
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
            using (DbCustomerViewGet db = new DbCustomerViewGet())
            {
                return db.GetCustomer(recordId);
            }
        }
    }
}