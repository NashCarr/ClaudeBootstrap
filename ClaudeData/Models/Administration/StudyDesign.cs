using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
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