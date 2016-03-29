using System;

namespace ClaudeCommon.BaseModels
{
    public class AdministrationBase
    {
        public AdministrationBase()
        {
            RecordId = 0;
            DisplayOrder = 0;
            Name = string.Empty;
            DisplaySort = string.Empty;
            StringLastUpdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string StringLastUpdate { get; set; }
    }
}