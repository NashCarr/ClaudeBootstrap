using System;
using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using DataLayerRetrieval.Administration;

namespace ManagementRetrieval.Administration
{
    public class AdministrationGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<GiftCard> GetGiftCardList()
        {
            using (DbGiftCardGet db = new DbGiftCardGet())
            {
                return db.GetViewModel();
            }
        }

        public List<TestType> GetTestTypeList()
        {
            using (DbTestTypeGet db = new DbTestTypeGet())
            {
                return db.GetViewModel();
            }
        }

        public List<ProductGroup> GetProductGroupList()
        {
            using (DbProductGroupGet db = new DbProductGroupGet())
            {
                return db.GetViewModel();
            }
        }

        public List<HearAboutUs> GetHearAboutUsList()
        {
            using (DbHearAboutUsGet db = new DbHearAboutUsGet())
            {
                return db.GetViewModel();
            }
        }

        public List<BudgetCategory> GetBudgetCategoryList()
        {
            using (DbBudgetCategoryGet db = new DbBudgetCategoryGet())
            {
                return db.GetViewModel();
            }
        }
    }
}