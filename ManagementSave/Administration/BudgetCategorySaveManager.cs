using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Administration;
using SaveDataCommon;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.Return;

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

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.BudgetCategoryReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbBudgetCategorySave db = new DbBudgetCategorySave())
            {
                return db.SetInactive(id);
            }
        }
    }
}