using System.ComponentModel;

namespace ClaudeCommon.Enums
{
    public class StudyEnums
    {
        public enum Attendance : byte
        {
            None,
            Completed,
            Started,
            [Description("No Show")] NoShow
        }

        public enum CallOutcome : byte
        {
            None,
            Busy,
            NoAnswer,
            [Description("Left Message")] LeftMessage,
            [Description("Not Interested")] NotInterested,
            [Description("Remove From Database")] RemoveFromDatabase,
            Disqualified,
            Proceeded
        }

        public enum CallPopulation : byte
        {
            None,
            Prequalified,
            [Description("Returning Call")] ReturningCall,
            [Description("Qualified Not Scheduled")] QualifiedNotScheduled,
            Scheduled
        }

        public enum CompensationType : byte
        {
            None,
            Cash,
            [Description("Gift Card")] GiftCard,
            Points
        }

        public enum FacilityStatus : byte
        {
            None,
            Development,
            Opened,
            Postponed,
            Cancelled,
            Closed
        }

        public enum QuotaApplication : byte
        {
            None,
            Study,
            Session
        }

        public enum QuotaLimit : byte
        {
            None,
            Minimum,
            Maximum,
            Range,
            Exact
        }

        public enum QuotaUnit : byte
        {
            None,
            Number,
            Percentage
        }

        public enum ScheduleSource : byte
        {
            None,
            Self,
            [Description("Dummy Ids")] DummyId = 20,
            [Description("Auto-List")] AutoList,
            Qualified,
            Scheduled,
            [Description("Call-Back List")] CallBack = 28,
            [Description("Paper Screener")] PaperScreener = 30
        }

        public enum SessionCode : short
        {
            None,
            Postponed = 980,
            [Description("Waiting List")] WaitingList = 985,
            [Description("Cannot Attend")] CannotAttend = 991,
            Cancelled = 992,
            Rejected = 993,
            [Description("Bar From Study")] BarFromStudy = 994,
            [Description("Study Cancelled")] StudyCancelled = 999
        }

        public enum SessionStatus : byte
        {
            None,
            Opened,
            Closed,
            Hidden
        }

        public enum StudyClass : byte
        {
            None,
            [Description("Open (No Limits)")] OpenNoLimits,
            [Description("Open (Cookie Restriction)")] OpenCookie,
            [Description("Open (Password Restriction)")] OpenPassword,
            [Description("Open (Cookie/Password Restriction)")] OpenCookiePassword,
            List,
            Panel,
            [Description("List Panel Hybrid")] ListPanel
        }

        public enum StudyStatus : byte
        {
            Requested,
            Development,
            Opened,
            Postponed,
            Cancelled,
            Closed
        }

        public enum TestStudyLoginResult : byte
        {
            None,
            [Description("UserName Password Invalid")] UserNamePasswordInvalid,
            [Description("No Study Exists")] NoStudyExists,
            [Description("Multiple Studies")] MultipleStudies,
            [Description("No Show/Cancel/Paid and Sent")] NoShowCancelPaidSent,
            [Description("Already Completed")] Completed,
            [Description("Too Early")] TooEarly,
            [Description("To Late")] TooLate,
            Confidentiality,
            [Description("Go to CLT.html")] GoToClt
        }
    }
}