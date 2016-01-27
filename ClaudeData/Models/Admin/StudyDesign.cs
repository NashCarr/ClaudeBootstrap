using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class StudyDesign : AdminBase
    {
        public StudyDesign()
        {
            PostalZoneId = 0;
        }

        public int PostalZoneId { get; set; }
    }
}