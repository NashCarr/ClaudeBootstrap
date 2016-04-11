using System;
using CommonDataReturn;
using DataLayerDelete.Customer;

namespace ManagementDelete.Customer
{
    public class CustomerBrandDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbCustomerBrandDelete db = new DbCustomerBrandDelete())
            {
                return db.SetInactive(recordId);
            }
        }
    }
}