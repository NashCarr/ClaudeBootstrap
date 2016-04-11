using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using ManagementRetrieval.Administration;

namespace ViewData.Administration
{
    public class ProductGroupViewModel
    {
        public ProductGroupViewModel()
        {
            using (AdministrationGetManager mgr = new AdministrationGetManager())
            {
                ListEntity = mgr.GetProductGroupList();
            }
        }

        public List<ProductGroup> ListEntity { get; set; }
    }
}