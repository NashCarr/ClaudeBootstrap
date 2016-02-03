using System;

namespace ClaudeCommon.Models
{
    public class GiftCard
    {
        public GiftCard()
        {
            RecordId = 0;
            DisplayOrder = 0;
            Name = string.Empty;
            StringCreateDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
        public short DisplayOrder { get; set; }
        public string StringCreateDate { get; set; }
    }
}