using System;
using CommonDataReturn;
using DataLayerDelete.Administration;

namespace ManagementDelete.Administration
{
    public class GiftCardDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbGiftCardDelete db = new DbGiftCardDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}