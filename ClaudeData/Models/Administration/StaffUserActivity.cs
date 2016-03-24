using System;

namespace ClaudeData.Models.Administration
{
    public class StaffMemberActivity
    {
        public int Logins { get; set; }
        public int StaffMemberId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastParticipation { get; set; }
    }
}