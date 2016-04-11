using System;
using CommonDataReturn;
using DataLayerDelete.Administration;

namespace ManagementDelete.Administration
{
    public class TestTypeDeleteManager : IDisposable
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
            using (DbTestTypeDelete db = new DbTestTypeDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}