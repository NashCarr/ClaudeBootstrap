using System;
using CommonDataReturn;
using DataLayerDelete.Administration;

namespace ManagementDelete.Administration
{
    public class ProductGroupDeleteManager : IDisposable
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
            using (DbProductGroupDelete db = new DbProductGroupDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}