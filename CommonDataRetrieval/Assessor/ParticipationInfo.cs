using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class ParticipationInfo : ModelBase
    {
        public ParticipationInfo()
        {
            NoShow = 0;
            Screeners = 0;
            Qualified = 0;
            Completed = 0;
            Cancelled = 0;
        }

        public short NoShow { get; set; }
        public short Screeners { get; set; }
        public short Qualified { get; set; }
        public short Completed { get; set; }
        public short Cancelled { get; set; }
    }
}