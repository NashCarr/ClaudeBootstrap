using System;
using CommonDataReturn;
using DataLayerDelete.Administration;

namespace ManagementDelete.Administration
{
    public class HearAboutUsDeleteManager : IDisposable
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
            using (DbHearAboutUsDelete db = new DbHearAboutUsDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}