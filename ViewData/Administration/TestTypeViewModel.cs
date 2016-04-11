using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using ManagementRetrieval.Administration;

namespace ViewData.Administration
{
    public class TestTypeViewModel
    {
        public TestTypeViewModel()
        {
            using (AdministrationGetManager mgr = new AdministrationGetManager())
            {
                ListEntity = mgr.GetTestTypeList();
            }
        }

        public List<TestType> ListEntity { get; set; }
    }
}