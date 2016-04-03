using System.Collections.Generic;
using CommonData.Models.Administration;
using DataLayerRetrieval.Administration;

namespace ViewData.Administration
{
    public class BudgetCategoryViewModel
    {
        public BudgetCategoryViewModel()
        {
            using (DbBudgetCategoryGet data = new DbBudgetCategoryGet())
            {
                ListEntity = data.GetViewModel();
            }
        }

        public List<BudgetCategory> ListEntity { get; set; }
    }
}