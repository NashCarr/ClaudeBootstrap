using System;
using CommonDataReturn;
using CommonDataSave;
using DataLayerSave.Administration;

namespace ManagementSave.Administration
{
    public class BudgetCategorySaveManager : IDisposable
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
            using (DbBudgetCategorySave db = new DbBudgetCategorySave())
            {
                return db.AddUpdateRecord(data);
            }
        }
    }
}