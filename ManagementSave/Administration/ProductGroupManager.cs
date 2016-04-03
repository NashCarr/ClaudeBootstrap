using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Administration;
using SaveDataCommon;

namespace ManagementSave.Administration
{
    public class ProductGroupManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(SaveBase data)
        {
            using (DbProductGroupSave db = new DbProductGroupSave())
            {
                return db.AddUpdateRecord(data);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.ProductGroupReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbProductGroupSave db = new DbProductGroupSave())
            {
                return db.SetInactive(id);
            }
        }
    }
}