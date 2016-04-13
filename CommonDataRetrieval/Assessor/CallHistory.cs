using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class CallHistory : ModelBase
    {
        public CallHistory()
        {
            Email = string.Empty;
            Reason = string.Empty;
            Outcome = string.Empty;
            Remarks = string.Empty;
            CallDate = string.Empty;
        }

        public string Email { get; set; }
        public string Reason { get; set; }
        public string Outcome { get; set; }
        public string Remarks { get; set; }
        public string CallDate { get; set; }
    }
}