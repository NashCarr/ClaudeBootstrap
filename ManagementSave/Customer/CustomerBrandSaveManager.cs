using System;
using CommonDataReturn;
using CommonDataSave.Customer;
using DataLayerSave.Customer;

namespace ManagementSave.Customer
{
    public class CustomerBrandSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(CustomerBrandSave entity)
        {
            using (DbCustomerBrandSave db = new DbCustomerBrandSave())
            {
                return db.AddUpdateRecord(entity);
            }
        }
    }
}