using System.Collections.Generic;
using CommonData.Models.Administration;
using DataLayerRetrieval.Administration;

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