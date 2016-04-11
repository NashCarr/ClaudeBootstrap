using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using DataLayerRetrieval.Administration;

namespace ViewData.Administration
{
    public class TestTypeViewModel
    {
        public TestTypeViewModel()
        {
            using (DbTestTypeGet mgr = new DbTestTypeGet())
            {
                ListEntity = mgr.GetViewModel();
            }
        }

        public List<TestType> ListEntity { get; set; }
    }
}