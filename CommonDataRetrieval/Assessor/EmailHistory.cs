using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class EmailHistory : ModelBase
    {
        public EmailHistory()
        {
            Email = string.Empty;
            Campaign = string.Empty;
            SentDate = string.Empty;
            OpenDate = string.Empty;
            ClickDate = string.Empty;
            BounceDate = string.Empty;
        }

        public string Email { get; set; }
        public string Campaign { get; set; }
        public string SentDate { get; set; }
        public string OpenDate { get; set; }
        public string ClickDate { get; set; }
        public string BounceDate { get; set; }
    }
}