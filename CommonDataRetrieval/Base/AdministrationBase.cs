using System;

namespace CommonDataRetrieval.Base
{
    public class AdministrationBase : ModelBase
    {
        public AdministrationBase()
        {
            DisplayOrder = 0;
            DisplaySort = string.Empty;
            StringLastUpdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string StringLastUpdate { get; set; }
    }
}