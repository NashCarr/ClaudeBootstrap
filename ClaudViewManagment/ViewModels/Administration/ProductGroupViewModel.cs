using System.Collections.Generic;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;

namespace ClaudeViewManagement.ViewModels.Administration
{
    public class ProductGroupViewModel
    {
        public ProductGroupViewModel()
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                ListEntity = mgr.GetList();
            }
        }

        public List<ProductGroup> ListEntity { get; set; }
    }
}