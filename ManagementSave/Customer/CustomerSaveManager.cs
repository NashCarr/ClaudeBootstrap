using System;
using System.Collections.Generic;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
using DataLayerSave.Place;

namespace ManagementSave.Customer
{
    public class CustomerSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
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
            using (DbPlaceSetInactive db = new DbPlaceSetInactive())
            {
                return db.SetCustomerInactive(id);
            }
        }
    }
}