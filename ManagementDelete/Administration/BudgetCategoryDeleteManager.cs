using System;
using CommonDataReturn;
using DataLayerDelete.Administration;

namespace ManagementDelete.Administration
{
    public class BudgetCategoryDeleteManager : IDisposable
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
            using (DbBudgetCategoryDelete db = new DbBudgetCategoryDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}