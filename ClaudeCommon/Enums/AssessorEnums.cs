using System.ComponentModel;

namespace ClaudeCommon.Enums
{
    public class AssessorEnums
    {
        public enum Articulate : byte
        {
            [Description("Not Rated")] NotRated,
            Articulate,
            InArticulate
        }

        public enum AssessorStatus : byte
        {
            None,
            Inactive,
            Suspended,
            [Description("Do Not Use")] DoNotUse
        }

        public enum AssessorType : byte
        {
            None,
            Consumer,
            Employee
        }

        public enum Deduplication : byte
        {
            No,
            Approved,
            Denied
        }

        public enum FamilyRelationship : byte
        {
            None,
            [Description("Spouse (Partner)")] SpousePartner,
            [Description("Former Spouse (Partner)")] FormerSpousePartner,
            Child,
            [Description("Parent (Guardian)")] ParentGuardian
        }

        public enum InactiveCode : byte
        {
            None,
            Moving,
            Time,
            [Description("Not Qualified")] NotQualified,
            [Description("Bad Study")] BadStudy,
            [Description("Bad Person")] BadPerson,
            Other,
            Deduplicate,
            [Description("Email Opt-Out")] EmailOptOut,
            Disengaged
        }

        public enum IncreaseDecrease : byte
        {
            None,
            Increase,
            Decrease
        }

        public enum OptOut : byte
        {
            None,
            [Description("Study Only")] StudyOnly,
            [Description("All Emails")] AllEmails,
            [Description("Whole Database")] WholeDatabase,
            Nevermind
        }

        public enum OrganizationApproval : byte
        {
            None,
            Approved,
            [Description("Hold (Not Approved)")] HoldNotApproved,
            [Description("Remove Permanently")] RemovePermanently
        }

        public enum PhonePreference : byte
        {
            None,
            Home,
            Cell,
            Work
        }
    }
}