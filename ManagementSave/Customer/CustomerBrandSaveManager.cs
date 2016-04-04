using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Customer;
using SaveDataCommon.Customer;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.Return;

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