using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Administration;
using SaveDataCommon;

namespace ManagementSave.Administration
{
    public class GiftCardManager : IDisposable
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
            using (DbGiftCardSave db = new DbGiftCardSave())
            {
                return db.AddUpdateRecord(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbGiftCardSave db = new DbGiftCardSave())
            {
                return db.SetInactive(id);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.GiftCardReorderSave(data);
            }
        }
    }
}