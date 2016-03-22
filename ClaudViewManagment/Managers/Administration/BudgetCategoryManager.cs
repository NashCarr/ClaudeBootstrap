using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Administration;
using ClaudeData.DataRepository.AdministrationRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Administration
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

        public List<BudgetCategory> GetList()
        {
            using (DbBudgetCategoryGet data = new DbBudgetCategoryGet())
            {
                return data.GetViewModel();
            }
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