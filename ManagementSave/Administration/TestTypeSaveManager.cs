using System;
using CommonDataReturn;
using CommonDataSave.Administration;
using DataLayerSave.Administration;

namespace ManagementSave.Administration
{
    public class TestTypeSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(TestTypeSave data)
        {
            using (DbTestTypeSave db = new DbTestTypeSave())
            {
                return db.AddUpdateRecord(data);
            }
        }
    }
}