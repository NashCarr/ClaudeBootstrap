using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class AssessorNote : ModelBase
    {
        public AssessorNote()
        {
            StaffMemberId = 0;
            Note = string.Empty;
            LastUpdate = string.Empty;
            StaffMemberName = string.Empty;
        }

        public string Note { get; set; }
        public string LastUpdate { get; set; }
        public short StaffMemberId { get; set; }
        public string StaffMemberName { get; set; }
    }
}