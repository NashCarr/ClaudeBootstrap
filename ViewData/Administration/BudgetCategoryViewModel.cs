using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using ManagementRetrieval.Administration;

namespace ViewData.Administration
{
    public class BudgetCategoryViewModel
    {
        public BudgetCategoryViewModel()
        {
            using (AdministrationGetManager mgr = new AdministrationGetManager())
            {
                ListEntity = mgr.GetBudgetCategoryList();
            }
        }

        public List<BudgetCategory> ListEntity { get; set; }
    }
}