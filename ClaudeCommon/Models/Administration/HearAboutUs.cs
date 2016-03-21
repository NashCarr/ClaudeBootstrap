using System;

namespace ClaudeCommon.Models.Administration
{
    public class HearAboutUs
    {
        public HearAboutUs()
        {
            RecordId = 0;
            DisplayOrder = 0;
            Name = string.Empty;
            DisplaySort = string.Empty;
            StringCreateDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
        public bool IsSystem { get; set; }
        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string StringCreateDate { get; set; }
    }
}