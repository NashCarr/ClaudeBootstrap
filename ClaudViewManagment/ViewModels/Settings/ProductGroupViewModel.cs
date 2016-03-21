using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Settings;

namespace ClaudeViewManagement.ViewModels.Settings
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