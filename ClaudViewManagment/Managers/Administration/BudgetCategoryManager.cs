using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;
using DataManagement.DataRepository.ReorderRepository;
using DataSaveLayer.Administration;

namespace ViewManagement.Managers.Administration
{
    public class BudgetCategoryManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(BudgetCategory entity)
        {
            using (DbBudgetCategorySave data = new DbBudgetCategorySave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.BudgetCategoryReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbBudgetCategorySave data = new DbBudgetCategorySave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}