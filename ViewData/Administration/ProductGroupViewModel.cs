using System.Collections.Generic;
using DataLayerRetrieval.Administration;
using ViewDataCommon.Administration;

namespace ViewData.Administration
{
    public class ProductGroupViewModel
    {
        public ProductGroupViewModel()
        {
            using (DbProductGroupGet mgr = new DbProductGroupGet())
            {
                ListEntity = mgr.GetViewModel();
            }
        }

        public List<ProductGroup> ListEntity { get; set; }
    }
}