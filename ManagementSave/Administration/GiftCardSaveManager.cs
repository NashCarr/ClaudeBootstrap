using System;
using CommonDataReturn;
using CommonDataSave;
using DataLayerSave.Administration;

namespace ManagementSave.Administration
{
    public class GiftCardSaveManager : IDisposable
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
    }
}