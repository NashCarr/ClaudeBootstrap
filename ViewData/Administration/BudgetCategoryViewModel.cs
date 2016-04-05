using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using DataLayerRetrieval.Administration;

namespace ViewData.Administration
{
    public class BudgetCategoryViewModel
    {
        public BudgetCategoryViewModel()
        {
            using (DbBudgetCategoryGet db = new DbBudgetCategoryGet())
            {
                ListEntity = db.GetViewModel();
            }
        }

        public List<BudgetCategory> ListEntity { get; set; }
    }
}