using System;
using System.Collections.Generic;
using CommonDataSave.Customer;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
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

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.CustomerBrandReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbCustomerBrandSave db = new DbCustomerBrandSave())
            {
                return db.SetInactive(recordId);
            }
        }
    }
}