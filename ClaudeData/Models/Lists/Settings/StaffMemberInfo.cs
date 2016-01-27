using System;

namespace ClaudeData.Models.Lists.Settings
{
    public class StaffMemberInfo
    {
        public StaffMemberInfo()
        {
            PersonId = 0;
            Email = string.Empty;
            UserId = string.Empty;
            UserName = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            AccessRight = string.Empty;
        }

        public int PersonId { get; set; }

        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public string AccessRight { get; set; }

        public DateTime? LastLogin { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}