using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class EventInfo : ModelBase
    {
        public EventInfo()
        {
            Cash = 0;
            Points = 0;
            Event = string.Empty;
            Detail = string.Empty;
            Attendance = string.Empty;
            LastUpdate = string.Empty;
        }

        public short Cash { get; set; }
        public short Points { get; set; }
        public string Event { get; set; }
        public string Detail { get; set; }
        public string Attendance { get; set; }
        public string LastUpdate { get; set; }
    }
}