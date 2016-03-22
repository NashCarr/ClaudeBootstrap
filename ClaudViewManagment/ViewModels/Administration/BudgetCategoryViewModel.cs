using System.Collections.Generic;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;

namespace ClaudeViewManagement.ViewModels.Administration
{
    public class BudgetCategoryViewModel
    {
        public BudgetCategoryViewModel()
        {
            using (BudgetCategoryManager mgr = new BudgetCategoryManager())
            {
                ListEntity = mgr.GetList();
            }
        }

        public List<BudgetCategory> ListEntity { get; set; }
    }
}