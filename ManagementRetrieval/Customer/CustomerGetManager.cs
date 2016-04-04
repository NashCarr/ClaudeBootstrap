using System;
using DataLayerRetrieval.Customer;
using DataRetrievalCommon.Places;

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
            using (DbCustomerViewGet data = new DbCustomerViewGet())
            {
                return data.GetCustomer(recordId);
            }
        }
    }
}