using System;

namespace ClaudeData.Models.Admin
{
    public class StaffUserActivity
    {
        public int StaffUserId { get; set; }
        public int Logins { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastParticipation { get; set; }
    }
}